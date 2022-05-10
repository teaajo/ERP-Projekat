﻿using AutoMapper;
using Coffeeshop.Data;
using Coffeeshop.Models;
using Coffeeshop.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coffeeshop.Controllers
{
    [ApiController]
    [Route("api/porudzbine")]
    [Produces("application/json", "application/xml")]
    public class PorudzbinaController : ControllerBase
    {
        private readonly IPorudzbinaRepository porudzbinaRepository;

        private readonly IMapper mapper;
        private readonly LinkGenerator linkGenerator;

        public PorudzbinaController(IPorudzbinaRepository porudzbinaRepository, IMapper mapper, LinkGenerator linkGenerator)
        {
            this.porudzbinaRepository = porudzbinaRepository;
            this.mapper = mapper;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        [HttpHead]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public ActionResult<List<Porudzbine>> GetPorudzbine()
        {

            List<Porudzbine> porudzbines = porudzbinaRepository.GetPorudzbine();
            if (porudzbines == null || porudzbines.Count == 0)
            {

                return NoContent();

            }

            return Ok(porudzbines);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public ActionResult<Porudzbine> GetPorudzbinaById(int id)
        {

            Porudzbine porudzbinaModel = porudzbinaRepository.GetById(id);
            if (porudzbinaModel == null)
            {

                return NotFound();
            }

            return Ok(porudzbinaModel);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        // [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public IActionResult DeletePorudzbina(int id)
        {
            try
            {

                Porudzbine porudzbinaModel = porudzbinaRepository.GetById(id);
                if (porudzbinaModel == null)
                {

                    return NotFound();
                }
                porudzbinaRepository.DeletePorudzbina(id);
                porudzbinaRepository.SaveChanges();

                return NoContent();
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");

            }
        }

        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<PorudzbineConfirmation> CreatePorudzbina([FromBody] PorudzbineCreation porudzbine)
        {
            try
            {

                Porudzbine porudzbina = mapper.Map<Porudzbine>(porudzbine);

                PorudzbineConfirmation confirmation = porudzbinaRepository.CreatePorudzbina(porudzbina);
                string location = linkGenerator.GetPathByAction("GetPorudzbine", "Porudzbina", new { tipId = confirmation.Id });

                return Created(location, mapper.Map<PorudzbineConfirmation>(confirmation));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);

            }



        }

        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles = "Administrator")]
        public ActionResult<PorudzbineConfirmation> UpdatePorudzbine(Porudzbine porudzbine)
        {


            try
            {

                var oldporudzbina = porudzbinaRepository.GetById(porudzbine.Id);
                if (oldporudzbina == null)
                {

                    return NotFound();
                }
                mapper.Map(porudzbine, oldporudzbina);
                porudzbinaRepository.SaveChanges();

                return Ok(mapper.Map<PorudzbineConfirmation>(oldporudzbina));

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Update error");


            }


        }

        [HttpOptions]
        public IActionResult GetkorisnikOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, DELETE");
            return Ok();
        }

    }
}
