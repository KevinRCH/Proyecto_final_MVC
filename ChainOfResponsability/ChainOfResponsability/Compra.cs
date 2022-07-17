using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsability
{
    public class Compra
    {
        public string DescripcionCompra { get; set; }
        public int MontoCompra { get; set; }
    }

    public abstract class Aprovador
    {
        protected Aprovador Siguiente;
        public void SiguienteNivel(Aprovador siguienteNivelAprobado)
        {
            this.Siguiente = siguienteNivelAprobado;
        }
        public abstract void AprobarCompra(Compra CompraRealizada);

    }
    public class Empleado : Aprovador
    {
        public override void AprobarCompra(Compra CompraRealizada)
        {
            if (CompraRealizada.MontoCompra<100)
            {
                Console.WriteLine("Compra aprobada por {0}", this.GetType().Name);
            }
            else
            {
                Siguiente.AprobarCompra(CompraRealizada);
            }
        }
    }
    public class GerenteDeDepartamento : Aprovador
    {
        public override void AprobarCompra(Compra CompraRealizada)
        {
            if (CompraRealizada.MontoCompra < 300)
            {
                Console.WriteLine("Compra aprobada por {0}", this.GetType().Name);
            }
            else
            {
                Siguiente.AprobarCompra(CompraRealizada);
            }
        }
    }
    public class GerenteGeneral : Aprovador
    {
        public override void AprobarCompra(Compra CompraRealizada)
        {
            if (CompraRealizada.MontoCompra < 500)
            {
                Console.WriteLine("Compra aprobada por {0}", this.GetType().Name);
            }
            else
            {
                Console.WriteLine("No se puede aprobar, el monto excede los $500");
            }
        }
    }
}
