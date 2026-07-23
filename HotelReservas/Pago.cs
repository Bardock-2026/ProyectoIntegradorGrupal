using ProyectoIntegradorGrupal.Generales;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ProyectoIntegradorGrupal.HotelReservas
{
    public class Pago
    {
        // --- CAMPOS PRIVADOS ---
        private int id;
        private Reserva reserva;
        private decimal monto;
        private DateTime fechaPago;

        // --- PROPIEDADES CON VALIDACIÓN ---
        public int Id { get => id; set => id = value; }

        public Reserva Reserva
        {
            get => reserva;
            set
            {
                if (value == null)
                {
                    Console.WriteLine("La reserva asociada al pago no existe.");
                    return;
                }
                reserva = value;
            }
        }

        public decimal Monto
        {
            get => monto;
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("El monto debe ser mayor a 0.");
                    return;
                }
                monto = value;
            }
        }

        public DateTime FechaPago { get => fechaPago; set => fechaPago = value; }

        // --- CONSTRUCTOR ---
        public Pago(Reserva reserva, decimal monto)
        {
            if (reserva == null)
                throw new Exception("La reserva asociada al pago no existe");

            if (monto <= 0)
                throw new Exception("El monto debe ser mayor a 0");

            this.Reserva = reserva;
            this.Monto = monto;
            this.FechaPago = DateTime.Now;

            if (Database.Pagos.Count == 0)
                this.id = 1;
            else
                this.id = Database.Pagos.Max(x => x.Id) + 1;
        }

        // --- MÉTODO IMPRIMIR ---
        public void Imprimir()
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Reserva: {this.Reserva.Id}");
            Console.WriteLine($"Monto: {this.Monto}");
            Console.WriteLine($"Fecha de Pago: {this.FechaPago}");
            Console.WriteLine("------------------------------------");
        }

        // --- CRUD ---
        public static void CrearPago()
        {
            Console.Clear();
            Console.WriteLine("********** Registrar Pago **********");

            Console.Write("Ingrese ID de la reserva: ");
            int idReserva = Convert.ToInt32(Console.ReadLine());
            Reserva reserva = Database.Reservas.Find(r => r.Id == idReserva);

            if (reserva == null)
            {
                Console.WriteLine("Reserva no encontrada.");
                return;
            }

            Console.Write("Ingrese monto: ");
            decimal monto = Convert.ToDecimal(Console.ReadLine());

            Pago pago = new Pago(reserva, monto);
            Database.Pagos.Add(pago);

            Console.WriteLine("Pago registrado exitosamente!!");
            Console.ReadLine();
        }

        public static void ListarPagos()
        {
            Console.Clear();
            Console.WriteLine("********** Pagos Registrados **********");
            foreach (Pago p in Database.Pagos)
            {
                p.Imprimir();
            }
            Console.ReadLine();
        }

        public static void BuscarPago()
        {
            Console.Clear();
            Console.WriteLine("********** Buscar Pago **********");
            Console.Write("Ingrese el ID del pago: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Pago objPago = Database.Pagos.Find(p => p.Id == idIngresado);

            if (objPago != null)
            {
                Console.WriteLine("Pago encontrado!!");
                objPago.Imprimir();
            }
            else
            {
                Console.WriteLine("Pago NO encontrado...");
            }
            Console.ReadLine();
        }

        public static void ActualizarPago()
        {
            Console.Clear();
            Console.WriteLine("********** Actualizar Pago **********");
            Console.Write("Ingrese el ID del pago a actualizar: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Pago objPago = Database.Pagos.Find(p => p.Id == idIngresado);

            if (objPago != null)
            {
                Console.WriteLine("Pago encontrado!!");
                objPago.Imprimir();

                Console.Write("Ingrese nuevo monto: ");
                objPago.Monto = Convert.ToDecimal(Console.ReadLine());

                objPago.FechaPago = DateTime.Now;

                Console.WriteLine("Pago actualizado exitosamente!!");
            }
            else
            {
                Console.WriteLine("Pago NO encontrado...");
            }
            Console.ReadLine();
        }

        public static void EliminarPago()
        {
            Console.Clear();
            Console.WriteLine("********** Eliminar Pago **********");
            Console.Write("Ingrese el ID del pago a eliminar: ");
            int idIngresado = Convert.ToInt32(Console.ReadLine());

            Pago objPago = Database.Pagos.Find(p => p.Id == idIngresado);

            if (objPago != null)
            {
                objPago.Imprimir();
                Console.WriteLine($"¿Estás seguro que quieres eliminar el pago ID {objPago.Id}? S/N:");
                if (Console.ReadLine().ToUpper() == "S")
                {
                    Database.Pagos.Remove(objPago);
                    Console.WriteLine("Pago eliminado exitosamente!!");
                }
                else
                {
                    Console.WriteLine("Operación cancelada!!");
                }
            }
            else
            {
                Console.WriteLine("Pago NO encontrado!!");
            }
            Console.ReadLine();
        }
    }
}

