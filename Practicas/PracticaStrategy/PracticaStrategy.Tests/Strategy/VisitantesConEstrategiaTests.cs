using Microsoft.VisualStudio.TestTools.UnitTesting;
using static PracticaStrategy.Tests.SistemaEjemplo;

namespace PracticaStrategy.Tests;

/// <summary>
/// Pruebas de los visitantes de impresión combinados con las distintas
/// estrategias de visualización.
/// </summary>
[TestClass]
public class VisitantesConEstrategiaTests
{
    /// <summary>
    /// Estrategia creada solo para las pruebas. Demuestra que los visitantes
    /// funcionan con cualquier implementación de la interfaz, incluso con
    /// una que no conocen (inversión de dependencias).
    /// </summary>
    private sealed class EstrategiaEntreCorchetes : IEstrategiaVisualizacion
    {
        public string Adaptar(string texto) { return "[" + texto + "]"; }
    }

    [TestMethod]
    public void Extendido_Castellano_MuestraLosNombresTalCual()
    {
        string esperado = Lineas(
            "d Diseño Software",
            "   f Canción.mp3",
            "   d Años",
            "      f Año 2025.txt",
            "      f Ñandú.txt",
            "   c España.zip",
            "      f Logroño.jpg",
            "   e Canción.mp3");
        IVisitanteSparrow visitante = new VisitanteExtendido(new EstrategiaCastellano());
        Assert.AreEqual(esperado, CrearSistemaConEnhes().Aceptar(visitante));
    }

    [TestMethod]
    public void Extendido_Gallega_SustituyeEnhesYMantieneTildes()
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
        IVisitanteSparrow visitante = new VisitanteExtendido(new EstrategiaGallega());
        Assert.AreEqual(esperado, CrearSistemaConEnhes().Aceptar(visitante));
    }

    [TestMethod]
    public void Extendido_Catalana_SustituyeEnhesYMantieneTildes()
    {
        string esperado = Lineas(
            "d Disenyo Software",
            "   f Canción.mp3",
            "   d Anyos",
            "      f Anyo 2025.txt",
            "      f Nyandú.txt",
            "   c Espanya.zip",
            "      f Logronyo.jpg",
            "   e Canción.mp3");
        IVisitanteSparrow visitante = new VisitanteExtendido(new EstrategiaCatalana());
        Assert.AreEqual(esperado, CrearSistemaConEnhes().Aceptar(visitante));
    }

    [TestMethod]
    public void Extendido_InternacionalGallega_QuitaTildesYSustituyeEnhes()
    {
        string esperado = Lineas(
            "d Disenho Software",
            "   f Cancion.mp3",
            "   d Anhos",
            "      f Anho 2025.txt",
            "      f Nhandu.txt",
            "   c Espanha.zip",
            "      f Logronho.jpg",
            "   e Cancion.mp3");
        IVisitanteSparrow visitante = new VisitanteExtendido(new EstrategiaInternacionalGallega());
        Assert.AreEqual(esperado, CrearSistemaConEnhes().Aceptar(visitante));
    }

    [TestMethod]
    public void Compacto_InternacionalCatalana_QuitaTildesYSustituyeEnhes()
    {
        string esperado = Lineas(
            "Disenyo Software",
            "   Cancion.mp3",
            "   Anyos",
            "      Anyo 2025.txt",
            "      Nyandu.txt",
            "   Espanya.zip",
            "   Cancion.mp3");
        IVisitanteSparrow visitante = new VisitanteCompacto(new EstrategiaInternacionalCatalana());
        Assert.AreEqual(esperado, CrearSistemaConEnhes().Aceptar(visitante));
    }

    [TestMethod]
    public void Visitante_AdaptaSoloLosNombres_NoLaLetraNiLaTabulacion()
    {
        string esperado = Lineas(
            "d [Años]",
            "   f [Año 2025.txt]",
            "   f [Ñandú.txt]");
        IVisitanteSparrow visitante = new VisitanteExtendido(new EstrategiaEntreCorchetes());
        Assert.AreEqual(esperado, CrearSistemaConEnhes().Elementos[1].Aceptar(visitante));
    }

    [TestMethod]
    public void SistemaDeEjemplo_ConCualquierEstrategia_NoCambia()
    {
        // El sistema del enunciado no tiene eñes ni tildes
        string castellano = CrearFigura1().Aceptar(new VisitanteExtendido(new EstrategiaCastellano()));
        string internacional = CrearFigura1().Aceptar(new VisitanteExtendido(new EstrategiaInternacionalCatalana()));
        Assert.AreEqual(castellano, internacional);
    }

    [TestMethod]
    public void Constructores_EstrategiaNula_LanzanExcepcion()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => new VisitanteCompacto(null!));
        Assert.ThrowsExactly<ArgumentNullException>(() => new VisitanteExtendido(null!));
    }
}
