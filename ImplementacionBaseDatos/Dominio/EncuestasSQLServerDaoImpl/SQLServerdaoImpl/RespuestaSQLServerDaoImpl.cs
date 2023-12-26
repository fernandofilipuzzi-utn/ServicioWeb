using EncuestasDAO.DAO;
using EncuestasModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasSQLServerDaoImpl.SQLServerdaoImpl
{
    public class RespuestaSQLServerDaoImpl : IRespuestaDAO
    {

        public Respuesta Agregar(Respuesta Nuevo)
        {
            return null;
        }

        public Respuesta Actualizar(Respuesta Nuevo)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            //
        }

        public Respuesta BuscarPorId(int id)
        {
            return null;
        }

        public List<Respuesta> BuscarTodos()
        {
            return null;
        }
    }
}
