using Microsoft.VisualStudio.TestTools.UnitTesting;
using static PracticaVisitor.Tests.SistemaEjemplo;

namespace PracticaVisitor.Tests;

/// <summary>
/// Pruebas de la clase SparrowView.
/// </summary>
[TestClass]
public class SparrowViewTests
{
    private StringWriter salida = null!;
    private SparrowView visor = null!;

    [TestInitialize]
    public void SetUp()
    {
        salida = new StringWriter();
        visor = new SparrowView(salida);
    }

    [TestMethod]
    public void MostrarSistemaSparrow_MuestraElFormatoExtendidoEntreAdornos()
    {
        Directorio dir = new Directorio("docs");
        dir.Anhadir(new Archivo("a.txt", 10));

        visor.MostrarSistemaSparrow(dir);

        string esperado = Lineas(
            "======= Sparrow Viewer =======",
            "",
            "d docs",
            "   f a.txt",
            "",
            "==============================");
        Assert.AreEqual(esperado, salida.ToString());
    }

    [TestMethod]
    public void MostrarSistemaSparrow_AceptaUnArchivoSuelto()
    {
        visor.MostrarSistemaSparrow(new Archivo("foto.jpg", 10));

        string esperado = Lineas(
            "======= Sparrow Viewer =======",
            "",
            "f foto.jpg",
            "",
            "==============================");
        Assert.AreEqual(esperado, salida.ToString());
    }

    [TestMethod]
    public void MostrarSistemaSparrow_SistemaDeEjemplo_IncluyeTodoElArbol()
    {
        Directorio raiz = CrearFigura1();

        visor.MostrarSistemaSparrow(raiz);

        string arbol = raiz.Aceptar(new VisitanteExtendido());
        StringAssert.Contains(salida.ToString(), arbol);
    }

    [TestMethod]
    public void Constructor_SalidaNula_LanzaExcepcion()
    {
        Assert.ThrowsExactly<ArgumentNullException>(() => new SparrowView(null!));
    }
}
