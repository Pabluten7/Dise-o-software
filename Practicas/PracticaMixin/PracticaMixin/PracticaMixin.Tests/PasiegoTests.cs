using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaMixin.Tests;

/// <summary>
/// Pruebas unitarias de la clase Pasiego.
/// </summary>
[TestClass]
public class PasiegoTests
{
    private Pasiego pasiego = null!;

    [TestInitialize]
    public void SetUp()
    {
        pasiego = new Pasiego();
    }

    [TestMethod]
    public void HacerSobaos_DevuelveSobaos()
    {
        Assert.AreEqual("Haciendo Sobaos.", pasiego.HacerSobaos());
    }

    [TestMethod]
    public void HacerQuesada_DevuelveQuesada()
    {
        Assert.AreEqual("Haciendo Quesada.", pasiego.HacerQuesada());
    }

    [TestMethod]
    public void HacerCocido_DevuelveCocidoMontanes()
    {
        Assert.AreEqual("Haciendo Cocido Montañés.", pasiego.HacerCocido());
    }
}
