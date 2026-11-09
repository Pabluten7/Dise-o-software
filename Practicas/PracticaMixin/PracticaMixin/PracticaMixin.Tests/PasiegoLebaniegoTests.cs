using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaMixin.Tests;

/// <summary>
/// Pruebas unitarias de la clase PasiegoLebaniego (patrón mixin).
/// </summary>
[TestClass]
public class PasiegoLebaniegoTests
{
    private PasiegoLebaniego pasiegoLebaniego = null!;

    [TestInitialize]
    public void SetUp()
    {
        pasiegoLebaniego = new PasiegoLebaniego();
    }

    // ---------------------------------------------------------------
    // Figura 1: comportamiento reutilizado por delegación
    // ---------------------------------------------------------------

    [TestMethod]
    public void HacerSobaos_DevuelveSobaos()
    {
        Assert.AreEqual("Haciendo Sobaos.", pasiegoLebaniego.HacerSobaos());
    }

    [TestMethod]
    public void HacerQuesada_DevuelveQuesada()
    {
        Assert.AreEqual("Haciendo Quesada.", pasiegoLebaniego.HacerQuesada());
    }

    [TestMethod]
    public void HacerOrujo_DevuelveOrujo()
    {
        Assert.AreEqual("Haciendo Orujo.", pasiegoLebaniego.HacerOrujo());
    }

    [TestMethod]
    public void HacerCocido_PorDefecto_DevuelveCocidoLebaniego()
    {
        Assert.AreEqual("Haciendo Cocido Lebaniego.", pasiegoLebaniego.HacerCocido());
    }

    // ---------------------------------------------------------------
    // Figura 1: tipo reutilizado mediante herencia de interfaces
    // ---------------------------------------------------------------

    [TestMethod]
    public void PasiegoLebaniego_EsDeTipoPasiegoYLebaniego()
    {
        Assert.IsInstanceOfType(pasiegoLebaniego, typeof(IPasiego));
        Assert.IsInstanceOfType(pasiegoLebaniego, typeof(ILebaniego));
    }

    [TestMethod]
    public void PasiegoLebaniego_UsadoComoIPasiego_HaceSobaosYQuesada()
    {
        IPasiego comoPasiego = pasiegoLebaniego;
        Assert.AreEqual("Haciendo Sobaos.", comoPasiego.HacerSobaos());
        Assert.AreEqual("Haciendo Quesada.", comoPasiego.HacerQuesada());
    }

    [TestMethod]
    public void PasiegoLebaniego_UsadoComoILebaniego_HaceOrujo()
    {
        ILebaniego comoLebaniego = pasiegoLebaniego;
        Assert.AreEqual("Haciendo Orujo.", comoLebaniego.HacerOrujo());
    }

    // ---------------------------------------------------------------
    // Figura 2: resolución del conflicto de HacerCocido por contexto
    // ---------------------------------------------------------------

    [TestMethod]
    public void Contexto_PorDefecto_EsLiebana()
    {
        Assert.AreEqual(TipoContexto.Liebana, pasiegoLebaniego.Contexto);
    }

    [TestMethod]
    public void HacerCocido_EnLiebana_DevuelveCocidoLebaniego()
    {
        pasiegoLebaniego.Contexto = TipoContexto.Liebana;
        Assert.AreEqual("Haciendo Cocido Lebaniego.", pasiegoLebaniego.HacerCocido());
    }

    [TestMethod]
    public void HacerCocido_EnPas_DevuelveCocidoMontanes()
    {
        pasiegoLebaniego.Contexto = TipoContexto.Pas;
        Assert.AreEqual("Haciendo Cocido Montañés.", pasiegoLebaniego.HacerCocido());
    }

    [TestMethod]
    public void HacerCocido_CambiandoContexto_CambiaElCocido()
    {
        pasiegoLebaniego.Contexto = TipoContexto.Pas;
        Assert.AreEqual("Haciendo Cocido Montañés.", pasiegoLebaniego.HacerCocido());

        pasiegoLebaniego.Contexto = TipoContexto.Liebana;
        Assert.AreEqual("Haciendo Cocido Lebaniego.", pasiegoLebaniego.HacerCocido());
    }

    [TestMethod]
    public void HacerCocido_UsadoComoIPasiego_DependeDelContexto()
    {
        IPasiego comoPasiego = pasiegoLebaniego;

        pasiegoLebaniego.Contexto = TipoContexto.Liebana;
        Assert.AreEqual("Haciendo Cocido Lebaniego.", comoPasiego.HacerCocido());

        pasiegoLebaniego.Contexto = TipoContexto.Pas;
        Assert.AreEqual("Haciendo Cocido Montañés.", comoPasiego.HacerCocido());
    }

    [TestMethod]
    public void HacerCocido_UsadoComoILebaniego_DependeDelContexto()
    {
        ILebaniego comoLebaniego = pasiegoLebaniego;

        pasiegoLebaniego.Contexto = TipoContexto.Pas;
        Assert.AreEqual("Haciendo Cocido Montañés.", comoLebaniego.HacerCocido());

        pasiegoLebaniego.Contexto = TipoContexto.Liebana;
        Assert.AreEqual("Haciendo Cocido Lebaniego.", comoLebaniego.HacerCocido());
    }

    [TestMethod]
    public void HacerCocido_ContextoInvalido_LanzaExcepcion()
    {
        pasiegoLebaniego.Contexto = (TipoContexto)99;
        Assert.ThrowsExactly<InvalidOperationException>(() => pasiegoLebaniego.HacerCocido());
    }
}
