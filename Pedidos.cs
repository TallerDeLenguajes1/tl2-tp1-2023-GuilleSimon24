class Pedido
{
    private int nro;
    private string obs;
    private Cliente cliente;
    private EstadoPedido estado;

    private Cadetes cadeteACargo;
    public enum EstadoPedido
    {
        Aceptado,
        Entregado,
        Cancelado
    }

    public Pedido(int nro, string obs, Cliente cliente, EstadoPedido estado)
    {
        this.nro = nro;
        this.obs = obs;
        this.cliente = cliente;
        this.estado = estado;
    }

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    internal EstadoPedido Estado { get => estado; set => estado = value; }
    internal Cadetes CadeteACargo { get => cadeteACargo; set => cadeteACargo = value; }

    public string VerDireccionCliente(Cliente cliente){
        return cliente.Direccion;
    }

    public string VerDatosCliente(Cliente cliente){
        string datos = "Nombre: " + cliente.Nombre + ",\n Telefono: " +  cliente.Telefono + ",\n Direccion: " + cliente.Direccion + ",\n Referencia: " + cliente.DatosReferenciaDireccion;
        return datos;
    }
}