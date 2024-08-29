
class Funciones
{
    private string ruta;


    public string Ruta { get => ruta; set => ruta = value; }


    public List<Cadetes> cargarCadetes(string Ruta, List<Cadetes> listaCadetes)
    {
        
        using (StreamReader sr = new StreamReader(Ruta))
        {
            string linea;
            sr.ReadLine();

            while ((linea = sr.ReadLine()) != null)
            {
                // Dividir la línea por comas
                string[] values = linea.Split(',');

                int i = 0;
                string nombre;
                string id;
                string direccion;
                string telefono;

                id = values[i];
                nombre = values[i + 1];
                direccion = values[i + 2];
                telefono = values[i + 3];
                
                listaCadetes.Add(new Cadetes(id, nombre, direccion, telefono));
            }
        }
        return listaCadetes;

    }

    public List<Cadeteria> cargarCadeterias(string Ruta, List<Cadetes> listadoDeCadetes, List<Cadeteria> listaCadeteria){

        using (StreamReader sr = new StreamReader(Ruta))
        {
            string linea;
            sr.ReadLine();

            while ((linea = sr.ReadLine()) != null)
            {
                // Dividir la línea por comas
                string[] values = linea.Split(',');

                int i = 0;
                string nombre;
                string telefono;

                nombre = values[i];
                telefono = values[i + 1];
                
                listaCadeteria.Add(new Cadeteria(nombre, telefono, listadoDeCadetes));
            }
        }
        return listaCadeteria;
    }

    public int mostrarMenu()
    {
        Console.WriteLine("Elija una opcion: ");
        string opcionCad = Console.ReadLine();
        int opcion;
        bool anda = int.TryParse(opcionCad, out opcion);

        if (anda)
        {
            switch (opcion)
            {
                case 1:
                    Console.WriteLine("1_ Dar de alta un pedido");
                    break;
                case 2:
                    Console.WriteLine("2_ Asignar pedido a un cadete");
                    break;
                case 3:
                    Console.WriteLine("3_ Cambiar de estado un pedido");
                    break;
                case 4:
                    Console.WriteLine("4_ Reasignar pedido a otro cadete");
                    break;
                case 5:
                    Console.WriteLine("5_ Terminar el día");
                    break;
                default:
                    Console.WriteLine("Elija una opcion valida");
                    break;
            }

        }

        return opcion;
    }
}

