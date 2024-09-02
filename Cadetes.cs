class Cadetes
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedidos;
    private int entregados;

    public Cadetes()
    {
    }

    public Cadetes(int id, string nombre, string direccion, string telefono){
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono=telefono;
        new List<Pedido>();
        entregados = 0;
    } 

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    public int Entregados { get => entregados;set => entregados = value; }
    


    public double JornalACobrar()
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
        listadoPedidos.Add(pedido);
    }

    public void EliminarPedido(Pedido pedido)
    {
        listadoPedidos.Remove(pedido);
    }

    public int ObtenerPedidosTotales()
    {
        return listadoPedidos.Count();
    }

    public bool TienePedido(Pedido pedido)
    {
        return listadoPedidos.Contains(pedido);
    }
}
