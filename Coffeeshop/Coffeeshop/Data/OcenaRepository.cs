﻿using AutoMapper;
using Coffeeshop.Models;
using Coffeeshop.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffeeshop.Data
{
    public class OcenaRepository : IOcenaRepository
    {

        private readonly it70g2018Context context;
        private readonly IMapper mapper;

        public OcenaRepository(it70g2018Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;

        }

        public OcenaConfirmation CreateOcena(Ocena ocenaModel)
        {
            var createdEntity = context.Ocenas.Add(ocenaModel);

            SaveChanges();
            return mapper.Map<OcenaConfirmation>(createdEntity.Entity);
        }

        public void DeleteOcena(int ocenaId)
        {
            var ocene = GetById(ocenaId);
            context.Ocenas.Remove(ocene);

            SaveChanges();
        }

        public Ocena GetById(int ocenaId)
        {
            return context.Ocenas.FirstOrDefault(e => e.Id == ocenaId);
        }

        public List<Ocena> GetOcena()
        {
            return context.Ocenas.ToList();
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
    }
}
