using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaComposite.Tests;

/// <summary>
/// Pruebas unitarias de la clase Enlace.
/// </summary>
[TestClass]
public class EnlaceTests
{
    private const double Delta = 0.0001;

    private Archivo archivo = null!;
    private Enlace enlace = null!;

    [TestInitialize]
    public void SetUp()
    {
        archivo = new Archivo("foto.jpg", 500);
        enlace = new Enlace(archivo);
    }

    // ---------------- Nombre ----------------

    [TestMethod]
    public void Nombre_EsElDelDestino()
    {
        Assert.AreEqual("foto.jpg", enlace.Nombre);
    }

    [TestMethod]
    public void Nombre_RenombrarEnlace_RenombraElDestino()
    {
        enlace.Nombre = "playa.jpg";
        Assert.AreEqual("playa.jpg", archivo.Nombre);
        Assert.AreEqual("playa.jpg", enlace.Nombre);
    }

    [TestMethod]
    public void Nombre_RenombrarDestino_CambiaElNombreDelEnlace()
    {
        archivo.Nombre = "monte.jpg";
        Assert.AreEqual("monte.jpg", enlace.Nombre);
    }

    [TestMethod]
    public void Nombre_RenombrarEnlaceAVacio_LanzaExcepcionYNoCambiaNada()
    {
        Assert.ThrowsExactly<ArgumentException>(() => enlace.Nombre = "");
        Assert.AreEqual("foto.jpg", archivo.Nombre);
    }

    // ---------------- Tamaño y número de archivos ----------------

    [TestMethod]
    public void Tamanho_EsUnKbIndependientementeDelDestino()
    {
        Assert.AreEqual(1, enlace.Tamanho, Delta);
    }

    [TestMethod]
    public void NumArchivos_EsCero()
    {
        Assert.AreEqual(0, enlace.NumArchivos);
    }

    [TestMethod]
    public void EnlaceADirectorio_UsaSuNombrePeroNoSuTamanhoNiArchivos()
    {
        Directorio dir = new Directorio("docs");
        dir.Anhadir(new Archivo("a.txt", 100));
        Enlace enlaceDir = new Enlace(dir);
        Assert.AreEqual("docs", enlaceDir.Nombre);
        Assert.AreEqual(1, enlaceDir.Tamanho, Delta);
        Assert.AreEqual(0, enlaceDir.NumArchivos);
    }

    [TestMethod]
    public void EnlaceAArchivoComprimido_UsaSuNombre()
    {
        ArchivoComprimido zip = new ArchivoComprimido("fotos.zip");
        Enlace enlaceZip = new Enlace(zip);
        Assert.AreEqual("fotos.zip", enlaceZip.Nombre);
    }

    [TestMethod]
    public void Destino_DevuelveElElementoEnlazado()
    {
        Assert.AreSame(archivo, enlace.Destino);
    }

    // ---------------- Enlaces dentro de compuestos ----------------

    [TestMethod]
    public void EnlaceEnDirectorio_SumaUnKbYNoCuentaComoArchivo()
    {
        Directorio dir = new Directorio("dir");
        dir.Anhadir(enlace);
        Assert.AreEqual(2, dir.Tamanho, Delta);   // 1 (dir) + 1 (enlace)
        Assert.AreEqual(0, dir.NumArchivos);
    }

    [TestMethod]
    public void EnlaceEnComprimido_SeComprimeComoCualquierElemento()
    {
        ArchivoComprimido zip = new ArchivoComprimido("z.zip");
        zip.Anhadir(enlace);
        Assert.AreEqual(1.3, zip.Tamanho, Delta);   // 0.3 * 1 + 1
        Assert.AreEqual(1, zip.NumArchivos);
    }

    [TestMethod]
    public void EnlaceASuPropioDirectorio_NoProvocaCiclo()
    {
        Directorio dir = new Directorio("dir");
        dir.Anhadir(new Enlace(dir));
        Assert.AreEqual(2, dir.Tamanho, Delta);
    }

    // ---------------- Restricciones ----------------

    [TestMethod]
    public void Constructor_DestinoNulo_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => new Enlace(null!));
    }

    [TestMethod]
    public void Enlace_NoEsEnlazable_NoSePuedenCrearEnlacesAEnlaces()
    {
        // Un enlace no es un ElementoEnlazable, así que "new Enlace(enlace)"
        // ni siquiera compila. Aquí lo comprobamos sobre la jerarquía de tipos.
        Assert.IsFalse(typeof(ElementoEnlazable).IsAssignableFrom(typeof(Enlace)));
    }
}
