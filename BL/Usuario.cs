using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result UsuarioAdd(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JcervantesSicossContext context = new DL.JcervantesSicossContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UsuarioAdd '{usuario.Username}', @Password", new SqlParameter("Password", usuario.Password));
                    if(query != 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al agregar al Usuario" + ex;
            }
            return result; 
        }

        

    }
}
