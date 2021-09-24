using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDioDesignPatterns.Domain.Veiculo
{
  public  interface IVeiculoRepository
    {
        Veiculo GetById(Guid id);

        IEnumerable<Veiculo> GetAll();

        void Add(Veiculo veiculo);
        void Delete(Guid id);
        void Update(Guid id,Veiculo veiculo);
    }
}
