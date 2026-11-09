namespace PracticaStrategy.Tests;

/// <summary>
/// Utilidades compartidas por las pruebas de los visitantes.
/// </summary>
public static class SistemaEjemplo
{
    /// <summary>
    /// Construye el sistema de archivos de ejemplo del enunciado.
    /// </summary>
    /// <returns>El directorio raíz del sistema.</returns>
    public static Directorio CrearFigura1()
    {
        Directorio raiz = new Directorio("Raiz");
        Directorio dirVacio = new Directorio("Directorio Vacio");
        Directorio dirArchivoUnico = new Directorio("Directorio Con Archivo Unico");
        Directorio dirComprimidoSimple = new Directorio("Directorio Con Archivo Comprimido Simple");
        Directorio dirAnidado = new Directorio("Directorio con Directorio Anidado");
        raiz.Anhadir(dirVacio);
        raiz.Anhadir(dirArchivoUnico);
        raiz.Anhadir(dirComprimidoSimple);
        raiz.Anhadir(dirAnidado);

        Archivo foto001 = new Archivo("foto001.jpg", 100);
        dirArchivoUnico.Anhadir(foto001);

        ArchivoComprimido ccSimple = new ArchivoComprimido("ccSimple.zip");
        dirComprimidoSimple.Anhadir(new Archivo("foto002.jpg", 200));
        dirComprimidoSimple.Anhadir(new Enlace(foto001));
        dirComprimidoSimple.Anhadir(ccSimple);
        ccSimple.Anhadir(new Directorio("Directorio Vacio En Archivo Comprimido"));
        ccSimple.Anhadir(new Archivo("foto003.jpg", 300));
        ccSimple.Anhadir(new Enlace(foto001));

        Directorio dirComprimidoComplejo = new Directorio("Directorio con Archivo Comprimido Complejo");
        dirAnidado.Anhadir(new Archivo("foto004.jpg", 400));
        dirAnidado.Anhadir(new Enlace(ccSimple));
        dirAnidado.Anhadir(new Enlace(dirVacio));
        dirAnidado.Anhadir(dirComprimidoComplejo);

        ArchivoComprimido ccComplejo = new ArchivoComprimido("ccComplejo.zip");
        ArchivoComprimido ccAnidada = new ArchivoComprimido("ccAnidada.zip");
        dirComprimidoComplejo.Anhadir(new Archivo("foto005", 500));
        dirComprimidoComplejo.Anhadir(new Archivo("foto006", 600));
        dirComprimidoComplejo.Anhadir(ccComplejo);
        ccComplejo.Anhadir(ccAnidada);
        ccComplejo.Anhadir(new Archivo("foto008.jpg", 800));
        ccAnidada.Anhadir(new Archivo("foto007.jpg", 700));

        return raiz;
    }

    /// <summary>
    /// Construye un sistema pequeño con nombres que contienen eñes (en
    /// minúscula y mayúscula) y vocales con tilde:
    /// Diseño Software / Canción.mp3, Años / (Año 2025.txt, Ñandú.txt),
    /// España.zip / Logroño.jpg, y un enlace a Canción.mp3.
    /// </summary>
    /// <returns>El directorio raíz del sistema.</returns>
    public static Directorio CrearSistemaConEnhes()
    {
        Directorio raiz = new Directorio("Diseño Software");
        Archivo cancion = new Archivo("Canción.mp3", 100);
        Directorio anhos = new Directorio("Años");
        ArchivoComprimido espanha = new ArchivoComprimido("España.zip");

        raiz.Anhadir(cancion);
        raiz.Anhadir(anhos);
        anhos.Anhadir(new Archivo("Año 2025.txt", 10));
        anhos.Anhadir(new Archivo("Ñandú.txt", 20));
        raiz.Anhadir(espanha);
        espanha.Anhadir(new Archivo("Logroño.jpg", 30));
        raiz.Anhadir(new Enlace(cancion));

        return raiz;
    }

    /// <summary>
    /// Une varias líneas en una sola cadena, terminando cada una con un
    /// salto de línea, para escribir cómodamente los resultados esperados.
    /// </summary>
    /// <param name="lineas">Líneas a unir.</param>
    /// <returns>La cadena resultante.</returns>
    public static string Lineas(params string[] lineas)
    {
        return string.Concat(lineas.Select(linea => linea + Environment.NewLine));
    }
}
