namespace PracticaStrategy;

/// <summary>
/// Visitante concreto que imprime un sistema Sparrow en formato compacto:
/// un elemento por línea, solo su nombre, y el contenido de los directorios
/// tabulado debajo de ellos. El contenido de los archivos comprimidos no se
/// muestra.
/// </summary>
public class VisitanteCompacto : VisitanteImpresion
{
    /// <summary>
    /// Crea un visitante de formato compacto que adapta los textos con la
    /// estrategia de visualización indicada.
    /// </summary>
    /// <param name="estrategia">Estrategia con la que se adaptan los textos.</param>
    public VisitanteCompacto(IEstrategiaVisualizacion estrategia) : base(estrategia)
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
