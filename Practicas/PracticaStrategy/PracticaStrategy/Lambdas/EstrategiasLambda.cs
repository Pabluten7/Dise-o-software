using System.Text;

namespace PracticaStrategy;

/// <summary>
/// Estrategias de visualización del sistema Sparrow expresadas como
/// funciones lambda, en lugar de como clases que implementan una interfaz.
/// Cada estrategia es una función que recibe un texto y devuelve el texto
/// adaptado: Func&lt;string, string&gt;.
/// </summary>
public static class EstrategiasLambda
{
    /// <summary>Correspondencia entre cada vocal con tilde y su versión sin tilde.</summary>
    private static readonly Dictionary<char, char> VocalesSinTilde = new Dictionary<char, char>
    {
        ['á'] = 'a', ['é'] = 'e', ['í'] = 'i', ['ó'] = 'o', ['ú'] = 'u',
        ['Á'] = 'A', ['É'] = 'E', ['Í'] = 'I', ['Ó'] = 'O', ['Ú'] = 'U'
    };

    /// <summary>Muestra los textos tal cual.</summary>
    public static readonly Func<string, string> Castellano = texto => texto;

    /// <summary>Sustituye la ñ por nh.</summary>
    public static readonly Func<string, string> Gallega =
        texto => texto.Replace("ñ", "nh").Replace("Ñ", "Nh");

    /// <summary>Sustituye la ñ por ny.</summary>
    public static readonly Func<string, string> Catalana =
        texto => texto.Replace("ñ", "ny").Replace("Ñ", "Ny");

    /// <summary>Quita las tildes y sustituye la ñ por nh.</summary>
    public static readonly Func<string, string> InternacionalGallega =
        texto => Gallega(QuitarTildes(texto));

    /// <summary>Quita las tildes y sustituye la ñ por ny.</summary>
    public static readonly Func<string, string> InternacionalCatalana =
        texto => Catalana(QuitarTildes(texto));

    /// <summary>
    /// Sustituye cada vocal con tilde por su versión sin tilde.
    /// </summary>
    /// <param name="texto">Texto original.</param>
    /// <returns>El texto sin tildes.</returns>
    public static string QuitarTildes(string texto)
    {
        StringBuilder resultado = new StringBuilder(texto.Length);
        foreach (char caracter in texto)
        {
            resultado.Append(VocalesSinTilde.GetValueOrDefault(caracter, caracter));
        }
        return resultado.ToString();
    }
}
