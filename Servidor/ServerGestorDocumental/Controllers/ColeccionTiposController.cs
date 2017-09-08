using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using formulario;
using formulario.Models;
using formulario.Servicios;
using System.Web.Http.Cors;

namespace formulario.Controllers
{
    [EnableCors(origins: "http://localhost:8080, http://localhost:8081, http://localhost:3000", headers: "*", methods: "*")]

    public class ColeccionTiposController : ApiController
    {
        private IColeccionTiposService coleccionTiposService;

        public ColeccionTiposController(IColeccionTiposService _coleccionTiposService)
        {
            this.coleccionTiposService = _coleccionTiposService;
        }

        // GET: api/ColeccionTipos
        public IQueryable<ColeccionTipo> GetColeccionTipos()
        {
            return coleccionTiposService.Get();
        }

        // GET: api/ColeccionTipos/5
        [ResponseType(typeof(ColeccionTipo))]
        public IHttpActionResult GetColeccionTipo(long id)
        {
            ColeccionTipo coleccionTipo = coleccionTiposService.Get(id);
            if (coleccionTipo == null)
            {
                return NotFound();
            }

            return Ok(coleccionTipo);
        }

        // PUT: api/ColeccionTipos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutColeccionTipo(long id, ColeccionTipo coleccionTipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coleccionTipo.Id)
            {
                return BadRequest();
            }

            try
            {
                coleccionTiposService.Put(coleccionTipo);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ColeccionTipos
        [ResponseType(typeof(ColeccionTipo))]
        public IHttpActionResult PostColeccionTipo(ColeccionTipo coleccionTipo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            coleccionTipo = coleccionTiposService.Create(coleccionTipo);

            return CreatedAtRoute("DefaultApi", new { id = coleccionTipo.Id }, coleccionTipo);
        }

        // DELETE: api/ColeccionTipos/5
        [ResponseType(typeof(ColeccionTipo))]
        public IHttpActionResult DeleteColeccionTipo(long id)
        {
            ColeccionTipo coleccionTipo;
            try
            {
                coleccionTipo = coleccionTiposService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(coleccionTipo);
        }
    }
}