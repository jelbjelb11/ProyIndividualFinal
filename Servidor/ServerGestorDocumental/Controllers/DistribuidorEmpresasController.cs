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

    public class DistribuidorEmpresasController : ApiController
    {
        private IDistribuidorEmpresasService distribuidorEmpresasService;

        public DistribuidorEmpresasController(IDistribuidorEmpresasService _distribuidorEmpresasService)
        {
            this.distribuidorEmpresasService = _distribuidorEmpresasService;
        }

        // GET: api/DistribuidorEmpresas
        public IQueryable<DistribuidorEmpresa> GetDistribuidorEmpresas()
        {
            return distribuidorEmpresasService.Get();
        }

        // GET: api/DistribuidorEmpresas/5
        [ResponseType(typeof(DistribuidorEmpresa))]
        public IHttpActionResult GetDistribuidorEmpresa(long id)
        {
            DistribuidorEmpresa distribuidorEmpresa = distribuidorEmpresasService.Get(id);
            if (distribuidorEmpresa == null)
            {
                return NotFound();
            }

            return Ok(distribuidorEmpresa);
        }

        // PUT: api/DistribuidorEmpresas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDistribuidorEmpresa(long id, DistribuidorEmpresa distribuidorEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != distribuidorEmpresa.Id)
            {
                return BadRequest();
            }

            try
            {
                distribuidorEmpresasService.Put(distribuidorEmpresa);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/DistribuidorEmpresas
        [ResponseType(typeof(DistribuidorEmpresa))]
        public IHttpActionResult PostDistribuidorEmpresa(DistribuidorEmpresa distribuidorEmpresa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            distribuidorEmpresa = distribuidorEmpresasService.Create(distribuidorEmpresa);

            return CreatedAtRoute("DefaultApi", new { id = distribuidorEmpresa.Id }, distribuidorEmpresa);
        }

        // DELETE: api/DistribuidorEmpresas/5
        [ResponseType(typeof(DistribuidorEmpresa))]
        public IHttpActionResult DeleteDistribuidorEmpresa(long id)
        {
            DistribuidorEmpresa distribuidorEmpresa;
            try
            {
                distribuidorEmpresa = distribuidorEmpresasService.Delete(id);
            }
            catch (NoEncontradoException)
            {
                return NotFound();
            }

            return Ok(distribuidorEmpresa);
        }
    }
}