using Coffeeshop.Models;
using Coffeeshop.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffeeshop.Data
{
    public interface IProizvodPorudzbinaRepository
    {


        List<ProizvodPorudzbineDto> GetProizvodPorudzbina();
        ProizvodPorudzbine GetById(int porudzbinaId);


        ProizvodPorudzbineConfirmation CreateProizvodPorudzbina(ProizvodPorudzbine porudzbinaModel);

        void DeleteProizvodPorudzbina(int porudzbinaId);

        List<ProizvodPorudzbine> GetProizvodByPorudzbina(int porudzbinaId);



        bool SaveChanges();
    }
}
