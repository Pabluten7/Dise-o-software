namespace PracticaStrategy;

/// <summary>
/// Visitante de formato extendido en su versión con lambdas.
/// </summary>
public class VisitanteExtendidoLambda : VisitanteImpresionLambda
{
    private const string PrefijoDirectorio = "d ";
    private const string PrefijoEnlace = "e ";
    private const string PrefijoComprimido = "c ";
    private const string PrefijoArchivo = "f ";

    /// <summary>
    /// Crea un visitante de formato extendido que adapta los textos con la
    /// función indicada.
    /// </summary>
    /// <param name="adaptar">Función que adapta cada texto al dispositivo.</param>
    public VisitanteExtendidoLambda(Func<string, string> adaptar) : base(adaptar)
    {
    }

    /// <inheritdoc/>
    public override string Visitar(Archivo archivo)
    {
        return Linea(PrefijoArchivo + Nombre(archivo));
    }

    /// <inheritdoc/>
    public override string Visitar(Directorio directorio)
    {
        string cabecera = Linea(PrefijoDirectorio + Nombre(directorio));
        return cabecera + Contenido(directorio);
    }

    /// <inheritdoc/>
    public override string Visitar(ArchivoComprimido comprimido)
    {
        string cabecera = Linea(PrefijoComprimido + Nombre(comprimido));
        return cabecera + Contenido(comprimido);
    }

    /// <inheritdoc/>
    public override string Visitar(Enlace enlace)
    {
        return Linea(PrefijoEnlace + Nombre(enlace));
    }
}
