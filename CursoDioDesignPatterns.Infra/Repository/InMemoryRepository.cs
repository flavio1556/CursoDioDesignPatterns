using CursoDioDesignPatterns.Domain.Veiculo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace CursoDioDesignPatterns.Infra.Repository
{
   public class InMemoryRepository : IVeiculoRepository
    {
        private readonly IList<Veiculo> entites = new List<Veiculo>();

        public void Add(Veiculo veiculo) => entites.Add(veiculo);

        public void Delete(Guid id) => entites.Remove(GetById(id));


        public IEnumerable<Veiculo> GetAll() => entites.ToList();

        public Veiculo GetById(Guid id) => entites.SingleOrDefault(x => x.Id == id);

        public void Update(Guid id,Veiculo veiculo)
        {
            entites.Remove(GetById(id));
            entites.Add(veiculo);
        }
    }
}
