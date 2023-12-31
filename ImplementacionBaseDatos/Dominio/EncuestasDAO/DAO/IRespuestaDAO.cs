﻿using EncuestasNuevoModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncuestasDAO.DAO
{
    public interface IRespuestaDAO
    {
        Respuesta Agregar(Respuesta nueva,Encuesta aDondePertenece);
        void Actualizar(Respuesta actual);
        void Eliminar(int id);
        Respuesta BuscarPorId(int id);
        List<Respuesta> BuscarTodos();
        List<Respuesta> BuscarPorIdEncuesta(int idEncuesta);
    }
}
