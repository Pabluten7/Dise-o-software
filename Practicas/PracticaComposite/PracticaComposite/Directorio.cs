namespace PracticaComposite;

/// <summary>
/// Directorio del sistema Sparrow. Puede contener cualquier elemento,
/// incluidos otros directorios.
/// </summary>
public class Directorio : ElementoCompuesto
{
    /// <summary>
    /// Crea un directorio vacío con el nombre indicado.
    /// </summary>
    /// <param name="nombre">Nombre del directorio.</param>
    public Directorio(string nombre) : base(nombre)
    {
    }

    /// <summary>
    /// Tamaño de la definición del directorio (1 Kb) más el tamaño de
    /// todos los elementos que contiene.
    /// </summary>
    public override double Tamanho
    {
        get { return TamanhoDefinicionKb + TamanhoContenido(); }
    }

    /// <summary>Suma de los archivos de todos los elementos que contiene.</summary>
    public override int NumArchivos
    {
        get { return NumArchivosContenido(); }
    }
}
