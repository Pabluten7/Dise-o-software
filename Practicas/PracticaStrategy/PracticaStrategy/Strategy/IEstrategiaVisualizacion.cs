namespace PracticaStrategy;

/// <summary>
/// Estrategia abstracta del patrón Strategy: forma de adaptar los textos de
/// un sistema Sparrow a los caracteres que admite el dispositivo de salida.
/// Los visitantes de impresión dependen solo de esta interfaz, nunca de sus
/// implementaciones concretas (inversión de dependencias).
/// </summary>
public interface IEstrategiaVisualizacion
{
    /// <summary>
    /// Adapta un texto para que pueda mostrarse en el dispositivo de salida.
    /// </summary>
    /// <param name="texto">Texto original.</param>
    /// <returns>El texto adaptado.</returns>
    string Adaptar(string texto);
}
