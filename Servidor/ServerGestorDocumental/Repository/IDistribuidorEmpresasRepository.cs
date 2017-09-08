using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formulario.Repository
{
    public interface IDistribuidorEmpresasRepository
    {
        DistribuidorEmpresa Create(DistribuidorEmpresa distribuidorEmpresa);
        DistribuidorEmpresa Get(long id);
        IQueryable<DistribuidorEmpresa> Get();
        void Put(DistribuidorEmpresa distribuidorEmpresa);
        DistribuidorEmpresa Delete(long id);
    }
}
