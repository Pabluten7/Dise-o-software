using Microsoft.VisualStudio.TestTools.UnitTesting;
using static PracticaStrategy.Tests.SistemaEjemplo;

namespace PracticaStrategy.Tests;

/// <summary>
/// Pruebas del visitante de formato extendido.
/// </summary>
[TestClass]
public class VisitanteExtendidoTests
{
    private VisitanteExtendido visitante = null!;

    [TestInitialize]
    public void SetUp()
    {
        visitante = new VisitanteExtendido(new EstrategiaCastellano());
    }

    // ---------------- Letra de cada tipo de elemento ----------------

    [TestMethod]
    public void Archivo_LlevaLaLetraF()
    {
        Archivo archivo = new Archivo("foto.jpg", 10);
        Assert.AreEqual(Lineas("f foto.jpg"), archivo.Aceptar(visitante));
    }

    [TestMethod]
    public void Directorio_LlevaLaLetraD()
    {
        Directorio dir = new Directorio("docs");
        Assert.AreEqual(Lineas("d docs"), dir.Aceptar(visitante));
    }

    [TestMethod]
    public void ArchivoComprimido_LlevaLaLetraC()
    {
        ArchivoComprimido zip = new ArchivoComprimido("fotos.zip");
        Assert.AreEqual(Lineas("c fotos.zip"), zip.Aceptar(visitante));
    }

    [TestMethod]
    public void Enlace_LlevaLaLetraEYElNombreDelDestino()
    {
        Enlace enlace = new Enlace(new Directorio("docs"));
        Assert.AreEqual(Lineas("e docs"), enlace.Aceptar(visitante));
    }

    // ---------------- Contenido y tabulación ----------------

    [TestMethod]
    public void Directorio_MuestraSuContenidoTabulado()
    {
        Directorio dir = new Directorio("docs");
        dir.Anhadir(new Archivo("a.txt", 10));
        dir.Anhadir(new Enlace(new Archivo("b.txt", 20)));

        string esperado = Lineas(
            "d docs",
            "   f a.txt",
            "   e b.txt");
        Assert.AreEqual(esperado, dir.Aceptar(visitante));
    }

    [TestMethod]
    public void ArchivoComprimido_MuestraSuContenidoTabulado()
    {
        ArchivoComprimido zip = new ArchivoComprimido("fotos.zip");
        zip.Anhadir(new Archivo("a.jpg", 10));
        zip.Anhadir(new Directorio("sub"));

        string esperado = Lineas(
            "c fotos.zip",
            "   f a.jpg",
            "   d sub");
        Assert.AreEqual(esperado, zip.Aceptar(visitante));
    }

    [TestMethod]
    public void ComprimidosYDirectoriosAnidados_TabulanCadaNivel()
    {
        Directorio dir = new Directorio("dir");
        ArchivoComprimido zip = new ArchivoComprimido("z.zip");
        ArchivoComprimido zipInterior = new ArchivoComprimido("interior.zip");
        dir.Anhadir(zip);
        zip.Anhadir(zipInterior);
        zipInterior.Anhadir(new Archivo("a.txt", 10));

        string esperado = Lineas(
            "d dir",
            "   c z.zip",
            "      c interior.zip",
            "         f a.txt");
        Assert.AreEqual(esperado, dir.Aceptar(visitante));
    }

    [TestMethod]
    public void EnlaceAComprimido_NoMuestraElContenidoDelDestino()
    {
        ArchivoComprimido zip = new ArchivoComprimido("fotos.zip");
        zip.Anhadir(new Archivo("a.jpg", 10));
        Directorio dir = new Directorio("dir");
        dir.Anhadir(new Enlace(zip));

        string esperado = Lineas(
            "d dir",
            "   e fotos.zip");
        Assert.AreEqual(esperado, dir.Aceptar(visitante));
    }

    // ---------------- Sistema completo ----------------

    [TestMethod]
    public void SistemaDeEjemplo_CoincideConElEjemploDelEnunciado()
    {
        string esperado = Lineas(
            "d Raiz",
            "   d Directorio Vacio",
            "   d Directorio Con Archivo Unico",
            "      f foto001.jpg",
            "   d Directorio Con Archivo Comprimido Simple",
            "      f foto002.jpg",
            "      e foto001.jpg",
            "      c ccSimple.zip",
            "         d Directorio Vacio En Archivo Comprimido",
            "         f foto003.jpg",
            "         e foto001.jpg",
            "   d Directorio con Directorio Anidado",
            "      f foto004.jpg",
            "      e ccSimple.zip",
            "      e Directorio Vacio",
            "      d Directorio con Archivo Comprimido Complejo",
            "         f foto005",
            "         f foto006",
            "         c ccComplejo.zip",
            "            c ccAnidada.zip",
            "               f foto007.jpg",
            "            f foto008.jpg");
        Assert.AreEqual(esperado, CrearFigura1().Aceptar(visitante));
    }

    [TestMethod]
    public void Subelemento_SeMuestraSinTabularDesdeSuPropioNivel()
    {
        ElementoSparrow dirComprimidoSimple = CrearFigura1().Elementos[2];

        string esperado = Lineas(
            "d Directorio Con Archivo Comprimido Simple",
            "   f foto002.jpg",
            "   e foto001.jpg",
            "   c ccSimple.zip",
            "      d Directorio Vacio En Archivo Comprimido",
            "      f foto003.jpg",
            "      e foto001.jpg");
        Assert.AreEqual(esperado, dirComprimidoSimple.Aceptar(visitante));
    }

    [TestMethod]
    public void MismoVisitante_UsadoDosVeces_DaElMismoResultado()
    {
        Directorio raiz = CrearFigura1();
        string primera = raiz.Aceptar(visitante);
        string segunda = raiz.Aceptar(visitante);
        Assert.AreEqual(primera, segunda);
    }
}
