﻿using Coffeeshop.Models;
using Coffeeshop.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffeeshop.Data
{
    public interface IPorudzbinaRepository
    {

        List<Porudzbine> GetPorudzbine();
        Porudzbine GetById(int porudzbinaId);


        PorudzbineConfirmation CreatePorudzbina(Porudzbine porudzbinaModel);

        void DeletePorudzbina(int porudzbinaId);



        bool SaveChanges();
    }
}
