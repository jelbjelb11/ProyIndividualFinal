using formulario.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace formulario.Servicios
{
    public class DistribuidorEmpresasService : IDistribuidorEmpresasService
    {
        private IDistribuidorEmpresasRepository perfilesUsuariosRepository;
        public DistribuidorEmpresasService(IDistribuidorEmpresasRepository _perfilesUsuariosRepository)
        {
            this.perfilesUsuariosRepository = _perfilesUsuariosRepository;
        }

        public DistribuidorEmpresa Get(long id)
        {
            return perfilesUsuariosRepository.Get(id);
        }

        public IQueryable<DistribuidorEmpresa> Get()
        {
            return perfilesUsuariosRepository.Get();
        }

        public DistribuidorEmpresa Create(DistribuidorEmpresa perfilesUsuario)
        {
            return perfilesUsuariosRepository.Create(perfilesUsuario);
        }

        public void Put(DistribuidorEmpresa perfilesUsuario)
        {
            perfilesUsuariosRepository.Put(perfilesUsuario);
        }

        public DistribuidorEmpresa Delete(long id)
        {
            return perfilesUsuariosRepository.Delete(id);
        }
    }
}