using Microsoft.VisualStudio.TestTools.UnitTesting;
using static PracticaStrategy.Tests.SistemaEjemplo;

namespace PracticaStrategy.Tests;

/// <summary>
/// Pruebas del visitante de formato compacto.
/// </summary>
[TestClass]
public class VisitanteCompactoTests
{
    private VisitanteCompacto visitante = null!;

    [TestInitialize]
    public void SetUp()
    {
        visitante = new VisitanteCompacto(new EstrategiaCastellano());
    }

    // ---------------- Cada tipo de elemento por separado ----------------

    [TestMethod]
    public void Archivo_MuestraSoloSuNombre()
    {
        Archivo archivo = new Archivo("foto.jpg", 10);
        Assert.AreEqual(Lineas("foto.jpg"), archivo.Aceptar(visitante));
    }

    [TestMethod]
    public void Enlace_MuestraElNombreDeSuDestino()
    {
        Enlace enlace = new Enlace(new Archivo("foto.jpg", 10));
        Assert.AreEqual(Lineas("foto.jpg"), enlace.Aceptar(visitante));
    }

    [TestMethod]
    public void DirectorioVacio_MuestraSoloSuNombre()
    {
        Directorio dir = new Directorio("docs");
        Assert.AreEqual(Lineas("docs"), dir.Aceptar(visitante));
    }

    [TestMethod]
    public void ArchivoComprimido_NoMuestraSuContenido()
    {
        ArchivoComprimido zip = new ArchivoComprimido("fotos.zip");
        zip.Anhadir(new Archivo("a.jpg", 10));
        zip.Anhadir(new Directorio("sub"));
        Assert.AreEqual(Lineas("fotos.zip"), zip.Aceptar(visitante));
    }

    // ---------------- Contenido y tabulación ----------------

    [TestMethod]
    public void Directorio_MuestraSuContenidoTabulado()
    {
        Directorio dir = new Directorio("docs");
        dir.Anhadir(new Archivo("a.txt", 10));
        dir.Anhadir(new Archivo("b.txt", 20));

        string esperado = Lineas(
            "docs",
            "   a.txt",
            "   b.txt");
        Assert.AreEqual(esperado, dir.Aceptar(visitante));
    }

    [TestMethod]
    public void DirectoriosAnidados_TabulanUnNivelMasPorCadaNivel()
    {
        Directorio dir = new Directorio("nivel0");
        Directorio sub = new Directorio("nivel1");
        Directorio subSub = new Directorio("nivel2");
        dir.Anhadir(sub);
        sub.Anhadir(subSub);
        subSub.Anhadir(new Archivo("profundo.txt", 10));
        dir.Anhadir(new Archivo("arriba.txt", 10));

        string esperado = Lineas(
            "nivel0",
            "   nivel1",
            "      nivel2",
            "         profundo.txt",
            "   arriba.txt");
        Assert.AreEqual(esperado, dir.Aceptar(visitante));
    }

    [TestMethod]
    public void EnlaceADirectorio_NoMuestraElContenidoDelDestino()
    {
        Directorio destino = new Directorio("destino");
        destino.Anhadir(new Archivo("a.txt", 10));
        Directorio dir = new Directorio("dir");
        dir.Anhadir(new Enlace(destino));

        string esperado = Lineas(
            "dir",
            "   destino");
        Assert.AreEqual(esperado, dir.Aceptar(visitante));
    }

    // ---------------- Sistema completo ----------------

    [TestMethod]
    public void SistemaDeEjemplo_SeMuestraEnFormatoCompacto()
    {
        string esperado = Lineas(
            "Raiz",
            "   Directorio Vacio",
            "   Directorio Con Archivo Unico",
            "      foto001.jpg",
            "   Directorio Con Archivo Comprimido Simple",
            "      foto002.jpg",
            "      foto001.jpg",
            "      ccSimple.zip",
            "   Directorio con Directorio Anidado",
            "      foto004.jpg",
            "      ccSimple.zip",
            "      Directorio Vacio",
            "      Directorio con Archivo Comprimido Complejo",
            "         foto005",
            "         foto006",
            "         ccComplejo.zip");
        Assert.AreEqual(esperado, CrearFigura1().Aceptar(visitante));
    }

    [TestMethod]
    public void Subelemento_SeMuestraSinTabularDesdeSuPropioNivel()
    {
        ElementoSparrow dirArchivoUnico = CrearFigura1().Elementos[1];

        string esperado = Lineas(
            "Directorio Con Archivo Unico",
            "   foto001.jpg");
        Assert.AreEqual(esperado, dirArchivoUnico.Aceptar(visitante));
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
