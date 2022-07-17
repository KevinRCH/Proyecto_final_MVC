using System;

namespace ChainOfResponsability
{
    class Program
    {
        static void Main(string[] args)
        {
            Compra compra1 = new Compra();
            compra1.MontoCompra = 60;

            var empleado = new Empleado();
            var empleado2 = new GerenteDeDepartamento();
            var empleado3 = new GerenteGeneral();

            empleado.SiguienteNivel(empleado2);
            empleado2.SiguienteNivel(empleado3);

            empleado.AprobarCompra(compra1);
        }
    }
}
