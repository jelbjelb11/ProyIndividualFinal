using formulario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario.Servicios
{
    public class ColeccionTiposService : IColeccionTiposService
    {
        private IColeccionTiposRepository coleccionTiposRepository;
        public ColeccionTiposService(IColeccionTiposRepository _coleccionTiposRepository)
        {
            this.coleccionTiposRepository = _coleccionTiposRepository;
        }

        public ColeccionTipo Get(long id)
        {
            return coleccionTiposRepository.Get(id);
        }

        public IQueryable<ColeccionTipo> Get()
        {
            return coleccionTiposRepository.Get();
        }

        public ColeccionTipo Create(ColeccionTipo coleccionTipo)
        {
            return coleccionTiposRepository.Create(coleccionTipo);
        }

        public void Put(ColeccionTipo coleccionTipo)
        {
            coleccionTiposRepository.Put(coleccionTipo);
        }

        public ColeccionTipo Delete(long id)
        {
            return coleccionTiposRepository.Delete(id);
        }
    }
}