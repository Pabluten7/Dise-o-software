namespace PracticaMixin;

/// <summary>
/// Habitante de la Vega de Pas, experto en sobaos y quesadas.
/// </summary>
public class Pasiego : IPasiego
{
    /// <inheritdoc/>
    public string HacerSobaos()
    {
        return "Haciendo Sobaos.";
    }

    /// <inheritdoc/>
    public string HacerQuesada()
    {
        return "Haciendo Quesada.";
    }
}