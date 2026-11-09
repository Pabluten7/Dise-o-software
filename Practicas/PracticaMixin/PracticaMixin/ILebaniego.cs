namespace PracticaMixin;

/// <summary>
/// Define las habilidades que debe tener todo lebaniego.
/// </summary>
public interface ILebaniego
{
    /// <summary>Elabora un cocido.</summary>
    /// <returns>Cadena que describe la acción realizada.</returns>
    string HacerCocido();

    /// <summary>Elabora orujo.</summary>
    /// <returns>Cadena que describe la acción realizada.</returns>
    string HacerOrujo();
}