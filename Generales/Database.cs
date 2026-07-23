using ProyectoIntegradorGrupal.HotelReservas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegradorGrupal.Generales
{
    public static class Database
    {
        private static readonly string rutaCarpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Datos");
        private static readonly string rutaArchivoClientes = Path.Combine(rutaCarpeta, "Clientes.Json");
        private static readonly string rutaArchivoReservas = Path.Combine(rutaCarpeta, "Reservas.Json");
        private static readonly string rutaArchivoHabitaciones = Path.Combine(rutaCarpeta, "Habitaciones.Json");
        private static readonly string rutaArchivoPagos = Path.Combine(rutaCarpeta, "Pagos.Json");

        public static List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public static List<Reserva> Reservas { get; set; } = new List<Reserva>();
        public static List<Habitacion> Habitaciones { get; set; } = new List<Habitacion>();
        public static List<Pago> Pagos { get; set; } = new List<Pago>();

        public static void CargarDatos()
        {
            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            Clientes = ArchivoJson.Cargar<Cliente>(rutaArchivoClientes);
            Reservas = ArchivoJson.Cargar<Reserva>(rutaArchivoReservas);
            Habitaciones = ArchivoJson.Cargar<Habitacion>(rutaArchivoHabitaciones);
            Pagos = ArchivoJson.Cargar<Pago>(rutaArchivoPagos);
        }

        public static void GuardarDatos()
        {
            ArchivoJson.Guardar(rutaArchivoClientes, Clientes);
            ArchivoJson.Guardar(rutaArchivoReservas, Reservas);
            ArchivoJson.Guardar(rutaArchivoHabitaciones, Habitaciones);
            ArchivoJson.Guardar(rutaArchivoPagos, Pagos);
        }

        public static void GuardarClientes()
        {
            ArchivoJson.Guardar(rutaArchivoClientes, Clientes);
        }

        public static void GuardarReservas()
        {
            ArchivoJson.Guardar(rutaArchivoReservas, Reservas);
        }

        public static void GuardarHabitaciones()
        {
            ArchivoJson.Guardar(rutaArchivoHabitaciones, Habitaciones);
        }

        public static void GuardarPagos()
        {
            ArchivoJson.Guardar(rutaArchivoPagos, Pagos);
        }
    }
}
