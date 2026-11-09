using System.Text;

namespace PracticaStrategy;

/// <summary>
/// Base común de los visitantes de impresión en su versión con lambdas.
/// Es igual que <see cref="VisitanteImpresion"/>, pero la forma de adaptar
/// los textos se recibe como una función (Func&lt;string, string&gt;) en
/// lugar de como un objeto que implementa una interfaz.
/// </summary>
public abstract class VisitanteImpresionLambda : IVisitanteSparrow
{
    /// <summary>Número de espacios que se tabula cada nivel de anidamiento.</summary>
    private const int EspaciosPorNivel = 3;

    /// <summary>Nivel de anidamiento del elemento que se está visitando.</summary>
    private int nivel = 0;

    /// <summary>Función con la que se adaptan los textos al dispositivo.</summary>
    private readonly Func<string, string> adaptar;

    /// <summary>
    /// Inicializa el visitante con la función de adaptación indicada.
    /// </summary>
    /// <param name="adaptar">Función que adapta cada texto al dispositivo.</param>
    /// <exception cref="ArgumentNullException">Si la función es nula.</exception>
    protected VisitanteImpresionLambda(Func<string, string> adaptar)
    {
        ArgumentNullException.ThrowIfNull(adaptar);
        this.adaptar = adaptar;
    }

    /// <inheritdoc/>
    public abstract string Visitar(Archivo archivo);

    /// <inheritdoc/>
    public abstract string Visitar(Directorio directorio);

    /// <inheritdoc/>
    public abstract string Visitar(ArchivoComprimido comprimido);

    /// <inheritdoc/>
    public abstract string Visitar(Enlace enlace);

    /// <summary>
    /// Devuelve el nombre de un elemento adaptado al dispositivo de salida
    /// mediante la función de adaptación.
    /// </summary>
    /// <param name="elemento">Elemento cuyo nombre se quiere mostrar.</param>
    /// <returns>El nombre adaptado.</returns>
    protected string Nombre(ElementoSparrow elemento)
    {
        return adaptar(elemento.Nombre);
    }

    /// <summary>
    /// Construye una línea con el texto indicado, tabulada según el nivel de
    /// anidamiento actual.
    /// </summary>
    /// <param name="texto">Texto de la línea.</param>
    /// <returns>La línea tabulada, terminada en salto de línea.</returns>
    protected string Linea(string texto)
    {
        return new string(' ', nivel * EspaciosPorNivel) + texto + Environment.NewLine;
    }

    /// <summary>
    /// Imprime, un nivel más tabulados, todos los elementos contenidos en un
    /// elemento compuesto, haciendo que cada uno acepte a este visitante.
    /// </summary>
    /// <param name="compuesto">Elemento cuyo contenido se imprime.</param>
    /// <returns>El contenido impreso, una línea por elemento.</returns>
    protected string Contenido(ElementoCompuesto compuesto)
    {
        StringBuilder resultado = new StringBuilder();
        nivel++;
        try
        {
            foreach (ElementoSparrow elemento in compuesto.Elementos)
            {
                resultado.Append(elemento.Aceptar(this));
            }
        }
        finally
        {
            nivel--;
        }
        return resultado.ToString();
    }
}
