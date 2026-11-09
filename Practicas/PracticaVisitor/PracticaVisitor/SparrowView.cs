namespace PracticaVisitor;

/// <summary>
/// Especie de cuadro de texto que muestra un sistema de archivos Sparrow en
/// formato extendido, entre dos líneas de adorno.
/// </summary>
public class SparrowView
{
    private const string Cabecera = "======= Sparrow Viewer =======";
    private const string Pie = "==============================";

    private readonly TextWriter salida;

    /// <summary>
    /// Crea un visor que escribe en la consola.
    /// </summary>
    public SparrowView() : this(Console.Out)
    {
    }

    /// <summary>
    /// Crea un visor que escribe en la salida indicada (consola, fichero,
    /// cadena de texto...).
    /// </summary>
    /// <param name="salida">Salida en la que se escribe.</param>
    /// <exception cref="ArgumentNullException">Si la salida es nula.</exception>
    public SparrowView(TextWriter salida)
    {
        ArgumentNullException.ThrowIfNull(salida);
        this.salida = salida;
    }

    /// <summary>
    /// Muestra cualquier elemento de un sistema Sparrow en formato extendido,
    /// entre dos líneas de adorno.
    /// </summary>
    /// <param name="elemento">Elemento a mostrar.</param>
    public void MostrarSistemaSparrow(ElementoSparrow elemento)
    {
        string sistema = elemento.Aceptar(new VisitanteExtendido());

        salida.WriteLine(Cabecera);
        salida.WriteLine();
        salida.Write(sistema);
        salida.WriteLine();
        salida.WriteLine(Pie);
    }
}
