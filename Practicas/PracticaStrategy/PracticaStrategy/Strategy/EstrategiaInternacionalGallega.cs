namespace PracticaStrategy;

/// <summary>
/// Estrategia internacional gallega: quita las tildes y sustituye la ñ por nh.
/// </summary>
public class EstrategiaInternacionalGallega : EstrategiaInternacional
{
    /// <summary>
    /// Crea la estrategia internacional gallega.
    /// </summary>
    public EstrategiaInternacionalGallega() : base(new EstrategiaGallega())
    {
    }
}
