namespace PracticaComposite;

/// <summary>
/// Hoja del patrón Composite: archivo simple (documento, fotografía...)
/// con un nombre y un tamaño en Kb.
/// </summary>
public class Archivo : ElementoEnlazable
{
    private readonly double tamanho;

    /// <summary>
    /// Crea un archivo con el nombre y tamaño indicados.
    /// </summary>
    /// <param name="nombre">Nombre del archivo.</param>
    /// <param name="tamanho">Tamaño del archivo en Kb. No puede ser negativo.</param>
    /// <exception cref="ArgumentException">Si el nombre está vacío.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Si el tamaño es negativo.</exception>
    public Archivo(string nombre, double tamanho) : base(nombre)
    {
        if (tamanho < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(tamanho), "El tamaño no puede ser negativo.");
        }
        this.tamanho = tamanho;
    }

    /// <inheritdoc/>
    public override double Tamanho
    {
        get { return tamanho; }
    }

    /// <summary>Un archivo cuenta siempre como un único archivo.</summary>
    public override int NumArchivos
    {
        get { return 1; }
    }
}
