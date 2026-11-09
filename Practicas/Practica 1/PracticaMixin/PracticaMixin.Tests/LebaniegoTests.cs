using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaMixin.Tests;

/// <summary>
/// Pruebas unitarias de la clase Lebaniego.
/// </summary>
[TestClass]
public class LebaniegoTests
{
    private Lebaniego lebaniego = null!;

    [TestInitialize]
    public void SetUp()
    {
        lebaniego = new Lebaniego();
    }

    [TestMethod]
    public void HacerCocido_DevuelveCocidoLebaniego()
    {
        Assert.AreEqual("Haciendo Cocido Lebaniego.", lebaniego.HacerCocido());
    }

    [TestMethod]
    public void HacerOrujo_DevuelveOrujo()
    {
        Assert.AreEqual("Haciendo Orujo.", lebaniego.HacerOrujo());
    }
}
