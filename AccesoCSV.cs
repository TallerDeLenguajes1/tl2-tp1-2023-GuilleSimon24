
// Clase derivada para acceso a CSV
public class AccesoCSV : AccesoADatos
{
    public override Cadeteria CargarDatos(string archivoCadeteria, string archivoCadetes, Cadeteria miCadeteria, string extension)
    {
        string carpetaCsv = @"C:\1_Guillermo\Guardar\Facultad\TallerDeLenguajes2\TP1-POO\tl2-tp1-2023-GuilleSimon24";

        if (!Directory.Exists(carpetaCsv))
        {
            Directory.CreateDirectory(carpetaCsv);
        }

        string rutaArchivoCadeteria = Path.Combine(carpetaCsv, archivoCadeteria + extension);
        string rutaArchivoCadetes = Path.Combine(carpetaCsv, archivoCadetes + extension);

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

        using (StreamReader archivo = new StreamReader(rutaArchivoCadeteria))
        {
            string separador = ",";
            string linea;
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);
                miCadeteria.Nombre = fila[0];
                miCadeteria.Direccion = fila[1];
                miCadeteria.Telefono = fila[2];
            }
        }

        using (StreamReader archivo = new StreamReader(rutaArchivoCadetes))
        {
            string separador = ",";
            string linea;
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);
                int idCadete = int.Parse(fila[0]);
                Cadetes cadeteExistente = miCadeteria.ListadoDeCadetes.FirstOrDefault(c => c.Id == idCadete);

                if (cadeteExistente == null)
                {
                    Cadetes nuevoCadete = new Cadetes(idCadete, fila[1], fila[2], fila[3]);
                    miCadeteria.ListadoDeCadetes.Add(nuevoCadete);
                }
            }
        }

        return miCadeteria;
    }
}
