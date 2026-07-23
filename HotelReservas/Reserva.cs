using ProyectoIntegradorGrupal.Generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegradorGrupal.HotelReservas
{
    public class Reserva
    {
        // --- CAMPOS PRIVADOS ---
        private int id;
        private Cliente cliente;
        private Habitacion habitacion;
        private DateTime fechaInicio;
        private DateTime fechaFin;

        // --- PROPIEDADES CON VALIDACIÓN ---
        public int Id { get => id; set => id = value; }

        public Cliente Cliente
        {
            get => cliente;
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Debe seleccionar un cliente válido.");
                    return;
                }
                cliente = value;
            }
        }

        public Habitacion Habitacion
        {
            get => habitacion;
            set
            {
                if (value == null)
                {
                    Console.WriteLine("Debe seleccionar una habitación válida.");
                    return;
                }
                habitacion = value;
            }
        }

        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }

        public DateTime FechaFin
        {
            get => fechaFin;
            set
            {
                if (value <= fechaInicio)
                {
                    Console.WriteLine("La fecha de fin debe ser mayor a la fecha de inicio.");
                    return;
                }
                fechaFin = value;
            }
        }

        // --- CONSTRUCTOR ---
        public Reserva(Cliente cliente, Habitacion habitacion, DateTime fechaInicio, DateTime fechaFin)
        {
            if (cliente == null)
                throw new Exception("Debe seleccionar un cliente válido");

            if (habitacion == null)
                throw new Exception("Debe seleccionar una habitación válida");

            if (fechaFin <= fechaInicio)
                throw new Exception("La fecha de fin debe ser mayor a la fecha de inicio");

            this.Cliente = cliente;
            this.Habitacion = habitacion;
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;

            if (Database.Reservas.Count == 0)
                this.id = 1;
            else
                this.id = Database.Reservas.Max(x => x.Id) + 1;
        }

        // --- MÉTODO IMPRIMIR ---
        public void Imprimir()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Cliente: {this.Cliente.Nombre}");
            Console.WriteLine($"Habitación ID: {this.Habitacion.Id}");
            Console.WriteLine($"Fecha Inicio: {this.FechaInicio.ToShortDateString()}");
            Console.WriteLine($"Fecha Fin: {this.FechaFin.ToShortDateString()}");
            Console.WriteLine("------------------------------------");
        }

        // --- CRUD ---
        public static void CrearReserva()
        {
            Console.Clear();
            Console.WriteLine("********** Crear Reserva **********");

            Console.Write("Ingrese ID del cliente: ");
            int idCliente = Convert.ToInt32(Console.ReadLine());
            Cliente cliente = Database.Clientes.Find(c => c.Id == idCliente);

            if (cliente == null)
            {
                Console.WriteLine("Cliente no encontrado.");
                return;
            }

            Console.Write("Ingrese ID de la habitación: ");
            int idHabitacion = Convert.ToInt32(Console.ReadLine());
            Habitacion habitacion = Database.Habitaciones.Find(h => h.Id == idHabitacion);

            if (habitacion == null || habitacion.Estado == "Ocupada")
            {
                Console.WriteLine("La habitación no está disponible.");
                return;
            }

            Console.Write("Ingrese fecha inicio (yyyy-mm-dd): ");
            DateTime inicio = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Ingrese fecha fin (yyyy-mm-dd): ");
            DateTime fin = Convert.ToDateTime(Console.ReadLine());

            Reserva reserva = new Reserva(cliente, habitacion, inicio, fin);
            Database.Reservas.Add(reserva);
            habitacion.Estado = "Ocupada";

            Console.WriteLine("Reserva creada exitosamente!!");
            Console.ReadLine();
        }

        public static void ListarReservas()
        {
            Console.Clear();
            Console.WriteLine("********** Reservas Registradas **********");
            foreach (Reserva r in Database.Reservas)
            {
                r.Imprimir();
            }
            Console.ReadLine();
        }

        public static void BuscarReserva()
        {
            Console.Clear();
            Console.WriteLine("********** Buscar Reserva **********");
            Console.Write("Ingrese el ID de la reserva: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Reserva objReserva = Database.Reservas.Find(r => r.Id == idIngresado);

            if (objReserva != null)
            {
                Console.WriteLine("Reserva encontrada!!");
                objReserva.Imprimir();
            }
            else
            {
                Console.WriteLine("Reserva NO encontrada...");
            }
            Console.ReadLine();
        }

        public static void ActualizarReserva()
        {
            Console.Clear();
            Console.WriteLine("********** Actualizar Reserva **********");
            Console.Write("Ingrese el ID de la reserva a actualizar: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Reserva objReserva = Database.Reservas.Find(r => r.Id == idIngresado);

            if (objReserva != null)
            {
                objReserva.Imprimir();

                Console.Write("Ingrese nueva fecha inicio (yyyy-mm-dd): ");
                objReserva.FechaInicio = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Ingrese nueva fecha fin (yyyy-mm-dd): ");
                objReserva.FechaFin = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Reserva actualizada exitosamente!!");
            }
            else
            {
                Console.WriteLine("Reserva NO encontrada...");
            }
            Console.ReadLine();
        }

        public static void EliminarReserva()
        {
            Console.Clear();
            Console.WriteLine("********** Eliminar Reserva **********");
            Console.Write("Ingrese el ID de la reserva a eliminar: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Reserva objReserva = Database.Reservas.Find(r => r.Id == idIngresado);

            if (objReserva != null)
            {
                objReserva.Imprimir();
                Console.WriteLine($"¿Estás seguro que quieres eliminar la reserva ID {objReserva.Id}? S/N:");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    objReserva.Habitacion.Estado = "Disponible";
                    Database.Reservas.Remove(objReserva);
                    Console.WriteLine("Reserva eliminada y habitación liberada!!");
                }
                else
                {
                    Console.WriteLine("Operación cancelada!!");
                }
            }
            else
            {
                Console.WriteLine("Reserva NO encontrada!!");
            }
            Console.ReadLine();
        }
    }
}

