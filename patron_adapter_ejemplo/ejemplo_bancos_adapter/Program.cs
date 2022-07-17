using System;

namespace ejemplo_bancos_adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Banco banco1 = new BancoInternacional();
            banco1.ComprarDolares();
            banco1.VenderDolares();
            banco1.RecibirFondos();
            banco1.RecibirFondos();
            Console.WriteLine("-----------------------------------");
            Banco banco2 = new BancoPYMES();
            banco2.ComprarDolares();
            banco2.VenderDolares();
            banco2.RecibirFondos();
            banco2.RecibirFondos();
            Console.WriteLine("-----------------------------------");
            Banco banco3 = new BancoNacional();
            banco3.ComprarDolares();
            banco3.VenderDolares();
            banco3.RecibirFondos();
            banco3.RecibirFondos();
            Console.WriteLine("-----------------------------------");
            Banco carterad = new CarteraDAdapter();
            carterad.ComprarDolares();
            carterad.VenderDolares();
            carterad.RecibirFondos();
            carterad.RecibirFondos();

        }
    }
}
