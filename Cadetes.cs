public class Cadetes
{
    private int id;
    private string nombre;
    private string direccion;
    private string telefono;
    
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
    public int Entregados { get => entregados;set => entregados = value; }
    


    
}
