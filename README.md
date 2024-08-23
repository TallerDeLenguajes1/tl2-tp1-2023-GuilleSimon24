 * La relacion pedido clientes es por Composición, las demás son por agregacion

 * Los metodos que se podría agregar es la cantidad de pedidos entregados, cancelados o pendientes, tipo estadiscticas. Lo mismo que en la clase cadetes se podría agregar un metodo en el que se pueda calcular una calificacion del cadete segundo los clientes

 * En todas las clases las propiedades deben ser privadas, mientras que los metodos tienen que ser publicos para poder comunicarse entre las clases

 * El constructor de la clase cadeteria podria ir vacio o con nombre y direccion, en la clase cadete con los datos personales del cadete mientras que el ID se inicializa solo y la lista de pedidos igual, en la clase pedidos se le puede pasar el cliente en el constructor y en la clase cliente pueden ser todos los datos

 * Se podria agregar una propiedad en el pedido que diga cual es el cadete a cargo, lo que haria que la relacion pedido-cadete empiece a ser por composicion y el pedido se relacionaria directamente con la cadeteria, lo cual tambien eliminaria la lista de pedidos a cargo del cadete y podria ser reemplazado con un contador que sume a la hora de entregar el pedido
 
