
public class gestionPedidos
{
    private Cadeteria miCadeteria;

    public gestionPedidos(Cadeteria cadeteria)
    {
        miCadeteria = cadeteria;
    }

    public Cadeteria MiCadeteria { get => miCadeteria; set => miCadeteria = value; }

    public Pedido BuscarPedidoPorNumero(int nroPedido)
    {
        var pedido = miCadeteria.ListadoPedidos.Find(p => p.Nro == nroPedido);
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
        Cadetes cadete = MiCadeteria.ListadoDeCadetes.FirstOrDefault(c => c.Id == idCadete);

        if (cadete != null)
        {
            MiCadeteria.AgregarPedido(nuevoPedido, MiCadeteria.ListadoPedidos);
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
            Cadetes cadete = MiCadeteria.ListadoDeCadetes.FirstOrDefault(c => c.Id == idCadete);

            if (cadete != null)
            {
                MiCadeteria.AgregarPedido(pedido, MiCadeteria.ListadoPedidos);
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
            Cadetes nuevoCadete = MiCadeteria.ListadoDeCadetes.FirstOrDefault(c => c.Id == idNuevoCadete);

            if (nuevoCadete != null)
            {
                var cadeteAnterior = MiCadeteria.ListadoDeCadetes.FirstOrDefault(c => MiCadeteria.TienePedido(pedido));
                if (cadeteAnterior != null)
                {
                    MiCadeteria.EliminarPedido(pedido);
                }
                MiCadeteria.AgregarPedido(pedido, MiCadeteria.ListadoPedidos);
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

}

