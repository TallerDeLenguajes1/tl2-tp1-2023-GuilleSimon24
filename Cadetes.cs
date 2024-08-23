class Cadetes
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Pedido> listadoPedidos;

    public Cadetes()
    {
    }

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public double jornalACobrar(List<Pedido> listadoDePedidos)
    {
        int cantidad = 0;
        foreach (var item in listadoDePedidos)
        {
            if (item.Estado == Pedido.EstadoPedido.Entregado)
            {
                cantidad++;
            }
        }

        return (cantidad * 500);
    }
}
