# ProyectoIntegradorGrupal
22/07/2026
Fernando Calderon
Descripción:
Motivo del cambio:
El proyecto anterior quedó inconsistente por un error de coordinación en el trabajo grupal.
Se decidió rehacer todo desde cero para garantizar orden, claridad y coherencia en la estructura del código y carpetas.
Este commit marca el nuevo inicio oficial del proyecto HotelReservas, tomando como base la clase Cliente y preparando el terreno para las demás clases (Habitación, Reserva, Pago).
Se rehizo completamente la estructura del proyecto en Visual Studio debido a un error de coordinación con el compañero de grupo.
Se creó la carpeta HotelReservas para contener todas las clases principales del sistema.
Se creó la carpeta Generales para manejar la lógica de persistencia, incluyendo las clases Database y ArchivoJson.
Se comenzó nuevamente con la clase Cliente, implementando:
Campos privados: id, nombre, cedula, telefono, email.
Propiedades públicas con validaciones simples y mensajes claros en consola.
Constructor con asignación automática de ID incremental desde la lista global en Database.
Método Imprimir() para mostrar datos del cliente.
CRUD completo (CrearCliente, ListarClientes, BuscarCliente, ActualizarCliente, EliminarCliente).

Implementación de la clase Reserva
Descripción:
Se agregó la clase Reserva dentro de la carpeta HotelReservas.
La clase incluye:
Campos privados: id, cliente, habitacion, fechaInicio, fechaFin.
Propiedades públicas con validaciones simples:
Validación de cliente y habitación no nulos.
Validación de fechas (la fecha de fin debe ser mayor a la fecha de inicio).
Constructor con validaciones iniciales y asignación automática de ID incremental desde la lista global en Database.
Método Imprimir() para mostrar los datos completos de la reserva.
CRUD completo:
CrearReserva: permite registrar una nueva reserva, validando cliente, habitación y fechas.
ListarReservas: muestra todas las reservas registradas.
BuscarReserva: busca una reserva por ID.
ActualizarReserva: permite modificar las fechas de una reserva existente.
EliminarReserva: elimina una reserva y libera la habitación asociada.
Motivo del cambio:
Continuando con el reinicio del proyecto HotelReservas, se implementó la clase Reserva como parte fundamental del sistema de gestión.
Esta clase asegura la relación entre Cliente y Habitación, además de manejar la lógica de disponibilidad de habitaciones.
Se mantiene la misma estructura y estilo limpio definido previamente en la clase Cliente, garantizando coherencia en todo el proyecto.

Implementación de la clase Database
Descripción:
Se creó la clase Database dentro de la carpeta Generales.
La clase se definió como static para centralizar la gestión de datos del sistema.
Se implementaron:
Rutas de archivos JSON para cada entidad (Clientes, Reservas, Habitaciones, Pagos), almacenados en la carpeta Datos dentro del directorio base del proyecto.
Listas globales (List<Cliente>, List<Reserva>, List<Habitacion>, List<Pago>) que funcionan como repositorio en memoria.
Método CargarDatos() que inicializa las listas cargando información desde los archivos JSON, creando la carpeta Datos si no existe.
Método GuardarDatos() que guarda todas las listas en sus respectivos archivos JSON.
Métodos individuales (GuardarClientes, GuardarReservas, GuardarHabitaciones, GuardarPagos) para persistir cada entidad de forma independiente.
Motivo del cambio:
La clase Database es el núcleo de persistencia del proyecto HotelReservas, permitiendo que los datos de clientes, reservas, habitaciones y pagos se mantengan organizados y disponibles entre ejecuciones.
Se estableció una estructura clara y ordenada para garantizar la escalabilidad del sistema y facilitar la integración con las clases de negocio (Cliente, Reserva, Habitacion, Pago).
Este commit asegura que el proyecto ya cuenta con un mecanismo sólido de almacenamiento y recuperación de información.

22/07/2026
Jonathan Anchundia
Tuvimos un inconveniente de coordinación en el equipo y la versión anterior del código nos había quedado bastante desordenada e inconsistente.
Por eso, preferimos no complicarnos y decidimos rehacer esta parte desde cero para dejar todo bien estructurado, limpio y funcionando como tiene que ser.
Se agregó el archivo inicial en Program.cs por un menú interactivo en consola, así que ahora se puede navegar súper fácil entre clientes, habitaciones, reservas y pagos.
También agregué la clase ArchivoJson para manejar toda la persistencia de datos en archivos JSON y no perder la información al cerrar el programa.
Además implementé la clase Habitacion con sus validaciones, constructor y su CRUD completo para controlar la disponibilidad.
Agregué la clase Pago, que también viene con sus validaciones y su CRUD para vincular cada pago directamente con su reserva.
Con este reinicio el proyecto quedó totalmente ordenado.

23/07/2027
Fernando Calderon
Reincorporación de Cliente y Reserva en Database
- Se agregó nuevamente la clase Cliente al proyecto con sus propiedades y validaciones simples.
- Se reincorporó la clase Reserva siguiendo el mismo esquema oficial (campos privados, propiedades públicas con get/set).
- Ambas clases fueron registradas en la clase Database para que se manejen en listas globales y se guarden en el archivo JSON.
- Ajustes realizados para que las búsquedas y operaciones CRUD se hagan por ID como identificador único.
- Con esto, Database reconoce correctamente Cliente y Reserva junto con las demás entidades del sistema.
- Menú principal actualizado con CRUD de Cliente y Reserva
- Se añadieron los casos 1 al 5 para ejecutar las funciones CRUD de Cliente (crear, listar, buscar, actualizar, eliminar).
- Se añadieron los casos 11 al 15 para ejecutar las funciones CRUD de Reserva (crear, listar, buscar, actualizar, eliminar).
- El menú ahora reconoce correctamente las operaciones de Cliente y Reserva conectadas con Database.
- Proyecto listo para ejecutar con todas las opciones integradas.

fix: persistencia de datos en CRUD

Me di cuenta que el programa, aunque funcionaba en las operaciones de crear,
actualizar y eliminar, no cumplía con el requerimiento de guardar en memoria.
El detalle era que olvidé llamar a los métodos de guardado (GuardarClientes,
GuardarReservas, GuardarHabitaciones, GuardarPagos) después de cada operación
de modificación. Esto provocaba que los cambios se perdieran al cerrar el
programa.

Se corrigió agregando las llamadas a los métodos de guardado en las funciones
de crear, actualizar y eliminar de cada clase, asegurando la persistencia en
JSON.