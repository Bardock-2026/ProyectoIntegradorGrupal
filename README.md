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
