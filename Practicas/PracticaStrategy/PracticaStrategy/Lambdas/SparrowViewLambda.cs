namespace PracticaStrategy;

/// <summary>
/// Versión con lambdas de <see cref="SparrowView"/>: muestra un sistema
/// Sparrow en formato extendido, adaptando los textos con una función.
/// </summary>
public class SparrowViewLambda
{
    private const string Cabecera = "======= Sparrow Viewer =======";
    private const string Pie = "==============================";

    private readonly Func<string, string> adaptar;
    private readonly TextWriter salida;

    /// <summary>
    /// Crea un visor que escribe en la consola.
    /// </summary>
    /// <param name="adaptar">Función que adapta cada texto al dispositivo.</param>
    public SparrowViewLambda(Func<string, string> adaptar) : this(adaptar, Console.Out)
    {
    }

    /// <summary>
    /// Crea un visor que escribe en la salida indicada.
    /// </summary>
    /// <param name="adaptar">Función que adapta cada texto al dispositivo.</param>
    /// <param name="salida">Salida en la que se escribe.</param>
    /// <exception cref="ArgumentNullException">Si algún parámetro es nulo.</exception>
    public SparrowViewLambda(Func<string, string> adaptar, TextWriter salida)
    {
        ArgumentNullException.ThrowIfNull(adaptar);
        ArgumentNullException.ThrowIfNull(salida);
        this.adaptar = adaptar;
        this.salida = salida;
    }

    /// <summary>
    /// Muestra cualquier elemento de un sistema Sparrow en formato extendido,
    /// entre dos líneas de adorno.
    /// </summary>
    /// <param name="elemento">Elemento a mostrar.</param>
    public void MostrarSistemaSparrow(ElementoSparrow elemento)
    {
        string sistema = elemento.Aceptar(new VisitanteExtendidoLambda(adaptar));

        salida.WriteLine(Cabecera);
        salida.WriteLine();
        salida.Write(sistema);
        salida.WriteLine();
        salida.WriteLine(Pie);
    }
}
