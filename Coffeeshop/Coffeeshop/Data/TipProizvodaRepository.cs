using AutoMapper;
using Coffeeshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffeeshop.Data
{
    public class TipProizvodaRepository : ITipProizvodaRepository
    {
        
        private readonly it70g2018Context context;
        private readonly IMapper mapper;


        public TipProizvodaRepository(it70g2018Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            
        }
        public TipProizvodum CreateTip(TipProizvodum tipModel)
        {
            var createdEntity = context.TipProizvoda.Add(tipModel);

            SaveChanges();
            return (createdEntity.Entity);
        }

        public void DeleteTip(int tipId)
        {
            var tipovi = GetById(tipId);
            context.TipProizvoda.Remove(tipovi);

            SaveChanges();
        }

        public TipProizvodum GetById(int tipId)
        {
            return context.TipProizvoda.FirstOrDefault(e => e.Id == tipId);
        }

        public List<TipProizvodum> GetTip()
        {
            return context.TipProizvoda.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
