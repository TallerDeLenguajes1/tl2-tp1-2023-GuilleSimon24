
public class ManejoUI
{
    
    private string ruta;
    private gestionPedidos Pedidos;

    public string Ruta { get => ruta; set => ruta = value; }
    


    private void inicializar(Cadeteria miCadeteria)
    {
        Pedidos = new gestionPedidos(miCadeteria);
    }

    public List<string> MostrarMenu(Cadeteria miCadeteria)
    {
        inicializar(miCadeteria);
        List<string> resultados = new List<string>();
        return GenerarOpciones(resultados, miCadeteria);
    }

    private List<string> GenerarOpciones(List<string> resultados, Cadeteria miCadeteria)
    {
        string opcionCad;
        do
        {
            Console.WriteLine("Elija una opcion: ");
            Console.WriteLine("1_ Dar de alta un pedido");
            Console.WriteLine("2_ Asignar pedido a un cadete");
            Console.WriteLine("3_ Cambiar de estado un pedido");
            Console.WriteLine("4_ Reasignar pedido a otro cadete");
            Console.WriteLine("5_ Mostrar informe");
            Console.WriteLine("6_ Terminar el día");
            opcionCad = Console.ReadLine();


            switch (opcionCad)
            {
                case "1":
                    var pedidoSinAsignar = Pedidos.AltaPedido();
                    miCadeteria.ListadoPedidos.Add(pedidoSinAsignar);
                    resultados.Add("Pedido agregado correctamente.");
                    break;

                case "2":
                    if (Pedidos.AsignarPedido())
                    {
                        resultados.Add("Pedido agregado al cadete correctamente.");
                    }
                    else
                    {
                        resultados.Add("Ocurrio un error, no pudiste tomar el pedido");
                    }
                    break;

                case "3":
                    if (Pedidos.CambiarEstadoPedido())
                    {
                        resultados.Add("Cambiaste el estado del pedido correctamente.");
                    }
                    else
                    {
                        resultados.Add("No pudo cambiar el estado del pedido, intente nuevamente.");
                    }
                    break;

                case "4":
                    if (Pedidos.ReasignarPedido())
                    {
                        resultados.Add("Pedido reasignado correctamente.");
                    }
                    else
                    {
                        resultados.Add("No pudo reasignar el pedido, intentelo nuevamente.");
                    }
                    break;
                case "5":
                    return GenerarInforme(miCadeteria);

                case "6":
                    resultados.Add("Saliendo del sistema...");
                    break;

                default:
                    resultados.Add("Opción no válida. Intente nuevamente.");
                    break;
            }
        } while (opcionCad != "6");

        return resultados;
    }


    private List<string> GenerarInforme(Cadeteria miCadeteria)
    {
        List<string> informe = new List<string>
    {
        "=== Informe de Pedidos - Fin de Jornada ===\n"
    };
        foreach (var cadete in miCadeteria.ListadoDeCadetes)
        {

            IEnumerable<Pedido> pedidosDelCadete = miCadeteria.ListadoPedidos
                .Where(pedido => pedido.CadeteACargo != null &&
                                 pedido.CadeteACargo.Id == cadete.Id &&
                                 pedido.Estado == Pedido.EstadoPedido.Entregado);

            int cantidadEnvios = pedidosDelCadete.Count();
            double montoGanado = miCadeteria.JornalACobrar(cadete);

            informe.Add($"Cadete: {cadete.Nombre}");
            informe.Add($"Cantidad de Envíos: {cantidadEnvios}");
            informe.Add($"Monto Ganado: ${montoGanado}\n");
        }

        int totalEnvios = miCadeteria.ListadoPedidos
            .Count(pedido => pedido.Estado == Pedido.EstadoPedido.Entregado);

        double promedioEnvios = miCadeteria.ListadoDeCadetes.Count > 0
            ? (double)totalEnvios / miCadeteria.ListadoDeCadetes.Count
            : 0;

        informe.Add($"Total de Envíos: {totalEnvios}");
        informe.Add($"Promedio de Envíos por Cadete: {promedioEnvios:F2}\n");

        return informe;
    }
}

