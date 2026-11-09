using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaComposite.Tests;

/// <summary>
/// Pruebas unitarias de la clase Archivo (hoja del Composite).
/// </summary>
[TestClass]
public class ArchivoTests
{
    private const double Delta = 0.0001;

    [TestMethod]
    public void Tamanho_DevuelveElTamanhoIndicado()
    {
        Archivo archivo = new Archivo("foto.jpg", 250);
        Assert.AreEqual(250, archivo.Tamanho, Delta);
    }

    [TestMethod]
    public void Tamanho_Cero_EsValido()
    {
        Archivo archivo = new Archivo("vacio.txt", 0);
        Assert.AreEqual(0, archivo.Tamanho, Delta);
    }

    [TestMethod]
    public void NumArchivos_EsUno()
    {
        Archivo archivo = new Archivo("foto.jpg", 250);
        Assert.AreEqual(1, archivo.NumArchivos);
    }

    [TestMethod]
    public void Nombre_DevuelveElNombreIndicado()
    {
        Archivo archivo = new Archivo("foto.jpg", 250);
        Assert.AreEqual("foto.jpg", archivo.Nombre);
    }

    [TestMethod]
    public void Nombre_SePuedeCambiar()
    {
        Archivo archivo = new Archivo("foto.jpg", 250);
        archivo.Nombre = "playa.jpg";
        Assert.AreEqual("playa.jpg", archivo.Nombre);
    }

    [TestMethod]
    public void Constructor_NombreVacio_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ArgumentException>(() => new Archivo("  ", 10));
    }

    [TestMethod]
    public void Nombre_CambiarAVacio_LanzaExcepcion()
    {
        Archivo archivo = new Archivo("foto.jpg", 250);
        Assert.ThrowsExactly<ArgumentException>(() => archivo.Nombre = "");
    }

    [TestMethod]
    public void Constructor_TamanhoNegativo_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => new Archivo("foto.jpg", -1));
    }
}
