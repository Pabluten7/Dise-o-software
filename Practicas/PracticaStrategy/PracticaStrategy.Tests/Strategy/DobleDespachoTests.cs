using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PracticaStrategy.Tests;

/// <summary>
/// Pruebas del mecanismo de doble despacho (métodos Aceptar). Usan un
/// visitante creado solo para las pruebas, lo que demuestra además que se
/// pueden añadir nuevos visitantes sin modificar la jerarquía.
/// </summary>
[TestClass]
public class DobleDespachoTests
{
    /// <summary>
    /// Visitante de prueba que devuelve el nombre del método Visitar invocado.
    /// </summary>
    private sealed class VisitanteTipo : IVisitanteSparrow
    {
        public string Visitar(Archivo archivo) { return "Archivo"; }
        public string Visitar(Directorio directorio) { return "Directorio"; }
        public string Visitar(ArchivoComprimido comprimido) { return "ArchivoComprimido"; }
        public string Visitar(Enlace enlace) { return "Enlace"; }
    }

    [TestMethod]
    public void Aceptar_SobreVariablesDelTipoBase_InvocaElVisitarDeCadaTipoReal()
    {
        Archivo archivo = new Archivo("a.txt", 10);
        ElementoSparrow[] elementos =
        {
            archivo,
            new Directorio("dir"),
            new ArchivoComprimido("z.zip"),
            new Enlace(archivo)
        };
        string[] esperados = { "Archivo", "Directorio", "ArchivoComprimido", "Enlace" };
        IVisitanteSparrow visitante = new VisitanteTipo();

        for (int i = 0; i < elementos.Length; i++)
        {
            Assert.AreEqual(esperados[i], elementos[i].Aceptar(visitante));
        }
    }
}
