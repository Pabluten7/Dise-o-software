namespace PracticaStrategy;

/// <summary>
/// Visitante de formato compacto en su versión con lambdas.
/// </summary>
public class VisitanteCompactoLambda : VisitanteImpresionLambda
{
    /// <summary>
    /// Crea un visitante de formato compacto que adapta los textos con la
    /// función indicada.
    /// </summary>
    /// <param name="adaptar">Función que adapta cada texto al dispositivo.</param>
    public VisitanteCompactoLambda(Func<string, string> adaptar) : base(adaptar)
    {
    }

    /// <inheritdoc/>
    public override string Visitar(Archivo archivo)
    {
        return Linea(Nombre(archivo));
    }

    /// <inheritdoc/>
    public override string Visitar(Directorio directorio)
    {
        string cabecera = Linea(Nombre(directorio));
        return cabecera + Contenido(directorio);
    }

    /// <inheritdoc/>
    public override string Visitar(ArchivoComprimido comprimido)
    {
        return Linea(Nombre(comprimido));
    }

    /// <inheritdoc/>
    public override string Visitar(Enlace enlace)
    {
        return Linea(Nombre(enlace));
    }
}
