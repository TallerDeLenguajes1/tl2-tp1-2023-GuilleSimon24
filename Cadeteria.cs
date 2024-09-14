public class Cadeteria
{
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Cadetes> listadoDeCadetes;
    private List<Pedido> listadoPedidos;

    public Cadeteria()
    {
    }

    public Cadeteria(string nombre, string telefono, List<Cadetes> listadoDeCadetes){
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoDeCadetes = listadoDeCadetes;
    }    

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadetes> ListadoDeCadetes { get => listadoDeCadetes; set => listadoDeCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    public string Direccion { get => direccion; set => direccion = value; }

    public double JornalACobrar(Cadetes cadete)
    {
        int contador = 0;
        foreach (var item in listadoPedidos)
        {
            if (item.Estado == Pedido.EstadoPedido.Entregado)
            {
                contador++;
            }
        }

        return contador * 500;
    }


    public void AgregarPedido(Pedido pedido)
    {
        if (pedido == null)
        {
            Console.WriteLine("Pedido nulo");
        }else
        {
            ListadoPedidos.Add(pedido);   
        }
    }

    public void EliminarPedido(Pedido pedido)
    {
        ListadoPedidos.Remove(pedido);
    }

    public int ObtenerPedidosTotales()
    {
        return ListadoPedidos.Count();
    }

    public bool TienePedido(Pedido pedido)
    {
        return ListadoPedidos.Contains(pedido);
    }

    public Pedido BuscarPedidoPorNumero(int nroPedido)
    {
        var pedido = ListadoPedidos.Find(p => p.Nro == nroPedido);
        return pedido;
    }
    public Pedido AltaPedido()
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
        Cadetes cadete = ListadoDeCadetes.FirstOrDefault(c => c.Id == idCadete);

        if (cadete != null)
        {
            AgregarPedido(nuevoPedido);
        }


        return nuevoPedido;
    }

    public bool AsignarPedido()
    {
        Console.Write("Ingrese el número del pedido a asignar: ");
        int nroPedido = int.Parse(Console.ReadLine());
        Pedido pedido = BuscarPedidoPorNumero(nroPedido);

        if (pedido != null)
        {
            Console.Write("Ingrese el ID del cadete al que se le asignará el pedido: ");
            int idCadete = int.Parse(Console.ReadLine());
            Cadetes cadete = ListadoDeCadetes.FirstOrDefault(c => c.Id == idCadete);

            if (cadete != null)
            {
                AgregarPedido(pedido);
                return true;
            }

            return false;

        }

        return false;

    }


    public bool ReasignarPedido()
    {
        Console.Write("Ingrese el número del pedido a reasignar: ");
        int nroPedido = int.Parse(Console.ReadLine());
        Pedido pedido = BuscarPedidoPorNumero(nroPedido);

        if (pedido != null)
        {
            Console.Write("Ingrese el ID del nuevo cadete: ");
            int idNuevoCadete = int.Parse(Console.ReadLine());
            Cadetes nuevoCadete = ListadoDeCadetes.FirstOrDefault(c => c.Id == idNuevoCadete);

            if (nuevoCadete != null)
            {
                var cadeteAnterior = ListadoDeCadetes.FirstOrDefault(c => TienePedido(pedido));
                if (cadeteAnterior != null)
                {
                    EliminarPedido(pedido);
                }
                AgregarPedido(pedido);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
    public bool CambiarEstadoPedido()
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

            return true;
        }
        else
        {
            return false;
        }
    }

    public void listarPedido(Pedido nuevoPedido){
        listadoPedidos.Add(nuevoPedido);
    }




}
