namespace PracticaStrategy;

/// <summary>
/// Estrategia para dispositivos que admiten todos los caracteres del
/// castellano: muestra los textos tal cual, sin modificarlos.
/// </summary>
public class EstrategiaCastellano : IEstrategiaVisualizacion
{
    /// <inheritdoc/>
    public string Adaptar(string texto)
    {
        return texto;
    }
}
