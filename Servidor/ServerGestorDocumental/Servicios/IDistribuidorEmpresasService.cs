using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formulario.Servicios
{
    public interface IDistribuidorEmpresasService
    {
        DistribuidorEmpresa Create(DistribuidorEmpresa perfilesUsuario);
        DistribuidorEmpresa Get(long id);
        IQueryable<DistribuidorEmpresa> Get();
        void Put(DistribuidorEmpresa perfilesUsuario);
        DistribuidorEmpresa Delete(long id);
    }
}
