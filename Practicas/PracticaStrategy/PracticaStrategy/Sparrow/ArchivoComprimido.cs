namespace PracticaStrategy;

/// <summary>
/// Archivo comprimido del sistema Sparrow. Almacena elementos en su interior
/// de forma comprimida.
/// </summary>
public class ArchivoComprimido : ElementoCompuesto
{
    /// <summary>
    /// Proporción del tamaño original que ocupa el contenido comprimido.
    /// </summary>
    private const double FactorCompresion = 0.3;

    /// <summary>
    /// Crea un archivo comprimido vacío con el nombre indicado.
    /// </summary>
    /// <param name="nombre">Nombre del archivo comprimido.</param>
    public ArchivoComprimido(string nombre) : base(nombre)
    {
    }

    /// <summary>
    /// 30% del tamaño total de los elementos que contiene, más 1 Kb por la
    /// definición del propio archivo.
    /// </summary>
    public override double Tamanho
    {
        get { return FactorCompresion * TamanhoContenido() + TamanhoDefinicionKb; }
    }

    /// <summary>
    /// Un archivo comprimido cuenta como un único archivo, con independencia
    /// de los elementos que contenga.
    /// </summary>
    public override int NumArchivos
    {
        get { return 1; }
    }

    /// <inheritdoc/>
    public override string Aceptar(IVisitanteSparrow visitante)
    {
        return visitante.Visitar(this);
    }
}
