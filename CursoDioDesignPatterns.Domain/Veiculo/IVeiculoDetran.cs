using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursoDioDesignPatterns.Domain.Veiculo
{
   public interface IVeiculoDetran
    {
        public  Task AgendarVistoriaDetran(Guid veicuiloId);
    }
}
