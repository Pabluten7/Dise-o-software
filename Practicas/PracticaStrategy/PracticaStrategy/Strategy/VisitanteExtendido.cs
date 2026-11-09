namespace PracticaStrategy;

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

    /// <summary>
    /// Crea un visitante de formato extendido que adapta los textos con la
    /// estrategia de visualización indicada.
    /// </summary>
    /// <param name="estrategia">Estrategia con la que se adaptan los textos.</param>
    public VisitanteExtendido(IEstrategiaVisualizacion estrategia) : base(estrategia)
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
