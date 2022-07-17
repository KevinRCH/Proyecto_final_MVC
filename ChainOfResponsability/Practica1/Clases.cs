using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    public class Compra
    {
        public string DescripcionCompra { get; set; }
        public int MontoCompra { get; set; }

        
    }

    
    public interface IAprobador
    {
        //protected IAprobador Siguiente;
        //String Siguiente;
        
        public void SiguienteN(IAprobador siguienteNivelAprobado);
        public void Aprobador(Compra CompraRealizada);
    }


    public class Empleado : IAprobador
    {
        public IAprobador Siguiente { get; set; }

        public void Aprobador(Compra CompraRealizada)
        {
            if (CompraRealizada.MontoCompra < 100)
            {
                Console.WriteLine("Compra aprobada por {0}", this.GetType().Name);
            }
            else
            {
                Siguiente.Aprobador(CompraRealizada);
            }
        }

        public void SiguienteN(IAprobador siguienteNivelAprobado)
        {
            this.Siguiente = siguienteNivelAprobado;
        }
    }
    public class GerenteDepartamento : IAprobador
    {
        public IAprobador Siguiente { get; set; }
        public void Aprobador(Compra CompraRealizada)
        {
            if (CompraRealizada.MontoCompra < 300)
            {
                Console.WriteLine("Compra aprobada por {0}", this.GetType().Name);
            }
            else
            {
                Siguiente.Aprobador(CompraRealizada);
            }
        }
        public void SiguienteN(IAprobador siguienteNivelAprobado)
        {
            this.Siguiente = siguienteNivelAprobado;
        }

    }
    public class GerenteGeneral : IAprobador
    {
        public IAprobador Siguiente { get; set; }
        public void Aprobador(Compra CompraRealizada)
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
        public void SiguienteN(IAprobador siguienteNivelAprobado)
        {
            
        }

    }
}
