using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pagina.Models.DAO
{
    public interface DAO<T>
    {
        void Crear(T d);
        T Obtener(int id);
        List<T> ObtenerTodas();
        void Actualizar(T d);
        void Borrar(T d);
    }
}