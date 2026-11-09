namespace PracticaMixin;

/// <summary>
/// Define las habilidades que debe tener todo pasiego.
/// </summary>
public interface IPasiego
{
    /// <summary>Elabora sobaos.</summary>
    /// <returns>Cadena que describe la acción realizada.</returns>
    string HacerSobaos();

    /// <summary>Elabora una quesada.</summary>
    /// <returns>Cadena que describe la acción realizada.</returns>
    string HacerQuesada();
}