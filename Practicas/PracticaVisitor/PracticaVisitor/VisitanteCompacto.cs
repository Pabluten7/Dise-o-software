namespace PracticaVisitor;

/// <summary>
/// Visitante concreto que imprime un sistema Sparrow en formato compacto:
/// un elemento por línea, solo su nombre, y el contenido de los directorios
/// tabulado debajo de ellos. El contenido de los archivos comprimidos no se
/// muestra.
/// </summary>
public class VisitanteCompacto : VisitanteImpresion
{
    /// <inheritdoc/>
    public override string Visitar(Archivo archivo)
    {
        return Linea(archivo.Nombre);
    }

    /// <inheritdoc/>
    public override string Visitar(Directorio directorio)
    {
        string cabecera = Linea(directorio.Nombre);
        return cabecera + Contenido(directorio);
    }

    /// <inheritdoc/>
    public override string Visitar(ArchivoComprimido comprimido)
    {
        return Linea(comprimido.Nombre);
    }

    /// <inheritdoc/>
    public override string Visitar(Enlace enlace)
    {
        return Linea(enlace.Nombre);
    }
}
