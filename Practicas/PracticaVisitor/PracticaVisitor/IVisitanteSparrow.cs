namespace PracticaVisitor;

/// <summary>
/// Visitante abstracto del patrón Visitor para la jerarquía Sparrow.
/// Declara un método Visitar por cada tipo concreto de elemento. Cada
/// visitante concreto implementa una nueva operación sobre la jerarquía
/// (una variante) sin necesidad de modificar las clases de la jerarquía.
/// </summary>
public interface IVisitanteSparrow
{
    /// <summary>Visita un archivo.</summary>
    /// <param name="archivo">Archivo visitado.</param>
    /// <returns>Resultado de la visita.</returns>
    string Visitar(Archivo archivo);

    /// <summary>Visita un directorio.</summary>
    /// <param name="directorio">Directorio visitado.</param>
    /// <returns>Resultado de la visita.</returns>
    string Visitar(Directorio directorio);

    /// <summary>Visita un archivo comprimido.</summary>
    /// <param name="comprimido">Archivo comprimido visitado.</param>
    /// <returns>Resultado de la visita.</returns>
    string Visitar(ArchivoComprimido comprimido);

    /// <summary>Visita un enlace directo.</summary>
    /// <param name="enlace">Enlace visitado.</param>
    /// <returns>Resultado de la visita.</returns>
    string Visitar(Enlace enlace);
}
