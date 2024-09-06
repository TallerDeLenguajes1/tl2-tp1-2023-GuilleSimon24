Cadeteria miCadeteria = new Cadeteria();
Funciones misFunciones = new Funciones();
List<Cadetes> cadetes = new List<Cadetes>();
List<Cadeteria> misCadeterias = new List<Cadeteria>();
cadetes = misFunciones.cargarCadetes(@"C:\1_Guillermo\Guardar\Facultad\TallerDeLenguajes2\TP1-POO\tl2-tp1-2023-GuilleSimon24\cadetes.csv", cadetes);
misCadeterias = misFunciones.cargarCadeterias(@"C:\1_Guillermo\Guardar\Facultad\TallerDeLenguajes2\TP1-POO\tl2-tp1-2023-GuilleSimon24\cadeteria.csv", cadetes, misCadeterias);

misCadeterias[0].ListadoDeCadetes = cadetes;
misFunciones.MiCadeteria = misCadeterias[0];
misFunciones.inicializar();

misFunciones.mostrarMenu();
