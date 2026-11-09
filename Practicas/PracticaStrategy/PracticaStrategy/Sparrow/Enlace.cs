namespace PracticaStrategy;

/// <summary>
/// Enlace directo del sistema Sparrow. Dirige a un elemento destino, que
/// puede ser cualquier elemento salvo otro enlace. Al recibir un
/// <see cref="ElementoEnlazable"/>, el compilador impide crear enlaces a
/// enlaces sin necesidad de castings ni comprobaciones de tipo.
/// </summary>
public class Enlace : ElementoSparrow
{
    private readonly ElementoEnlazable destino;

    /// <summary>
    /// Crea un enlace directo al elemento indicado.
    /// </summary>
    /// <param name="destino">Elemento al que dirige el enlace.</param>
    /// <exception cref="ArgumentNullException">Si el destino es nulo.</exception>
    public Enlace(ElementoEnlazable destino)
    {
        ArgumentNullException.ThrowIfNull(destino);
        this.destino = destino;
    }

    /// <summary>Elemento al que dirige el enlace.</summary>
    public ElementoEnlazable Destino
    {
        get { return destino; }
    }

    /// <summary>
    /// Un enlace no tiene nombre propio: usa el de su destino. Renombrar el
    /// enlace renombra también su destino.
    /// </summary>
    public override string Nombre
    {
        get { return destino.Nombre; }
        set { destino.Nombre = value; }
    }

    /// <summary>Un enlace ocupa siempre 1 Kb.</summary>
    public override double Tamanho
    {
        get { return TamanhoDefinicionKb; }
    }

    /// <summary>Los enlaces no cuentan como archivos.</summary>
    public override int NumArchivos
    {
        get { return 0; }
    }

    /// <inheritdoc/>
    public override string Aceptar(IVisitanteSparrow visitante)
    {
        return visitante.Visitar(this);
    }
}
