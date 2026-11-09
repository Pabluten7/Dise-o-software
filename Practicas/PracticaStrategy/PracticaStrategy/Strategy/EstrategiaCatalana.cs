namespace PracticaStrategy;

/// <summary>
/// Estrategia catalana: sustituye la ñ por ny (y la Ñ por Ny). Las vocales
/// con tilde se mantienen sin modificar.
/// </summary>
public class EstrategiaCatalana : IEstrategiaVisualizacion
{
    /// <inheritdoc/>
    public string Adaptar(string texto)
    {
        return texto.Replace("ñ", "ny").Replace("Ñ", "Ny");
    }
}
