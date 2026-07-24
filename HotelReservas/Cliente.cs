using ProyectoIntegradorGrupal.Generales;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegradorGrupal.HotelReservas
{
    public class Cliente
    {
        // --- CAMPOS PRIVADOS ---
        private int id;
        private string nombre;
        private string cedula;
        private string telefono;
        private string email;

        // --- PROPIEDADES CON VALIDACIÓN ---
        public int Id { get => id; set => id = value; }

        public string Nombre
        {
            get => nombre;
            set
            {
                if (value == null || value == "")
                {
                    Console.WriteLine("El nombre no puede estar vacío.");
                    return;
                }
                nombre = value;
            }
        }

        public string Cedula
        {
            get => cedula;
            set
            {
                if (value == null || value == "" || value.Length != 10)
                {
                    Console.WriteLine("La cédula debe tener exactamente 10 dígitos.");
                    return;
                }
                cedula = value;
            }
        }

        public string Telefono
        {
            get => telefono;
            set
            {
                if (value == null || value == "" || value.Length < 7)
                {
                    Console.WriteLine("El teléfono debe tener al menos 7 dígitos.");
                    return;
                }
                telefono = value;
            }
        }

        public string Email
        {
            get => email;
            set
            {
                if (value == null || value == "" || !value.Contains("@"))
                {
                    Console.WriteLine("El email no es válido.");
                    return;
                }
                email = value;
            }
        }

        // --- CONSTRUCTOR ---
        public Cliente(string nombre, string cedula, string telefono, string email)
        {
            if (nombre == null || nombre.Length == 0)
                throw new Exception("El nombre no puede estar vacío");

            if (cedula == null || cedula.Length != 10)
                throw new Exception("La cédula debe tener exactamente 10 dígitos");

            if (telefono == null || telefono.Length < 7)
                throw new Exception("El teléfono debe tener al menos 7 dígitos");

            if (email == null || !email.Contains("@"))
                throw new Exception("El email no es válido");

            this.Nombre = nombre;
            this.Cedula = cedula;
            this.Telefono = telefono;
            this.Email = email;

            if (Database.Clientes.Count == 0)
                this.id = 1;
            else
                this.id = Database.Clientes.Max(x => x.Id) + 1;
        }

        // --- MÉTODO IMPRIMIR ---
        public void Imprimir()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Nombre: {this.Nombre}");
            Console.WriteLine($"Cédula: {this.Cedula}");
            Console.WriteLine($"Teléfono: {this.Telefono}");
            Console.WriteLine($"Email: {this.Email}");
            Console.WriteLine("------------------------------------");
        }

        // --- CRUD ---
        public static void CrearCliente()
        {
            Console.Clear();
            Console.WriteLine("********** Crear Cliente **********");

            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese cédula: ");
            string cedula = Console.ReadLine();
            Console.Write("Ingrese teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Ingrese email: ");
            string email = Console.ReadLine();

            Cliente objCliente = new Cliente(nombre, cedula, telefono, email);
            Database.Clientes.Add(objCliente);
            Database.GuardarClientes();
            Console.WriteLine("Cliente creado exitosamente!!");
            Console.ReadLine();
        }

        public static void ListarClientes()
        {
            Console.Clear();
            Console.WriteLine("********** Clientes Registrados **********");
            foreach (Cliente c in Database.Clientes)
            {
                c.Imprimir();
            }
            Console.ReadLine();
        }

        public static void BuscarCliente()
        {
            Console.Clear();
            Console.WriteLine("********** Buscar Cliente **********");
            Console.Write("Ingrese el ID del cliente: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Cliente objCliente = Database.Clientes.Find(c => c.Id == idIngresado);

            if (objCliente != null)
            {
                Console.WriteLine("Cliente encontrado!!");
                objCliente.Imprimir();
            }
            else
            {
                Console.WriteLine("Cliente NO encontrado...");
            }
            Console.ReadLine();
        }

        public static void ActualizarCliente()
        {
            Console.Clear();
            Console.WriteLine("********** Actualizar Cliente **********");
            Console.Write("Ingrese el ID del cliente a actualizar: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Cliente objCliente = Database.Clientes.Find(c => c.Id == idIngresado);

            if (objCliente != null)
            {
                objCliente.Imprimir();

                Console.Write("Ingrese el nuevo nombre: ");
                objCliente.Nombre = Console.ReadLine();
                Console.Write("Ingrese la nueva cédula: ");
                objCliente.Cedula = Console.ReadLine();
                Console.Write("Ingrese el nuevo teléfono: ");
                objCliente.Telefono = Console.ReadLine();
                Console.Write("Ingrese el nuevo email: ");
                objCliente.Email = Console.ReadLine();
                Database.GuardarClientes();
                Console.WriteLine("Cliente actualizado exitosamente!!");
            }
            else
            {
                Console.WriteLine("Cliente NO encontrado...");
            }
            Console.ReadLine();
        }

        public static void EliminarCliente()
        {
            Console.Clear();
            Console.WriteLine("********** Eliminar Cliente **********");
            Console.Write("Ingrese el ID del cliente a eliminar: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Cliente objCliente = Database.Clientes.Find(c => c.Id == idIngresado);

            if (objCliente != null)
            {
                objCliente.Imprimir();
                Console.WriteLine($"¿Estás seguro que quieres eliminar al cliente {objCliente.Nombre}? S/N:");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    Database.Clientes.Remove(objCliente);
                    Database.GuardarClientes();
                    Console.WriteLine("Cliente eliminado exitosamente!!");
                }
                else
                {
                    Console.WriteLine("Operación cancelada!!");
                }
            }
            else
            {
                Console.WriteLine("Cliente NO encontrado!!");
            }
            Console.ReadLine();
        }
    }
}
