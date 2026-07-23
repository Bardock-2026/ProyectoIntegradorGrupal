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