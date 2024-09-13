using System.Text.Json;
// Clase derivada para acceso a JSON 
public class AccesoJSON : AccesoADatos
{
    public override Cadeteria CargarDatos(string archivoCadeteria, string archivoCadetes, Cadeteria miCadeteria, string extension)
    {
        string carpetaJson = @"C:\1_Guillermo\Guardar\Facultad\TallerDeLenguajes2\TP1-POO\tl2-tp1-2023-GuilleSimon24";

        if (!Directory.Exists(carpetaJson))
        {
            Directory.CreateDirectory(carpetaJson);
        }

        string rutaArchivoCadeteria = Path.Combine(carpetaJson, archivoCadeteria + extension);
        string rutaArchivoCadetes = Path.Combine(carpetaJson, archivoCadetes + extension);

        if (!File.Exists(rutaArchivoCadeteria))
        {
            Console.WriteLine($"El archivo {archivoCadeteria + extension} no existe en la ruta especificada: {rutaArchivoCadeteria}");
            return miCadeteria;
        }

        if (!File.Exists(rutaArchivoCadetes))
        {
            Console.WriteLine($"El archivo {archivoCadetes + extension} no existe en la ruta especificada: {rutaArchivoCadetes}");
            return miCadeteria;
        }

        try
        {
            string contenidoCadeteriaJson = File.ReadAllText(rutaArchivoCadeteria);
            miCadeteria = JsonSerializer.Deserialize<Cadeteria>(contenidoCadeteriaJson) ?? miCadeteria;

            string contenidoCadetesJson = File.ReadAllText(rutaArchivoCadetes);
            List<Cadetes> cadetes = JsonSerializer.Deserialize<List<Cadetes>>(contenidoCadetesJson) ?? new List<Cadetes>();

            // Asigno los cadetes a la cadetería
            miCadeteria.ListadoDeCadetes = cadetes;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Error al leer o deserializar los archivos JSON: {ex.Message}");
        }

        return miCadeteria;
    }
}