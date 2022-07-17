using System;

namespace Practica1
{
    class Program
    {
        static void Main(string[] args)
        {
            Compra compra1 = new Compra();
            Compra compra2 = new Compra();
            Compra compra3 = new Compra();
            Compra compra4 = new Compra();
            compra1.MontoCompra = 55;
            compra2.MontoCompra = 200;
            compra3.MontoCompra = 400;
            compra4.MontoCompra = 4000;

            var empleado = new Empleado();
            var empleado2 = new GerenteDepartamento();
            var empleado3 = new GerenteGeneral();

            empleado.SiguienteN(empleado2);
            empleado2.SiguienteN(empleado3);

            Console.WriteLine("Compra con un valor de: $"+compra1.MontoCompra);
            empleado.Aprobador(compra1);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Compra con un valor de: $" + compra2.MontoCompra);
            empleado.Aprobador(compra2);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Compra con un valor de: $" + compra3.MontoCompra);
            empleado.Aprobador(compra3);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Compra con un valor de: $" + compra4.MontoCompra);
            empleado.Aprobador(compra4);
            Console.WriteLine("----------------------------------------------");
        }
    }
}
