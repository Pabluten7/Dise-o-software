using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaStrategy.Tests;

/// <summary>
/// Pruebas de las estrategias concretas de visualización.
/// </summary>
[TestClass]
public class EstrategiasTests
{
    // ---------------- Castellano ----------------

    [TestMethod]
    public void Castellano_NoModificaNada()
    {
        Assert.AreEqual("Briñón Ñandú Árbol", new EstrategiaCastellano().Adaptar("Briñón Ñandú Árbol"));
    }

    // ---------------- Gallega ----------------

    [TestMethod]
    public void Gallega_EjemploDelEnunciado()
    {
        Assert.AreEqual("Brinhón", new EstrategiaGallega().Adaptar("Briñón"));
    }

    [TestMethod]
    public void Gallega_EnheMayuscula_SeSustituyePorNh()
    {
        Assert.AreEqual("Nhandú", new EstrategiaGallega().Adaptar("Ñandú"));
    }

    [TestMethod]
    public void Gallega_VariasEnhes_SeSustituyenTodas()
    {
        Assert.AreEqual("Nhonho", new EstrategiaGallega().Adaptar("Ñoño"));
    }

    [TestMethod]
    public void Gallega_MantieneLasTildes()
    {
        Assert.AreEqual("Canción Árbol", new EstrategiaGallega().Adaptar("Canción Árbol"));
    }

    // ---------------- Catalana ----------------

    [TestMethod]
    public void Catalana_EjemploDelEnunciado()
    {
        Assert.AreEqual("Brinyón", new EstrategiaCatalana().Adaptar("Briñón"));
    }

    [TestMethod]
    public void Catalana_EnheMayuscula_SeSustituyePorNy()
    {
        Assert.AreEqual("Nyandú", new EstrategiaCatalana().Adaptar("Ñandú"));
    }

    [TestMethod]
    public void Catalana_MantieneLasTildes()
    {
        Assert.AreEqual("Canción Árbol", new EstrategiaCatalana().Adaptar("Canción Árbol"));
    }

    // ---------------- Internacionales ----------------

    [TestMethod]
    public void InternacionalGallega_EjemploDelEnunciado()
    {
        Assert.AreEqual("Brinhon", new EstrategiaInternacionalGallega().Adaptar("Briñón"));
    }

    [TestMethod]
    public void InternacionalCatalana_EjemploDelEnunciado()
    {
        Assert.AreEqual("Brinyon", new EstrategiaInternacionalCatalana().Adaptar("Briñón"));
    }

    [TestMethod]
    public void Internacionales_QuitanTodasLasTildes()
    {
        Assert.AreEqual("aeiou AEIOU", new EstrategiaInternacionalGallega().Adaptar("áéíóú ÁÉÍÓÚ"));
        Assert.AreEqual("aeiou AEIOU", new EstrategiaInternacionalCatalana().Adaptar("áéíóú ÁÉÍÓÚ"));
    }

    [TestMethod]
    public void Internacionales_EnheMayusculaConTilde()
    {
        Assert.AreEqual("Nhandu", new EstrategiaInternacionalGallega().Adaptar("Ñandú"));
        Assert.AreEqual("Nyandu", new EstrategiaInternacionalCatalana().Adaptar("Ñandú"));
    }

    [TestMethod]
    public void Internacionales_NoTocanLaDieresis()
    {
        // La diéresis no es una tilde ortográfica
        Assert.AreEqual("pingüino", new EstrategiaInternacionalGallega().Adaptar("pingüino"));
    }

    // ---------------- Todas ----------------

    [TestMethod]
    public void TodasLasEstrategias_TextoSinCaracteresEspeciales_NoLoModifican()
    {
        IEstrategiaVisualizacion[] estrategias =
        {
            new EstrategiaCastellano(),
            new EstrategiaGallega(),
            new EstrategiaCatalana(),
            new EstrategiaInternacionalGallega(),
            new EstrategiaInternacionalCatalana()
        };

        foreach (IEstrategiaVisualizacion estrategia in estrategias)
        {
            Assert.AreEqual("foto001.jpg", estrategia.Adaptar("foto001.jpg"));
        }
    }
}
