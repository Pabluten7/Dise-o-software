namespace PracticaComposite;

/// <summary>
/// Elemento del sistema Sparrow que puede ser destino de un enlace directo.
/// Todos los elementos son enlazables salvo los propios enlaces, lo que
/// garantiza en tiempo de compilación que no se puedan crear enlaces a enlaces.
/// También gestiona el nombre propio del elemento.
/// </summary>
public abstract class ElementoEnlazable : ElementoSparrow
{
    private string nombre;

    /// <summary>
    /// Inicializa el elemento con el nombre indicado.
    /// </summary>
    /// <param name="nombre">Nombre del elemento. No puede estar vacío.</param>
    /// <exception cref="ArgumentException">Si el nombre está vacío.</exception>
    protected ElementoEnlazable(string nombre)
    {
        this.nombre = ValidarNombre(nombre);
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">Si el nuevo nombre está vacío.</exception>
    public override string Nombre
    {
        get { return nombre; }
        set { nombre = ValidarNombre(value); }
    }

    /// <summary>
    /// Comprueba que un nombre es válido.
    /// </summary>
    /// <param name="nombre">Nombre a comprobar.</param>
    /// <returns>El propio nombre, si es válido.</returns>
    /// <exception cref="ArgumentException">Si el nombre está vacío.</exception>
    private static string ValidarNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre))
        {
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(nombre));
        }
        return nombre;
    }
}
