namespace PracticaStrategy;

/// <summary>
/// Estrategia gallega: sustituye la ñ por nh (y la Ñ por Nh). Las vocales
/// con tilde se mantienen sin modificar.
/// </summary>
public class EstrategiaGallega : IEstrategiaVisualizacion
{
    /// <inheritdoc/>
    public string Adaptar(string texto)
    {
        return texto.Replace("ñ", "nh").Replace("Ñ", "Nh");
    }
}
