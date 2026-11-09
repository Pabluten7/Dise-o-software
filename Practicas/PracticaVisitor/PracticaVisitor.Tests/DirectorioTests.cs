using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaVisitor.Tests;

/// <summary>
/// Pruebas unitarias de la clase Directorio (compuesto del Composite).
/// </summary>
[TestClass]
public class DirectorioTests
{
    private const double Delta = 0.0001;

    private Directorio directorio = null!;

    [TestInitialize]
    public void SetUp()
    {
        directorio = new Directorio("docs");
    }

    // ---------------- Número de archivos ----------------

    [TestMethod]
    public void NumArchivos_DirectorioVacio_EsCero()
    {
        Assert.AreEqual(0, directorio.NumArchivos);
    }

    [TestMethod]
    public void NumArchivos_ConVariosArchivos_LosCuentaTodos()
    {
        directorio.Anhadir(new Archivo("a.txt", 10));
        directorio.Anhadir(new Archivo("b.txt", 20));
        directorio.Anhadir(new Archivo("c.txt", 30));
        Assert.AreEqual(3, directorio.NumArchivos);
    }

    [TestMethod]
    public void NumArchivos_ConSubdirectorios_CuentaLosArchivosDeTodosLosNiveles()
    {
        Directorio sub = new Directorio("sub");
        Directorio subSub = new Directorio("subSub");
        directorio.Anhadir(new Archivo("a.txt", 10));
        directorio.Anhadir(sub);
        sub.Anhadir(new Archivo("b.txt", 20));
        sub.Anhadir(subSub);
        subSub.Anhadir(new Archivo("c.txt", 30));
        Assert.AreEqual(3, directorio.NumArchivos);
    }

    [TestMethod]
    public void NumArchivos_SoloDirectoriosVacios_EsCero()
    {
        directorio.Anhadir(new Directorio("vacio1"));
        directorio.Anhadir(new Directorio("vacio2"));
        Assert.AreEqual(0, directorio.NumArchivos);
    }

    [TestMethod]
    public void NumArchivos_ConArchivoComprimido_CuentaElComprimidoComoUno()
    {
        ArchivoComprimido zip = new ArchivoComprimido("fotos.zip");
        zip.Anhadir(new Archivo("a.jpg", 10));
        zip.Anhadir(new Archivo("b.jpg", 20));
        directorio.Anhadir(zip);
        directorio.Anhadir(new Archivo("c.txt", 30));
        Assert.AreEqual(2, directorio.NumArchivos);
    }

    // ---------------- Tamaño ----------------

    [TestMethod]
    public void Tamanho_DirectorioVacio_EsUnKb()
    {
        Assert.AreEqual(1, directorio.Tamanho, Delta);
    }

    [TestMethod]
    public void Tamanho_ConArchivos_EsUnoMasLaSuma()
    {
        directorio.Anhadir(new Archivo("a.txt", 10));
        directorio.Anhadir(new Archivo("b.txt", 20));
        Assert.AreEqual(31, directorio.Tamanho, Delta);
    }

    [TestMethod]
    public void Tamanho_ConSubdirectorios_SumaLaDefinicionDeCadaDirectorio()
    {
        Directorio sub = new Directorio("sub");
        sub.Anhadir(new Archivo("a.txt", 10));
        directorio.Anhadir(sub);
        directorio.Anhadir(new Directorio("vacio"));
        // 1 (docs) + [1 (sub) + 10] + 1 (vacio)
        Assert.AreEqual(13, directorio.Tamanho, Delta);
    }

    [TestMethod]
    public void Tamanho_ConArchivoComprimido_UsaElTamanhoComprimido()
    {
        ArchivoComprimido zip = new ArchivoComprimido("fotos.zip");
        zip.Anhadir(new Archivo("a.jpg", 100));
        directorio.Anhadir(zip);
        // 1 (docs) + [0.3 * 100 + 1] (zip)
        Assert.AreEqual(32, directorio.Tamanho, Delta);
    }

    // ---------------- Gestión de elementos ----------------

    [TestMethod]
    public void Anhadir_ElementoApareceEnElementos()
    {
        Archivo archivo = new Archivo("a.txt", 10);
        directorio.Anhadir(archivo);
        Assert.AreEqual(1, directorio.Elementos.Count);
        Assert.AreSame(archivo, directorio.Elementos[0]);
    }

    [TestMethod]
    public void Eliminar_ElementoContenido_LoQuitaYActualizaLosCalculos()
    {
        Archivo archivo = new Archivo("a.txt", 10);
        directorio.Anhadir(archivo);

        bool eliminado = directorio.Eliminar(archivo);

        Assert.IsTrue(eliminado);
        Assert.AreEqual(0, directorio.Elementos.Count);
        Assert.AreEqual(0, directorio.NumArchivos);
        Assert.AreEqual(1, directorio.Tamanho, Delta);
    }

    [TestMethod]
    public void Eliminar_ElementoNoContenido_DevuelveFalso()
    {
        Assert.IsFalse(directorio.Eliminar(new Archivo("a.txt", 10)));
    }

    [TestMethod]
    public void Anhadir_Nulo_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => directorio.Anhadir(null!));
    }

    [TestMethod]
    public void Anhadir_ElMismoElementoDosVeces_LanzaExcepcion()
    {
        Archivo archivo = new Archivo("a.txt", 10);
        directorio.Anhadir(archivo);
        Assert.ThrowsExactly<ArgumentException>(() => directorio.Anhadir(archivo));
    }

    [TestMethod]
    public void Anhadir_ASiMismo_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ArgumentException>(() => directorio.Anhadir(directorio));
    }

    [TestMethod]
    public void Anhadir_UnAntecesor_LanzaExcepcion()
    {
        Directorio sub = new Directorio("sub");
        Directorio subSub = new Directorio("subSub");
        directorio.Anhadir(sub);
        sub.Anhadir(subSub);
        Assert.ThrowsExactly<ArgumentException>(() => subSub.Anhadir(directorio));
    }

    [TestMethod]
    public void Contiene_ElementoEnNivelProfundo_DevuelveVerdadero()
    {
        Directorio sub = new Directorio("sub");
        Archivo archivo = new Archivo("a.txt", 10);
        directorio.Anhadir(sub);
        sub.Anhadir(archivo);
        Assert.IsTrue(directorio.Contiene(archivo));
    }

    [TestMethod]
    public void Contiene_ElementoAjeno_DevuelveFalso()
    {
        Assert.IsFalse(directorio.Contiene(new Archivo("a.txt", 10)));
    }
}
