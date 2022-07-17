using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patron_adapter_ejemplo
{
    public abstract class Motor
    {
        public abstract void Acelerar();
        public abstract void Apagar();
        public abstract void Arrangar();
        public abstract void CargarCombustible();

    }
    public class MotorGasolina : Motor
    {
        public override void Acelerar()
        {
            Console.WriteLine("Acelerando Motor Gasolina...");
        }

        public override void Apagar()
        {
            Console.WriteLine("Apagando Motor Gasolina...");
        }

        public override void Arrangar()
        {
            Console.WriteLine("Arrancando Motor Gasolina...");
        }

        public override void CargarCombustible()
        {
            Console.WriteLine("Cargando combustible Motor Gasolina...");
        }
    }
    public class MotorDiesel : Motor
    {
        public override void Acelerar()
        {
            Console.WriteLine("Acelerando Motor Diesel...");
        }

        public override void Apagar()
        {
            Console.WriteLine("Apagando Motor Diesel...");
        }

        public override void Arrangar()
        {
            Console.WriteLine("Arrancando Motor Diesel...");
        }

        public override void CargarCombustible()
        {
            Console.WriteLine("Cargando combustible la Motor Diesel...");
        }
    }
     public class MotorElectrico
    {
        bool CargaElectrica;
        public void Encender()
        {
            if (CargaElectrica)
            {
                Console.WriteLine("Encendiendo Motor Electrico");

            }
            else
            {
                Console.WriteLine("El motor electrico no puede encender, no hay bateria");
            }

        }
        public void Desectivar()
        {
            Console.WriteLine("Motor desactivado");
        }
        public void Avanzar()
        {
            if (CargaElectrica)
            {

            }
        }
        public void RecargarBateria()
        {
            if (CargaElectrica)
            {
                Console.WriteLine("Bateria cargada");
            }
            else
            {
                CargaElectrica = true;
            }
        }
        public class MotorElectricoAdapter : Motor
        {
            MotorElectrico motor = new MotorElectrico();

            public override void Acelerar()
            {
                motor.Avanzar();

            }

            public override void Apagar()
            {
                throw new NotImplementedException();
            }

            public override void Arrangar()
            {
                throw new NotImplementedException();
            }

            public override void CargarCombustible()
            {
                throw new NotImplementedException();
            }
        }

    }
}

