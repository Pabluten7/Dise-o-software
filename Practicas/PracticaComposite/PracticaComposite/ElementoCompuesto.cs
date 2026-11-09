namespace PracticaComposite;

/// <summary>
/// Compuesto del patrón Composite: elemento que contiene a otros elementos
/// del sistema Sparrow (directorios y archivos comprimidos). Gestiona la
/// lista de hijos y ofrece a sus subclases los cálculos sobre su contenido.
/// </summary>
public abstract class ElementoCompuesto : ElementoEnlazable
{
    private readonly List<ElementoSparrow> elementos = new List<ElementoSparrow>();

    /// <summary>
    /// Inicializa un elemento compuesto vacío con el nombre indicado.
    /// </summary>
    /// <param name="nombre">Nombre del elemento.</param>
    protected ElementoCompuesto(string nombre) : base(nombre)
    {
    }

    /// <summary>Elementos contenidos directamente (solo lectura).</summary>
    public IReadOnlyList<ElementoSparrow> Elementos
    {
        get { return elementos.AsReadOnly(); }
    }

    /// <summary>
    /// Añade un elemento al contenido.
    /// </summary>
    /// <param name="elemento">Elemento a añadir.</param>
    /// <exception cref="ArgumentNullException">Si el elemento es nulo.</exception>
    /// <exception cref="ArgumentException">
    /// Si el elemento ya está contenido directamente, o si añadirlo
    /// crearía un ciclo (un elemento dentro de sí mismo).
    /// </exception>
    public void Anhadir(ElementoSparrow elemento)
    {
        ArgumentNullException.ThrowIfNull(elemento);

        if (elementos.Contains(elemento))
        {
            throw new ArgumentException("El elemento ya está contenido.", nameof(elemento));
        }
        if (elemento == this || elemento.Contiene(this))
        {
            throw new ArgumentException("Un elemento no puede contenerse a sí mismo.", nameof(elemento));
        }
        elementos.Add(elemento);
    }

    /// <summary>
    /// Elimina un elemento del contenido.
    /// </summary>
    /// <param name="elemento">Elemento a eliminar.</param>
    /// <returns>Verdadero si se eliminó; falso si no estaba contenido.</returns>
    public bool Eliminar(ElementoSparrow elemento)
    {
        return elementos.Remove(elemento);
    }

    /// <inheritdoc/>
    public override bool Contiene(ElementoSparrow elemento)
    {
        foreach (ElementoSparrow hijo in elementos)
        {
            if (hijo == elemento || hijo.Contiene(elemento))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Suma del tamaño de todos los elementos contenidos.
    /// </summary>
    /// <returns>Tamaño total del contenido, en Kb.</returns>
    protected double TamanhoContenido()
    {
        double total = 0.0;
        foreach (ElementoSparrow hijo in elementos)
        {
            total += hijo.Tamanho;
        }
        return total;
    }

    /// <summary>
    /// Suma del número de archivos de todos los elementos contenidos.
    /// </summary>
    /// <returns>Número total de archivos del contenido.</returns>
    protected int NumArchivosContenido()
    {
        int total = 0;
        foreach (ElementoSparrow hijo in elementos)
        {
            total += hijo.NumArchivos;
        }
        return total;
    }
}
