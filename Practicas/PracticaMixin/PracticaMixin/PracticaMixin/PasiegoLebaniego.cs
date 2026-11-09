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
    /// Región en la que se encuentra el pasiego lebaniego. Determina qué
    /// tipo de cocido elabora. Por defecto, se encuentra en Liébana.
    /// </summary>
    public TipoContexto Contexto { get; set; } = TipoContexto.Liebana;

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
    public string HacerOrujo()
    {
        return mixinLebaniego.HacerOrujo();
    }

    /// <summary>
    /// Elabora un cocido lebaniego o montañés según la región en la que
    /// se encuentre, resolviendo el conflicto entre los métodos HacerCocido
    /// heredados de IPasiego e ILebaniego.
    /// </summary>
    /// <returns>Cadena que describe la acción realizada.</returns>
    /// <exception cref="InvalidOperationException">
    /// Si el contexto no es un valor válido de <see cref="TipoContexto"/>.
    /// </exception>
    public string HacerCocido()
    {
        return Contexto switch
        {
            TipoContexto.Liebana => mixinLebaniego.HacerCocido(),
            TipoContexto.Pas => mixinPasiego.HacerCocido(),
            _ => throw new InvalidOperationException("Contexto desconocido: " + Contexto)
        };
    }
}
