using CursoDioDesignPatterns.Domain.Veiculo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CursoDioDesignPatterns.Infra.Repository.EF
{
    public class FrotaRepository : IVeiculoRepository
    {
        private readonly Context _dbcontext;
        public FrotaRepository(Context dbcontext) => this._dbcontext = dbcontext;
      
        public void Add(Veiculo veiculo)
        {
            _dbcontext.veiculos.Add(veiculo);
            _dbcontext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _dbcontext.veiculos.Remove(GetById(id));
            _dbcontext.SaveChanges();
        }

        public IEnumerable<Veiculo> GetAll() => _dbcontext.veiculos.ToList();

        public Veiculo GetById(Guid id) => _dbcontext.veiculos.SingleOrDefault(x => x.Id == id);
     

        public void Update(Guid id, Veiculo veiculo)
        {
            _dbcontext.Entry(GetById(id)).State = EntityState.Modified;
            _dbcontext.SaveChanges();
        }
    }
}
