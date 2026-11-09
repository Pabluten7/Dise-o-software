using System.Text;

namespace PracticaStrategy;

/// <summary>
/// Base de las estrategias internacionales: primero sustituye cada vocal con
/// tilde por su versión sin tilde y, a continuación, reemplaza la ñ
/// delegando en otra estrategia (gallega o catalana).
/// </summary>
public abstract class EstrategiaInternacional : IEstrategiaVisualizacion
{
    /// <summary>Correspondencia entre cada vocal con tilde y su versión sin tilde.</summary>
    private static readonly Dictionary<char, char> VocalesSinTilde = new Dictionary<char, char>
    {
        ['á'] = 'a', ['é'] = 'e', ['í'] = 'i', ['ó'] = 'o', ['ú'] = 'u',
        ['Á'] = 'A', ['É'] = 'E', ['Í'] = 'I', ['Ó'] = 'O', ['Ú'] = 'U'
    };

    /// <summary>Estrategia que se aplica para reemplazar la ñ.</summary>
    private readonly IEstrategiaVisualizacion estrategiaEnhe;

    /// <summary>
    /// Inicializa la estrategia internacional con la estrategia indicada
    /// para reemplazar la ñ.
    /// </summary>
    /// <param name="estrategiaEnhe">Estrategia que reemplaza la ñ.</param>
    /// <exception cref="ArgumentNullException">Si la estrategia es nula.</exception>
    protected EstrategiaInternacional(IEstrategiaVisualizacion estrategiaEnhe)
    {
        ArgumentNullException.ThrowIfNull(estrategiaEnhe);
        this.estrategiaEnhe = estrategiaEnhe;
    }

    /// <inheritdoc/>
    public string Adaptar(string texto)
    {
        return estrategiaEnhe.Adaptar(QuitarTildes(texto));
    }

    /// <summary>
    /// Sustituye cada vocal con tilde por su versión sin tilde.
    /// </summary>
    /// <param name="texto">Texto original.</param>
    /// <returns>El texto sin tildes.</returns>
    private static string QuitarTildes(string texto)
    {
        StringBuilder resultado = new StringBuilder(texto.Length);
        foreach (char caracter in texto)
        {
            resultado.Append(VocalesSinTilde.GetValueOrDefault(caracter, caracter));
        }
        return resultado.ToString();
    }
}
