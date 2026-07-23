using ProyectoIntegradorGrupal.Generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegradorGrupal.HotelReservas
{
    public class Habitacion
    {
        // --- CAMPOS PRIVADOS ---
        private int id;
        private string tipo;
        private decimal precio;
        private string estado;

        // --- PROPIEDADES CON VALIDACIÓN ---
        public int Id { get => id; set => id = value; }

        public string Tipo
        {
            get => tipo;
            set
            {
                if (value == null || value == "")
                {
                    Console.WriteLine("El tipo no puede estar vacío.");
                    return;
                }
                tipo = value;
            }
        }

        public decimal Precio
        {
            get => precio;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("El precio debe ser mayor a 0.");
                    return;
                }
                precio = value;
            }
        }

        public string Estado
        {
            get => estado;
            set
            {
                if (value != "Disponible" && value != "Ocupada")
                {
                    Console.WriteLine("El estado debe ser Disponible u Ocupada.");
                    return;
                }
                estado = value;
            }
        }

        // --- CONSTRUCTOR ---
        public Habitacion(string tipo, decimal precio, string estado = "Disponible")
        {
            if (tipo == null || tipo.Length == 0)
                throw new Exception("El tipo no puede estar vacío");

            if (precio <= 0)
                throw new Exception("El precio debe ser mayor a 0");

            if (estado != "Disponible" && estado != "Ocupada")
                throw new Exception("El estado debe ser Disponible u Ocupada");

            this.Tipo = tipo;
            this.Precio = precio;
            this.Estado = estado;

            if (Database.Habitaciones.Count == 0)
                this.id = 1;
            else
                this.id = Database.Habitaciones.Max(x => x.Id) + 1;
        }

        // --- MÉTODO IMPRIMIR ---
        public void Imprimir()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Tipo: {this.Tipo}");
            Console.WriteLine($"Precio: {this.Precio}");
            Console.WriteLine($"Estado: {this.Estado}");
            Console.WriteLine("------------------------------------");
        }

        // --- CRUD ---
        public static void CrearHabitacion()
        {
            Console.Clear();
            Console.WriteLine("********** Crear Habitación **********");

            Console.Write("Ingrese tipo: ");
            string tipo = Console.ReadLine();
            Console.Write("Ingrese precio: ");
            decimal precio = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Ingrese estado (Disponible/Ocupada): ");
            string estado = Console.ReadLine();

            Habitacion objHabitacion = new Habitacion(tipo, precio, estado);
            Database.Habitaciones.Add(objHabitacion);

            Console.WriteLine("Habitación creada exitosamente!!");
            Console.ReadLine();
        }

        public static void ListarHabitaciones()
        {
            Console.Clear();
            Console.WriteLine("********** Habitaciones Registradas **********");
            foreach (Habitacion h in Database.Habitaciones)
            {
                h.Imprimir();
            }
            Console.ReadLine();
        }

        public static void BuscarHabitacion()
        {
            Console.Clear();
            Console.WriteLine("********** Buscar Habitación **********");
            Console.Write("Ingrese el ID de la habitación: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Habitacion objHabitacion = Database.Habitaciones.Find(h => h.Id == idIngresado);

            if (objHabitacion != null)
            {
                Console.WriteLine("Habitación encontrada!!");
                objHabitacion.Imprimir();
            }
            else
            {
                Console.WriteLine("Habitación NO encontrada...");
            }
            Console.ReadLine();
        }

        public static void ActualizarHabitacion()
        {
            Console.Clear();
            Console.WriteLine("********** Actualizar Habitación **********");
            Console.Write("Ingrese el ID de la habitación a actualizar: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Habitacion objHabitacion = Database.Habitaciones.Find(h => h.Id == idIngresado);

            if (objHabitacion != null)
            {
                objHabitacion.Imprimir();

                Console.Write("Ingrese el nuevo tipo: ");
                objHabitacion.Tipo = Console.ReadLine();

                Console.Write("Ingrese el nuevo precio: ");
                objHabitacion.Precio = Convert.ToDecimal(Console.ReadLine());

                Console.Write("Ingrese el nuevo estado (Disponible/Ocupada): ");
                objHabitacion.Estado = Console.ReadLine();

                Console.WriteLine("Habitación actualizada exitosamente!!");
            }
            else
            {
                Console.WriteLine("Habitación NO encontrada...");
            }
            Console.ReadLine();
        }

        public static void EliminarHabitacion()
        {
            Console.Clear();
            Console.WriteLine("********** Eliminar Habitación **********");
            Console.Write("Ingrese el ID de la habitación a eliminar: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Habitacion objHabitacion = Database.Habitaciones.Find(h => h.Id == idIngresado);

            if (objHabitacion != null)
            {
                objHabitacion.Imprimir();
                Console.WriteLine($"¿Estás seguro que quieres eliminar la habitación ID {objHabitacion.Id}? S/N:");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    Database.Habitaciones.Remove(objHabitacion);
                    Console.WriteLine("Habitación eliminada exitosamente!!");
                }
                else
                {
                    Console.WriteLine("Operación cancelada!!");
                }
            }
            else
            {
                Console.WriteLine("Habitación NO encontrada!!");
            }
            Console.ReadLine();
        }
    }
}

