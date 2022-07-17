using System;

namespace patron_adapter_ejemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            MotorDiesel car1 = new MotorDiesel();
            car1.Acelerar();
            car1.Apagar();
            car1.Arrangar();
            car1.CargarCombustible();
            Console.WriteLine("----------------------------------------");

            MotorGasolina car2 = new MotorGasolina();
            car2.Acelerar();
            car2.Apagar();
            car2.Arrangar();
            car2.CargarCombustible();
            Console.WriteLine("----------------------------------------");


        }
    }
}
