namespace PracticaStrategy;

/// <summary>
/// Especie de cuadro de texto que muestra un sistema de archivos Sparrow en
/// formato extendido, entre dos líneas de adorno, adaptando los caracteres
/// con la estrategia de visualización que se le indique.
/// </summary>
public class SparrowView
{
    private const string Cabecera = "======= Sparrow Viewer =======";
    private const string Pie = "==============================";

    private readonly IEstrategiaVisualizacion estrategia;
    private readonly TextWriter salida;

    /// <summary>
    /// Crea un visor que escribe en la consola.
    /// </summary>
    /// <param name="estrategia">Estrategia con la que se adaptan los textos.</param>
    public SparrowView(IEstrategiaVisualizacion estrategia) : this(estrategia, Console.Out)
    {
    }

    /// <summary>
    /// Crea un visor que escribe en la salida indicada (consola, fichero,
    /// cadena de texto...).
    /// </summary>
    /// <param name="estrategia">Estrategia con la que se adaptan los textos.</param>
    /// <param name="salida">Salida en la que se escribe.</param>
    /// <exception cref="ArgumentNullException">Si algún parámetro es nulo.</exception>
    public SparrowView(IEstrategiaVisualizacion estrategia, TextWriter salida)
    {
        ArgumentNullException.ThrowIfNull(estrategia);
        ArgumentNullException.ThrowIfNull(salida);
        this.estrategia = estrategia;
        this.salida = salida;
    }

    /// <summary>
    /// Muestra cualquier elemento de un sistema Sparrow en formato extendido,
    /// entre dos líneas de adorno.
    /// </summary>
    /// <param name="elemento">Elemento a mostrar.</param>
    public void MostrarSistemaSparrow(ElementoSparrow elemento)
    {
        string sistema = elemento.Aceptar(new VisitanteExtendido(estrategia));

        salida.WriteLine(Cabecera);
        salida.WriteLine();
        salida.Write(sistema);
        salida.WriteLine();
        salida.WriteLine(Pie);
    }
}
