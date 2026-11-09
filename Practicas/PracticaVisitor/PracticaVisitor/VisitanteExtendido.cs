namespace PracticaVisitor;

/// <summary>
/// Visitante concreto que imprime un sistema Sparrow en formato extendido:
/// un elemento por línea, precedido de una letra que indica su tipo, y el
/// contenido de directorios y archivos comprimidos tabulado debajo de ellos.
/// </summary>
public class VisitanteExtendido : VisitanteImpresion
{
    private const string PrefijoDirectorio = "d ";
    private const string PrefijoEnlace = "e ";
    private const string PrefijoComprimido = "c ";
    private const string PrefijoArchivo = "f ";

    /// <inheritdoc/>
    public override string Visitar(Archivo archivo)
    {
        return Linea(PrefijoArchivo + archivo.Nombre);
    }

    /// <inheritdoc/>
    public override string Visitar(Directorio directorio)
    {
        string cabecera = Linea(PrefijoDirectorio + directorio.Nombre);
        return cabecera + Contenido(directorio);
    }

    /// <inheritdoc/>
    public override string Visitar(ArchivoComprimido comprimido)
    {
        string cabecera = Linea(PrefijoComprimido + comprimido.Nombre);
        return cabecera + Contenido(comprimido);
    }

    /// <inheritdoc/>
    public override string Visitar(Enlace enlace)
    {
        return Linea(PrefijoEnlace + enlace.Nombre);
    }
}
