using ProyectoIntegradorGrupal.Generales;
using ProyectoIntegradorGrupal.HotelReservas;

class Program
{
    static void Main(string[] args)
    {
        Database.CargarDatos();
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("=====================================");
            Console.WriteLine("         BIENVENIDO AL HOTEL         ");
            Console.WriteLine("=====================================");
            Console.WriteLine("             _________               ");
            Console.WriteLine("            |         |              ");
            Console.WriteLine("            |  HOTEL  |              ");
            Console.WriteLine("            |_________|              ");
            Console.WriteLine("            | []  []  |              ");
            Console.WriteLine("            | []  []  |              ");
            Console.WriteLine("            | []  []  |              ");
            Console.WriteLine("            |_________|              ");
            Console.WriteLine("=====================================");
            Console.WriteLine("1. Crear Cliente");
            Console.WriteLine("2. Listar Clientes");
            Console.WriteLine("3. Buscar Cliente");
            Console.WriteLine("4. Actualizar Cliente");
            Console.WriteLine("5. Eliminar Cliente");
            Console.WriteLine("6. Crear Habitación");
            Console.WriteLine("7. Listar Habitaciones");
            Console.WriteLine("8. Buscar Habitación");
            Console.WriteLine("9. Actualizar Habitación");
            Console.WriteLine("10. Eliminar Habitación");
            Console.WriteLine("11. Crear Reserva");
            Console.WriteLine("12. Listar Reservas");
            Console.WriteLine("13. Buscar Reserva");
            Console.WriteLine("14. Actualizar Reserva");
            Console.WriteLine("15. Eliminar Reserva");
            Console.WriteLine("16. Registrar Pago");
            Console.WriteLine("17. Listar Pagos");
            Console.WriteLine("18. Buscar Pago");
            Console.WriteLine("19. Actualizar Pago");
            Console.WriteLine("20. Eliminar Pago");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1: Cliente.CrearCliente(); break;
                case 2: Cliente.ListarClientes(); break;
                case 3: Cliente.BuscarCliente(); break;
                case 4: Cliente.ActualizarCliente(); break;
                case 5: Cliente.EliminarCliente(); break;
                case 6: Habitacion.CrearHabitacion(); break;
                case 7: Habitacion.ListarHabitaciones(); break;
                case 8: Habitacion.BuscarHabitacion(); break;
                case 9: Habitacion.ActualizarHabitacion(); break;
                case 10: Habitacion.EliminarHabitacion(); break;
                case 11: Reserva.CrearReserva(); break;
                case 12: Reserva.ListarReservas(); break;
                case 13: Reserva.BuscarReserva(); break;
                case 14: Reserva.ActualizarReserva(); break;
                case 15: Reserva.EliminarReserva(); break;
                case 16: Pago.CrearPago(); break;
                case 17: Pago.ListarPagos(); break;
                case 18: Pago.BuscarPago(); break;
                case 19: Pago.ActualizarPago(); break;
                case 20: Pago.EliminarPago(); break;
                case 0: Console.WriteLine("Saliendo del sistema..."); break;
                default: Console.WriteLine("Opción inválida."); Console.ReadLine(); break;

            }
        } while (opcion != 0);
    }
}
