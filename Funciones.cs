
class Funciones
{
    private Cadeteria miCadeteria;
    private string ruta;

    public string Ruta { get => ruta; set => ruta = value; }
    public Cadeteria MiCadeteria { get => miCadeteria; set => miCadeteria = value; }

    public void inicializar(){
        miCadeteria.ListadoPedidos = new List<Pedido>();
    }

    private Pedido BuscarPedidoPorNumero(int nroPedido)
    {
        foreach (var cadete in MiCadeteria.ListadoPedidos)
        {
            Pedido pedido = MiCadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == nroPedido);
            if (pedido != null)
            {
                return pedido;
            }
        }
        return null;
    }


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
                string idCadena;
                int id;
                string direccion;
                string telefono;

                idCadena = values[i];
                int.TryParse(idCadena, out id);
                nombre = values[i + 1];
                direccion = values[i + 2];
                telefono = values[i + 3];

                listaCadetes.Add(new Cadetes(id, nombre, direccion, telefono));
            }
        }
        return listaCadetes;

    }

    public void altaPedido()
    {
        Console.Write("Ingrese el número del pedido: ");
        int nroPedido = int.Parse(Console.ReadLine());
        Console.Write("Ingrese observaciones del pedido: ");
        string observaciones = Console.ReadLine();
        Console.Write("Ingrese el nombre del cliente: ");
        string nombreCliente = Console.ReadLine();
        Console.Write("Ingrese la dirección del cliente: ");
        string direccionCliente = Console.ReadLine();
        Console.Write("Ingrese el teléfono del cliente: ");
        string telefonoCliente = Console.ReadLine();
        Console.Write("Ingrese alguna referencia: ");
        string referencia = Console.ReadLine();

        Cliente nuevoCliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, referencia);
        Pedido nuevoPedido = new Pedido(nroPedido, observaciones, nuevoCliente, Pedido.EstadoPedido.Aceptado);

        Console.Write("Ingrese el ID del cadete al que se le asignará el pedido: ");
        int idCadete = int.Parse(Console.ReadLine());
        Cadetes cadete = miCadeteria.ListadoDeCadetes.FirstOrDefault(c => c.Id == idCadete);

        if (cadete != null)
        {
            miCadeteria.AgregarPedido(nuevoPedido, miCadeteria.ListadoPedidos);
            Console.WriteLine("Pedido asignado exitosamente al cadete.");
        }
        else
        {
            Console.WriteLine("Cadete no encontrado.");
        }


    }

    private void asignarPedido()
    {
        Console.Write("Ingrese el número del pedido a asignar: ");
        int nroPedido = int.Parse(Console.ReadLine());
        Pedido pedido = BuscarPedidoPorNumero(nroPedido);

        if (pedido != null)
        {
            Console.Write("Ingrese el ID del cadete al que se le asignará el pedido: ");
            int idCadete = int.Parse(Console.ReadLine());
            Cadetes cadete = MiCadeteria.ListadoDeCadetes.FirstOrDefault(c => c.Id == idCadete);

            if (cadete != null)
            {
                MiCadeteria.AgregarPedido(pedido, miCadeteria.ListadoPedidos);
                Console.WriteLine("Pedido asignado exitosamente al cadete.");
            }
            else
            {
                Console.WriteLine("Cadete no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Pedido no encontrado.");
        }
    }


    private void reasignarPedido()
    {
        Console.Write("Ingrese el número del pedido a reasignar: ");
        int nroPedido = int.Parse(Console.ReadLine());
        Pedido pedido = BuscarPedidoPorNumero(nroPedido);

        if (pedido != null)
        {
            Console.Write("Ingrese el ID del nuevo cadete: ");
            int idNuevoCadete = int.Parse(Console.ReadLine());
            Cadetes nuevoCadete = MiCadeteria.ListadoDeCadetes.FirstOrDefault(c => c.Id == idNuevoCadete);

            if (nuevoCadete != null)
            {
                var cadeteAnterior = MiCadeteria.ListadoDeCadetes.FirstOrDefault(c => MiCadeteria.TienePedido(pedido));
                if (cadeteAnterior != null)
                {
                    MiCadeteria.EliminarPedido(pedido);
                }
                MiCadeteria.AgregarPedido(pedido, miCadeteria.ListadoPedidos);
                Console.WriteLine("Pedido reasignado exitosamente.");
            }
            else
            {
                Console.WriteLine("Nuevo cadete no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Pedido no encontrado.");
        }

    }

    public List<Cadeteria> cargarCadeterias(string Ruta, List<Cadetes> listadoDeCadetes, List<Cadeteria> listaCadeteria)
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
                string telefono;

                nombre = values[i];
                telefono = values[i + 1];

                listaCadeteria.Add(new Cadeteria(nombre, telefono, listadoDeCadetes));
            }
        }
        return listaCadeteria;
    }

    public void mostrarMenu()
    {
        Console.WriteLine("Elija una opcion: ");
        Console.WriteLine("1_ Dar de alta un pedido");
        Console.WriteLine("2_ Asignar pedido a un cadete");
        Console.WriteLine("3_ Cambiar de estado un pedido");
        Console.WriteLine("4_ Reasignar pedido a otro cadete");
        Console.WriteLine("5_ Mostrar informe");
        Console.WriteLine("6_ Terminar el día");
        string opcionCad = Console.ReadLine();
        int opcion;
        bool anda = int.TryParse(opcionCad, out opcion);

        if (anda)
        {
            switch (opcion)
            {
                case 1:
                    altaPedido();
                    mostrarMenu();
                    break;
                case 2:
                    asignarPedido();
                    mostrarMenu();
                    break;
                case 3:
                    CambiarEstadoPedido();
                    mostrarMenu();
                    break;
                case 4:
                    reasignarPedido();
                    mostrarMenu();
                    break;
                case 5:
                    GenerarInforme();
                    mostrarMenu();
                    break;
                case 6:
                    Console.WriteLine("Fin del dia! Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Elija una opcion valida");
                    mostrarMenu();
                    break;
            }
        }
    }

    private void CambiarEstadoPedido()
    {
        Console.Write("Ingrese el número del pedido: ");
        int nroPedido = int.Parse(Console.ReadLine());
        Pedido pedido = BuscarPedidoPorNumero(nroPedido);

        if (pedido != null)
        {
            Console.WriteLine("Seleccione el nuevo estado del pedido:");
            Console.WriteLine("1. Pendiente");
            Console.WriteLine("2. Entregado");
            int opcionEstado = int.Parse(Console.ReadLine());

            switch (opcionEstado)
            {
                case 1:
                    pedido.Estado = Pedido.EstadoPedido.Aceptado;
                    break;
                case 2:
                    pedido.Estado = Pedido.EstadoPedido.Entregado;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("Estado del pedido actualizado.");
        }
        else
        {
            Console.WriteLine("Pedido no encontrado.");
        }
    }
    private void GenerarInforme()
    {
        Console.WriteLine("=== Informe de Pedidos - Fin de Jornada ===\n");

        // Calcular el monto ganado y la cantidad de envíos de cada cadete
        foreach (var cadete in MiCadeteria.ListadoDeCadetes)
        {
            int cantidadEnvios = MiCadeteria.ListadoPedidos.Count;
            double montoGanado = MiCadeteria.JornalACobrar(cadete);
            Console.WriteLine($"Cadete: {cadete.Nombre}");
            Console.WriteLine($"Cantidad de Envíos: {cantidadEnvios}");
            Console.WriteLine($"Monto Ganado: ${montoGanado}\n");
        }

        // Calcular el total de envíos de todos los cadetes
        int totalEnvios = MiCadeteria.ListadoDeCadetes.Sum(c => MiCadeteria.ListadoPedidos.Count);

        // Calcular el promedio de envíos por cadete
        double promedioEnvios = MiCadeteria.ListadoDeCadetes.Count > 0 ? (double)totalEnvios / MiCadeteria.ListadoDeCadetes.Count : 0;

        Console.WriteLine("=== Resumen ===");
        Console.WriteLine($"Total de Envíos: {totalEnvios}");
        Console.WriteLine($"Promedio de Envíos por Cadete: {promedioEnvios:F2}\n");
    }
}

