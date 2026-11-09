namespace PracticaStrategy;

/// <summary>
/// Estrategia internacional catalana: quita las tildes y sustituye la ñ por ny.
/// </summary>
public class EstrategiaInternacionalCatalana : EstrategiaInternacional
{
    /// <summary>
    /// Crea la estrategia internacional catalana.
    /// </summary>
    public EstrategiaInternacionalCatalana() : base(new EstrategiaCatalana())
    {
    }
}
