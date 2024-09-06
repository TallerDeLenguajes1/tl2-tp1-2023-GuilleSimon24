class Cadeteria
{
    private string nombre;
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

    public void AsignarCadeteAPedido(){

    }



    public List<Pedido> AgregarPedido(Pedido pedido, List<Pedido> ListadoPedidos)
    {
        if (pedido == null)
        {
            Console.WriteLine("Pedido nulo");
        }else
        {
            ListadoPedidos.Add(pedido);
            
        }
        return ListadoPedidos;
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
}
