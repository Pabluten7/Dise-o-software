namespace PracticaMixin;

/// <summary>
/// Habitante de Liébana, experto en cocido lebaniego y orujo.
/// </summary>
public class Lebaniego : ILebaniego
{
    /// <inheritdoc/>
    public string HacerCocido()
    {
        return "Haciendo Cocido Lebaniego.";
    }

    /// <inheritdoc/>
    public string HacerOrujo()
    {
        return "Haciendo Orujo.";
    }
}