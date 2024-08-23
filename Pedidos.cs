class Pedido
{
    private int nro;
    private string obs;
    private Cliente cliente;
    private EstadoPedido estado;
    public enum EstadoPedido
    {
        Aceptado,
        Entregado,
        Enviando,
        Cancelado
    }

    public Pedido()
    {
    }

    public int Nro { get => nro; set => nro = value; }
    public string Obs { get => obs; set => obs = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    internal EstadoPedido Estado { get => estado; set => estado = value; }

    public string VerDireccionCliente(Cliente cliente){
        return cliente.Direccion;
    }

    public string VerDatosCliente(Cliente cliente){
        string datos = "Nombre: " + cliente.Nombre + ",\n Telefono: " +  cliente.Telefono + ",\n Direccion: " + cliente.Direccion + ",\n Referencia: " + cliente.DatosReferenciaDireccion;
        return datos;
    }
}