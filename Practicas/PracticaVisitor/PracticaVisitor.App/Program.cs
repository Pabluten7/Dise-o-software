using System.Text;

namespace PracticaVisitor.App;

/// <summary>
/// Programa de demostración: construye el sistema de archivos de la
/// ejemplo del enunciado y lo muestra en los formatos extendido y compacto.
/// </summary>
public static class Program
{
    /// <summary>
    /// Punto de entrada de la aplicación.
    /// </summary>
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Nivel 1
        Directorio raiz = new Directorio("Raiz");
        Directorio dirVacio = new Directorio("Directorio Vacio");
        Directorio dirArchivoUnico = new Directorio("Directorio Con Archivo Unico");
        Directorio dirComprimidoSimple = new Directorio("Directorio Con Archivo Comprimido Simple");
        Directorio dirAnidado = new Directorio("Directorio con Directorio Anidado");
        raiz.Anhadir(dirVacio);
        raiz.Anhadir(dirArchivoUnico);
        raiz.Anhadir(dirComprimidoSimple);
        raiz.Anhadir(dirAnidado);

        // Directorio Con Archivo Unico
        Archivo foto001 = new Archivo("foto001.jpg", 100);
        dirArchivoUnico.Anhadir(foto001);

        // Directorio Con Archivo Comprimido Simple
        ArchivoComprimido ccSimple = new ArchivoComprimido("ccSimple.zip");
        dirComprimidoSimple.Anhadir(new Archivo("foto002.jpg", 200));
        dirComprimidoSimple.Anhadir(new Enlace(foto001));
        dirComprimidoSimple.Anhadir(ccSimple);
        ccSimple.Anhadir(new Directorio("Directorio Vacio En Archivo Comprimido"));
        ccSimple.Anhadir(new Archivo("foto003.jpg", 300));
        ccSimple.Anhadir(new Enlace(foto001));

        // Directorio con Directorio Anidado
        Directorio dirComprimidoComplejo = new Directorio("Directorio con Archivo Comprimido Complejo");
        dirAnidado.Anhadir(new Archivo("foto004.jpg", 400));
        dirAnidado.Anhadir(new Enlace(ccSimple));
        dirAnidado.Anhadir(new Enlace(dirVacio));
        dirAnidado.Anhadir(dirComprimidoComplejo);

        // Directorio con Archivo Comprimido Complejo
        ArchivoComprimido ccComplejo = new ArchivoComprimido("ccComplejo.zip");
        ArchivoComprimido ccAnidada = new ArchivoComprimido("ccAnidada.zip");
        dirComprimidoComplejo.Anhadir(new Archivo("foto005", 500));
        dirComprimidoComplejo.Anhadir(new Archivo("foto006", 600));
        dirComprimidoComplejo.Anhadir(ccComplejo);
        ccComplejo.Anhadir(ccAnidada);
        ccComplejo.Anhadir(new Archivo("foto008.jpg", 800));
        ccAnidada.Anhadir(new Archivo("foto007.jpg", 700));

        // Formato extendido, a través del visor
        SparrowView visor = new SparrowView();
        visor.MostrarSistemaSparrow(raiz);

        // Formato compacto, usando directamente el visitante
        Console.Out.WriteLine();
        Console.Out.WriteLine("------- Formato compacto -------");
        Console.Out.WriteLine();
        Console.Out.Write(raiz.Aceptar(new VisitanteCompacto()));

        // Cualquier elemento se puede visitar, no solo la raíz
        Console.Out.WriteLine();
        visor.MostrarSistemaSparrow(dirAnidado);

        // Las propiedades del Composite siguen funcionando igual
        Console.Out.WriteLine();
        ImprimirPropiedadesElementoSparrow(raiz);
    }

    /// <summary>
    /// Imprime por pantalla el nombre, tamaño y número de archivos de
    /// cualquier elemento del sistema Sparrow.
    /// </summary>
    /// <param name="e">Elemento cuyas propiedades se imprimen.</param>
    public static void ImprimirPropiedadesElementoSparrow(ElementoSparrow e)
    {
        Console.Out.WriteLine("============= Info ===============");
        Console.Out.WriteLine();
        Console.Out.WriteLine("Nombre        : " + e.Nombre);
        Console.Out.WriteLine("Tamaño        : " + e.Tamanho);
        Console.Out.WriteLine("Num. Archivos : " + e.NumArchivos);
        Console.Out.WriteLine();
    }
}
