using Microsoft.VisualStudio.TestTools.UnitTesting;
using static PracticaStrategy.Tests.SistemaEjemplo;

namespace PracticaStrategy.Tests;

/// <summary>
/// Pruebas de la versión con expresiones lambda: estrategias, visitantes y
/// visor. Comprueban además que dan exactamente los mismos resultados que
/// la versión con el patrón Strategy.
/// </summary>
[TestClass]
public class LambdasTests
{
    // ---------------- Estrategias lambda ----------------

    [TestMethod]
    public void EstrategiasLambda_EjemplosDelEnunciado()
    {
        Assert.AreEqual("Briñón", EstrategiasLambda.Castellano("Briñón"));
        Assert.AreEqual("Brinhón", EstrategiasLambda.Gallega("Briñón"));
        Assert.AreEqual("Brinyón", EstrategiasLambda.Catalana("Briñón"));
        Assert.AreEqual("Brinhon", EstrategiasLambda.InternacionalGallega("Briñón"));
        Assert.AreEqual("Brinyon", EstrategiasLambda.InternacionalCatalana("Briñón"));
    }

    [TestMethod]
    public void EstrategiasLambda_EnheMayuscula()
    {
        Assert.AreEqual("Nhandú", EstrategiasLambda.Gallega("Ñandú"));
        Assert.AreEqual("Nyandu", EstrategiasLambda.InternacionalCatalana("Ñandú"));
    }

    [TestMethod]
    public void QuitarTildes_QuitaTodasLasTildes()
    {
        Assert.AreEqual("aeiou AEIOU", EstrategiasLambda.QuitarTildes("áéíóú ÁÉÍÓÚ"));
    }

    // ---------------- Visitantes con lambdas ----------------

    [TestMethod]
    public void ExtendidoLambda_Gallega_SustituyeEnhes()
    {
        string esperado = Lineas(
            "d Disenho Software",
            "   f Canción.mp3",
            "   d Anhos",
            "      f Anho 2025.txt",
            "      f Nhandú.txt",
            "   c Espanha.zip",
            "      f Logronho.jpg",
            "   e Canción.mp3");
        IVisitanteSparrow visitante = new VisitanteExtendidoLambda(EstrategiasLambda.Gallega);
        Assert.AreEqual(esperado, CrearSistemaConEnhes().Aceptar(visitante));
    }

    [TestMethod]
    public void CompactoLambda_LambdaEscritaEnElMomento()
    {
        // Una estrategia nueva sin crear ninguna clase: basta con una lambda
        string esperado = Lineas(
            "AÑOS",
            "   AÑO 2025.TXT",
            "   ÑANDÚ.TXT");
        IVisitanteSparrow visitante = new VisitanteCompactoLambda(texto => texto.ToUpper());
        Assert.AreEqual(esperado, CrearSistemaConEnhes().Elementos[1].Aceptar(visitante));
    }

    [TestMethod]
    public void VersionLambda_DaLosMismosResultadosQueLaVersionStrategy()
    {
        IEstrategiaVisualizacion[] estrategias =
        {
            new EstrategiaCastellano(),
            new EstrategiaGallega(),
            new EstrategiaCatalana(),
            new EstrategiaInternacionalGallega(),
            new EstrategiaInternacionalCatalana()
        };
        Func<string, string>[] lambdas =
        {
            EstrategiasLambda.Castellano,
            EstrategiasLambda.Gallega,
            EstrategiasLambda.Catalana,
            EstrategiasLambda.InternacionalGallega,
            EstrategiasLambda.InternacionalCatalana
        };
        Directorio sistema = CrearSistemaConEnhes();

        for (int i = 0; i < estrategias.Length; i++)
        {
            Assert.AreEqual(
                sistema.Aceptar(new VisitanteExtendido(estrategias[i])),
                sistema.Aceptar(new VisitanteExtendidoLambda(lambdas[i])));
            Assert.AreEqual(
                sistema.Aceptar(new VisitanteCompacto(estrategias[i])),
                sistema.Aceptar(new VisitanteCompactoLambda(lambdas[i])));
        }
    }

    // ---------------- Visor con lambdas ----------------

    [TestMethod]
    public void SparrowViewLambda_MuestraElFormatoExtendidoEntreAdornos()
    {
        StringWriter salida = new StringWriter();
        SparrowViewLambda visor = new SparrowViewLambda(EstrategiasLambda.InternacionalCatalana, salida);

        visor.MostrarSistemaSparrow(new Archivo("Logroño.jpg", 10));

        string esperado = Lineas(
            "======= Sparrow Viewer =======",
            "",
            "f Logronyo.jpg",
            "",
            "==============================");
        Assert.AreEqual(esperado, salida.ToString());
    }

    [TestMethod]
    public void ConstructoresLambda_FuncionNula_LanzanExcepcion()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => new VisitanteCompactoLambda(null!));
        Assert.ThrowsExactly<ArgumentNullException>(() => new VisitanteExtendidoLambda(null!));
        Assert.ThrowsExactly<ArgumentNullException>(() => new SparrowViewLambda(null!, new StringWriter()));
    }
}
