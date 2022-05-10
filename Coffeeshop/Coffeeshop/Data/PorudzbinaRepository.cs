using AutoMapper;
using Coffeeshop.Models;
using Coffeeshop.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffeeshop.Data
{
    public class PorudzbinaRepository : IPorudzbinaRepository
    {
        private readonly it70g2018Context context;
        private readonly IMapper mapper;

        public PorudzbinaRepository(it70g2018Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }
        public PorudzbineConfirmation CreatePorudzbina(Porudzbine porudzbinaModel)
        {
            var createdEntity = context.Porudzbines.Add(porudzbinaModel);

            SaveChanges();
            return mapper.Map<PorudzbineConfirmation>(createdEntity.Entity);
        }

        public void DeletePorudzbina(int porudzbinaId)
        {
            var porudzbine = GetById(porudzbinaId);
            context.Porudzbines.Remove(porudzbine);

            SaveChanges();
        }

        public Porudzbine GetById(int porudzbinaId)
        {
            return context.Porudzbines.FirstOrDefault(e => e.Id == porudzbinaId);
        }

        public List<Porudzbine> GetPorudzbine()
        {
            return context.Porudzbines.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
