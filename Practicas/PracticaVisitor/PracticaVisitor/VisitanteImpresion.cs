using System.Text;

namespace PracticaVisitor;

/// <summary>
/// Base común de los visitantes que imprimen un sistema Sparrow en forma
/// arbórea. Gestiona la tabulación de los elementos anidados y el recorrido
/// del contenido de los elementos compuestos, que es igual para todos los
/// formatos. Cada formato concreto decide qué se escribe en cada línea y de
/// qué elementos se muestra el contenido.
/// </summary>
public abstract class VisitanteImpresion : IVisitanteSparrow
{
    /// <summary>Número de espacios que se tabula cada nivel de anidamiento.</summary>
    private const int EspaciosPorNivel = 3;

    /// <summary>Nivel de anidamiento del elemento que se está visitando.</summary>
    private int nivel = 0;

    /// <inheritdoc/>
    public abstract string Visitar(Archivo archivo);

    /// <inheritdoc/>
    public abstract string Visitar(Directorio directorio);

    /// <inheritdoc/>
    public abstract string Visitar(ArchivoComprimido comprimido);

    /// <inheritdoc/>
    public abstract string Visitar(Enlace enlace);

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
    /// elemento compuesto. Cada elemento se imprime aceptando a este mismo
    /// visitante, de modo que se invoca el Visitar correspondiente a su tipo.
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
