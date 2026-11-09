namespace PracticaMixin;

/// <summary>
/// Habitante de la Vega de Pas, experto en sobaos, quesadas y cocido montañés.
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

    /// <inheritdoc/>
    public string HacerCocido()
    {
        return "Haciendo Cocido Montañés.";
    }
}
