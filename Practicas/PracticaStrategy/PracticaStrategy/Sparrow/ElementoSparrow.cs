namespace PracticaStrategy;

/// <summary>
/// Componente del patrón Composite: cualquier elemento del sistema de
/// archivos Sparrow (archivo, directorio, archivo comprimido o enlace).
/// Permite tratar de forma homogénea a todos los elementos, con
/// independencia de su tipo y de su profundidad.
/// </summary>
public abstract class ElementoSparrow
{
    /// <summary>
    /// Tamaño, en Kb, que consume la definición de directorios, archivos
    /// comprimidos y enlaces.
    /// </summary>
    protected const double TamanhoDefinicionKb = 1.0;

    /// <summary>Nombre del elemento.</summary>
    public abstract string Nombre { get; set; }

    /// <summary>Tamaño total, en Kb, que ocupa el elemento.</summary>
    public abstract double Tamanho { get; }

    /// <summary>Número total de archivos que contiene el elemento.</summary>
    public abstract int NumArchivos { get; }

    /// <summary>
    /// Indica si este elemento contiene, directa o indirectamente, al
    /// elemento indicado. Por defecto, un elemento no contiene a ningún otro.
    /// </summary>
    /// <param name="elemento">Elemento a buscar.</param>
    /// <returns>Verdadero si lo contiene; falso en caso contrario.</returns>
    public virtual bool Contiene(ElementoSparrow elemento)
    {
        return false;
    }

    /// <summary>
    /// Acepta un visitante, invocando el método Visitar que corresponde al
    /// tipo concreto de este elemento (doble despacho). Permite añadir nuevas
    /// operaciones sobre la jerarquía sin modificarla.
    /// </summary>
    /// <param name="visitante">Visitante que realiza la operación.</param>
    /// <returns>El resultado producido por el visitante.</returns>
    public abstract string Aceptar(IVisitanteSparrow visitante);
}
