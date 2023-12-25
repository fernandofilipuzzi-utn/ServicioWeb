
using EncuestasModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasDAO.DAO
{
    public interface IEncuestaDAO
    {
        Encuesta Agregar(Encuesta Nuevo);
        Encuesta Actualizar(Encuesta Nuevo);
        void EliminarNuevo(int id);
        //
        Encuesta BuscarPorId(int id);
        List<Encuesta> BuscarTodos();

        Encuesta BuscarUltimaEncuestaNoCerrada();
    }
}
