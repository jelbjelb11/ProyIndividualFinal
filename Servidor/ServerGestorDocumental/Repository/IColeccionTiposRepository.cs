using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace formulario.Repository
{
    public interface IColeccionTiposRepository
    {
        ColeccionTipo Create(ColeccionTipo coleccionTipo);
        ColeccionTipo Get(long id);
        IQueryable<ColeccionTipo> Get();
        void Put(ColeccionTipo coleccionTipo);
        ColeccionTipo Delete(long id);
    }
}
