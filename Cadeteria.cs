class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadetes> listadoDeCadetes;

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
}
