using EncuestasClassLib.Models;
using EncuestasModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasDAO.DAO
{
    public interface IRespuestaDAO
    {
        Respuesta Agregar(Respuesta Nuevo);
        Respuesta Actualizar(Respuesta Nuevo);
        void EliminarNuevo(int id);
        Respuesta BuscarPorId(int id);
        List<Respuesta> BuscarTodos();

    }
}
