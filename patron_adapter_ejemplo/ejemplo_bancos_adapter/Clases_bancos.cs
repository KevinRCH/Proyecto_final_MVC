using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo_bancos_adapter
{
    public abstract class Banco
    {
        public abstract void EnvioFondos();
        public abstract void RecibirFondos();
        public abstract void VenderDolares();
        public abstract void ComprarDolares();


    }

    public class BancoInternacional : Banco
    {
        public override void ComprarDolares()
        {
            Console.WriteLine("Banco Internacional, compra de dolares a 600");
        }

        public override void EnvioFondos()
        {
            Console.WriteLine("Banco Internacional, envio de fondos 25% de comision");
        }

        public override void RecibirFondos()
        {
            Console.WriteLine("Banco Internacional, fondos recibidos 15% de comision");
        }

        public override void VenderDolares()
        {
            Console.WriteLine("Banco Internacional, venta a 750");
        }
    }
    public class BancoNacional : Banco
    {
        public override void ComprarDolares()
        {
            Console.WriteLine("Banco Nacional, compra de dolares a 500");
        }

        public override void EnvioFondos()
        {
            Console.WriteLine("Banco Nacional. Fondos Enviados. Comision 18%");
        }

        public override void RecibirFondos()
        {
            Console.WriteLine("Banco Nacional. Fondos Recibidos. Comision de 20%");
        }

        public override void VenderDolares()
        {
            Console.WriteLine("Banco Nacional, venta a 670");
        }
    }
    public class BancoPYMES : Banco
    {
        public override void ComprarDolares()
        {
            Console.WriteLine("Banco PYMES, compra de dolares a 650");
        }

        public override void EnvioFondos()
        {
            Console.WriteLine("Banco PYMES, envio de fondos con 10% de comision");
        }

        public override void RecibirFondos()
        {
            Console.WriteLine("Banco PYMES, fondos recibidos con 10% de comision");
        }

        public override void VenderDolares()
        { 
            Console.WriteLine("Banco PYMES, venta a 800");
        }
    }
    public class CarteraDigital
    {
        public void ComprarCripto()
        {
            Console.WriteLine("Cartera digital. Compra de criptomonedas efectuada");
        }
        public void VenderCripto()
        {
            Console.WriteLine("Cartera digital. Criptomonedas vendidas");
        }
        public void EnviarCripto()
        {
            Console.WriteLine("Cartera digital. Criptomonedas enviadas a otra cartera");
        }
        public void RecibirCripto()
        {
            Console.WriteLine("Cartera digital. Criptomonedas recibidas desde otra cartera");
        }
    }
    public class CarteraDAdapter : Banco
    {
        CarteraDigital cartera = new CarteraDigital();
        public override void ComprarDolares()
        {
            cartera.ComprarCripto();
        }

        public override void EnvioFondos()
        {
            cartera.EnviarCripto();
        }

        public override void RecibirFondos()
        {
            cartera.RecibirCripto();
        }

        public override void VenderDolares()
        {
            cartera.VenderCripto();
        }
    }

}
