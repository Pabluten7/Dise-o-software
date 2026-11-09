using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaComposite.Tests;

/// <summary>
/// Pruebas sobre el sistema de archivos completo de la Figura 1 del
/// enunciado: profundidad no acotada, elementos de distinto tipo en cada
/// nivel, enlaces, y tratamiento homogéneo de todos los elementos.
/// </summary>
[TestClass]
public class Figura1Tests
{
    private const double Delta = 0.0001;

    private Directorio raiz = null!;
    private Directorio dirVacio = null!;
    private Directorio dirArchivoUnico = null!;
    private Directorio dirComprimidoSimple = null!;
    private Directorio dirAnidado = null!;
    private Directorio dirComprimidoComplejo = null!;
    private Archivo foto001 = null!;
    private ArchivoComprimido ccSimple = null!;
    private ArchivoComprimido ccComplejo = null!;
    private ArchivoComprimido ccAnidada = null!;

    /// <summary>
    /// Construye el sistema de la Figura 1. Los tamaños de las fotos
    /// (no indicados en el enunciado) son: fotoN = N * 100 Kb.
    /// </summary>
    [TestInitialize]
    public void SetUp()
    {
        raiz = new Directorio("Raiz");
        dirVacio = new Directorio("Directorio Vacio");
        dirArchivoUnico = new Directorio("Directorio Con Archivo Unico");
        dirComprimidoSimple = new Directorio("Directorio Con Archivo Comprimido Simple");
        dirAnidado = new Directorio("Directorio con Directorio Anidado");
        raiz.Anhadir(dirVacio);
        raiz.Anhadir(dirArchivoUnico);
        raiz.Anhadir(dirComprimidoSimple);
        raiz.Anhadir(dirAnidado);

        foto001 = new Archivo("foto001.jpg", 100);
        dirArchivoUnico.Anhadir(foto001);

        ccSimple = new ArchivoComprimido("ccSimple.zip");
        dirComprimidoSimple.Anhadir(new Archivo("foto002.jpg", 200));
        dirComprimidoSimple.Anhadir(new Enlace(foto001));
        dirComprimidoSimple.Anhadir(ccSimple);
        ccSimple.Anhadir(new Directorio("Directorio Vacio En Archivo Comprimido"));
        ccSimple.Anhadir(new Archivo("foto003.jpg", 300));
        ccSimple.Anhadir(new Enlace(foto001));

        dirComprimidoComplejo = new Directorio("Directorio con Archivo Comprimido Complejo");
        dirAnidado.Anhadir(new Archivo("foto004.jpg", 400));
        dirAnidado.Anhadir(new Enlace(ccSimple));
        dirAnidado.Anhadir(new Enlace(dirVacio));
        dirAnidado.Anhadir(dirComprimidoComplejo);

        ccComplejo = new ArchivoComprimido("ccComplejo.zip");
        ccAnidada = new ArchivoComprimido("ccAnidada.zip");
        dirComprimidoComplejo.Anhadir(new Archivo("foto005", 500));
        dirComprimidoComplejo.Anhadir(new Archivo("foto006", 600));
        dirComprimidoComplejo.Anhadir(ccComplejo);
        ccComplejo.Anhadir(ccAnidada);
        ccComplejo.Anhadir(new Archivo("foto008.jpg", 800));
        ccAnidada.Anhadir(new Archivo("foto007.jpg", 700));
    }

    // ---------------- Número de archivos ----------------

    [TestMethod]
    public void NumArchivos_DeCadaElemento_EsCorrecto()
    {
        Assert.AreEqual(0, dirVacio.NumArchivos);
        Assert.AreEqual(1, dirArchivoUnico.NumArchivos);
        Assert.AreEqual(1, ccSimple.NumArchivos);
        Assert.AreEqual(2, dirComprimidoSimple.NumArchivos);   // foto002 + ccSimple
        Assert.AreEqual(1, ccAnidada.NumArchivos);
        Assert.AreEqual(1, ccComplejo.NumArchivos);
        Assert.AreEqual(3, dirComprimidoComplejo.NumArchivos); // foto005 + foto006 + ccComplejo
        Assert.AreEqual(4, dirAnidado.NumArchivos);            // foto004 + 3
    }

    [TestMethod]
    public void NumArchivos_Raiz_EsSiete()
    {
        // 0 + 1 + 2 + 4
        Assert.AreEqual(7, raiz.NumArchivos);
    }

    // ---------------- Tamaño ----------------

    [TestMethod]
    public void Tamanho_DeCadaElemento_EsCorrecto()
    {
        Assert.AreEqual(1, dirVacio.Tamanho, Delta);
        Assert.AreEqual(101, dirArchivoUnico.Tamanho, Delta);          // 1 + 100
        Assert.AreEqual(91.6, ccSimple.Tamanho, Delta);                // 0.3 * (1 + 300 + 1) + 1
        Assert.AreEqual(293.6, dirComprimidoSimple.Tamanho, Delta);    // 1 + 200 + 1 + 91.6
        Assert.AreEqual(211, ccAnidada.Tamanho, Delta);                // 0.3 * 700 + 1
        Assert.AreEqual(304.3, ccComplejo.Tamanho, Delta);             // 0.3 * (211 + 800) + 1
        Assert.AreEqual(1405.3, dirComprimidoComplejo.Tamanho, Delta); // 1 + 500 + 600 + 304.3
        Assert.AreEqual(1808.3, dirAnidado.Tamanho, Delta);            // 1 + 400 + 1 + 1 + 1405.3
    }

    [TestMethod]
    public void Tamanho_Raiz_EsLaSumaDeTodo()
    {
        // 1 + 1 + 101 + 293.6 + 1808.3
        Assert.AreEqual(2204.9, raiz.Tamanho, Delta);
    }

    // ---------------- Enlaces dentro del sistema ----------------

    [TestMethod]
    public void RenombrarDesdeUnEnlace_SeVeEnTodoElSistema()
    {
        // El enlace se renombra como cualquier otro elemento, sin castings
        ElementoSparrow enlaceFoto = dirComprimidoSimple.Elementos[1];
        enlaceFoto.Nombre = "foto001_renombrada.jpg";
        Assert.AreEqual("foto001_renombrada.jpg", foto001.Nombre);
        Assert.AreEqual("foto001_renombrada.jpg", ccSimple.Elementos[2].Nombre);
    }

    [TestMethod]
    public void CambiarElContenidoDelDestino_NoCambiaElTamanhoDelEnlace()
    {
        double tamanhoAntes = dirAnidado.Tamanho;
        dirVacio.Anhadir(new Archivo("nuevo.txt", 50));
        // dirAnidado solo tiene un enlace a dirVacio: su tamaño no cambia
        Assert.AreEqual(tamanhoAntes, dirAnidado.Tamanho, Delta);
        // pero la raíz sí contiene a dirVacio de verdad
        Assert.AreEqual(2254.9, raiz.Tamanho, Delta);
        Assert.AreEqual(8, raiz.NumArchivos);
    }

    // ---------------- Profundidad y homogeneidad ----------------

    [TestMethod]
    public void Raiz_ContieneElementosDelNivelMasProfundo()
    {
        Assert.IsTrue(raiz.Contiene(ccAnidada));
        Assert.IsTrue(raiz.Contiene(ccAnidada.Elementos[0]));   // foto007, nivel 6
    }

    [TestMethod]
    public void TodosLosElementos_SeTratanDeFormaHomogenea()
    {
        // Elementos de tipos distintos tratados todos como ElementoSparrow
        ElementoSparrow[] elementos =
        {
            raiz, foto001, ccSimple, new Enlace(ccComplejo)
        };
        double[] tamanhosEsperados = { 2204.9, 100, 91.6, 1 };
        int[] archivosEsperados = { 7, 1, 1, 0 };

        for (int i = 0; i < elementos.Length; i++)
        {
            Assert.AreEqual(tamanhosEsperados[i], elementos[i].Tamanho, Delta);
            Assert.AreEqual(archivosEsperados[i], elementos[i].NumArchivos);
            Assert.IsFalse(string.IsNullOrEmpty(elementos[i].Nombre));
        }
    }
}
