
using Coffeeshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffeeshop.Data
{
   public interface ITipProizvodaRepository
    {
        List<TipProizvodum> GetTip();
        TipProizvodum GetById(int tipId);


        TipProizvodum CreateTip(TipProizvodum tipModel);

        void DeleteTip(int tipId);
       


        bool SaveChanges();
        

    }
}
