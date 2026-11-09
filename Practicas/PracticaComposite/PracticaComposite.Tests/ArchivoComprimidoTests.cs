using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaComposite.Tests;

/// <summary>
/// Pruebas unitarias de la clase ArchivoComprimido (compuesto del Composite).
/// </summary>
[TestClass]
public class ArchivoComprimidoTests
{
    private const double Delta = 0.0001;

    private ArchivoComprimido comprimido = null!;

    [TestInitialize]
    public void SetUp()
    {
        comprimido = new ArchivoComprimido("datos.zip");
    }

    // ---------------- Número de archivos ----------------

    [TestMethod]
    public void NumArchivos_Vacio_EsUno()
    {
        Assert.AreEqual(1, comprimido.NumArchivos);
    }

    [TestMethod]
    public void NumArchivos_ConVariosArchivos_SigueSiendoUno()
    {
        comprimido.Anhadir(new Archivo("a.txt", 10));
        comprimido.Anhadir(new Archivo("b.txt", 20));
        comprimido.Anhadir(new Archivo("c.txt", 30));
        Assert.AreEqual(1, comprimido.NumArchivos);
    }

    [TestMethod]
    public void NumArchivos_ConDirectoriosYComprimidosDentro_SigueSiendoUno()
    {
        Directorio dir = new Directorio("dir");
        dir.Anhadir(new Archivo("a.txt", 10));
        ArchivoComprimido otro = new ArchivoComprimido("otro.zip");
        otro.Anhadir(new Archivo("b.txt", 20));
        comprimido.Anhadir(dir);
        comprimido.Anhadir(otro);
        Assert.AreEqual(1, comprimido.NumArchivos);
    }

    // ---------------- Tamaño ----------------

    [TestMethod]
    public void Tamanho_Vacio_EsUnKb()
    {
        Assert.AreEqual(1, comprimido.Tamanho, Delta);
    }

    [TestMethod]
    public void Tamanho_ConArchivos_EsTreintaPorCientoMasUno()
    {
        comprimido.Anhadir(new Archivo("a.txt", 100));
        comprimido.Anhadir(new Archivo("b.txt", 50));
        // 0.3 * 150 + 1
        Assert.AreEqual(46, comprimido.Tamanho, Delta);
    }

    [TestMethod]
    public void Tamanho_ConDirectorioDentro_IncluyeLaDefinicionDelDirectorio()
    {
        Directorio dir = new Directorio("dir");
        dir.Anhadir(new Archivo("a.txt", 99));
        comprimido.Anhadir(dir);
        // 0.3 * (1 + 99) + 1
        Assert.AreEqual(31, comprimido.Tamanho, Delta);
    }

    [TestMethod]
    public void Tamanho_ComprimidoDentroDeComprimido_SeComprimeDosVeces()
    {
        ArchivoComprimido interior = new ArchivoComprimido("interior.zip");
        interior.Anhadir(new Archivo("a.txt", 100));   // interior = 0.3 * 100 + 1 = 31
        comprimido.Anhadir(interior);
        // 0.3 * 31 + 1
        Assert.AreEqual(10.3, comprimido.Tamanho, Delta);
    }

    [TestMethod]
    public void Anhadir_ASiMismo_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ArgumentException>(() => comprimido.Anhadir(comprimido));
    }
}
