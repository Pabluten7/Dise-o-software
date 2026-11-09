namespace PracticaMixin;

/// <summary>
/// Superraza que combina las habilidades de pasiegos y lebaniegos.
/// Aplica el patrón mixin: hereda el tipo de las interfaces IPasiego e
/// ILebaniego y reutiliza el comportamiento por composición y delegación.
/// </summary>
public class PasiegoLebaniego : IPasiego, ILebaniego
{
    // Mixins: objetos en los que se delega el comportamiento heredado
    private readonly IPasiego mixinPasiego;
    private readonly ILebaniego mixinLebaniego;

    /// <summary>
    /// Crea un pasiego lebaniego con las habilidades de ambas razas.
    /// </summary>
    public PasiegoLebaniego()
    {
        mixinPasiego = new Pasiego();
        mixinLebaniego = new Lebaniego();
    }

    /// <inheritdoc/>
    public string HacerSobaos()
    {
        return mixinPasiego.HacerSobaos();
    }

    /// <inheritdoc/>
    public string HacerQuesada()
    {
        return mixinPasiego.HacerQuesada();
    }

    /// <inheritdoc/>
    public string HacerCocido()
    {
        return mixinLebaniego.HacerCocido();
    }

    /// <inheritdoc/>
    public string HacerOrujo()
    {
        return mixinLebaniego.HacerOrujo();
    }
}