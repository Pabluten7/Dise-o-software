using System.Text;

namespace PracticaStrategy.App;

/// <summary>
/// Programa de demostración: muestra un sistema Sparrow con eñes y tildes
/// usando cada estrategia de visualización, primero con el patrón Strategy
/// y después con expresiones lambda.
/// </summary>
public static class Program
{
    /// <summary>
    /// Punto de entrada de la aplicación. Es el único lugar donde se crean
    /// las estrategias concretas y se inyectan en quien las usa.
    /// </summary>
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        Directorio raiz = CrearSistema();

        // --------------- Versión con el patrón Strategy ---------------
        Console.Out.WriteLine("##### PATRÓN STRATEGY #####");
        Console.Out.WriteLine();

        Dictionary<string, IEstrategiaVisualizacion> estrategias = new Dictionary<string, IEstrategiaVisualizacion>
        {
            ["Castellano"] = new EstrategiaCastellano(),
            ["Gallega"] = new EstrategiaGallega(),
            ["Catalana"] = new EstrategiaCatalana(),
            ["Internacional gallega"] = new EstrategiaInternacionalGallega(),
            ["Internacional catalana"] = new EstrategiaInternacionalCatalana()
        };

        foreach (KeyValuePair<string, IEstrategiaVisualizacion> par in estrategias)
        {
            Console.Out.WriteLine("Estrategia " + par.Key + ":");
            new SparrowView(par.Value).MostrarSistemaSparrow(raiz);
            Console.Out.WriteLine();
        }

        Console.Out.WriteLine("Formato compacto, estrategia internacional catalana:");
        Console.Out.Write(raiz.Aceptar(new VisitanteCompacto(new EstrategiaInternacionalCatalana())));
        Console.Out.WriteLine();

        // --------------- Versión con expresiones lambda ---------------
        Console.Out.WriteLine("##### EXPRESIONES LAMBDA #####");
        Console.Out.WriteLine();

        Console.Out.WriteLine("Lambda internacional gallega:");
        new SparrowViewLambda(EstrategiasLambda.InternacionalGallega).MostrarSistemaSparrow(raiz);
        Console.Out.WriteLine();

        Console.Out.WriteLine("Lambda escrita en el momento (todo en mayúsculas):");
        new SparrowViewLambda(texto => texto.ToUpper()).MostrarSistemaSparrow(raiz);
    }

    /// <summary>
    /// Construye un sistema de ejemplo con nombres que contienen eñes y tildes.
    /// </summary>
    /// <returns>El directorio raíz del sistema.</returns>
    private static Directorio CrearSistema()
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
        espanha.Anhadir(new Archivo("Briñón.pdf", 40));
        raiz.Anhadir(new Enlace(cancion));

        return raiz;
    }
}
