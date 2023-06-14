using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SuperDigito
    {
        public static ML.Result SDByUsuario(string username)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JcervantesSicossContext context = new DL.JcervantesSicossContext())
                {
                    var query = context.SuperDigitos.FromSqlRaw($"SDByUsuario @Username", new SqlParameter("Username", username)).ToList();
                    result.Objects = new List<object>();

                    foreach (var row in query)
                    {
                        ML.SuperDigito superDigito = new ML.SuperDigito();
                        superDigito.Usuario = new ML.Usuario();

                        superDigito.IdSuperDigito = row.IdSuperDigito;
                        superDigito.Numero = row.Numero;
                        superDigito.Resultado = (int)row.Resultado;
                        superDigito.FechaHora = row.FechaHora.Value;

                        superDigito.Usuario.IdUsuario = row.IdUsuario.Value;
                        result.Objects.Add(superDigito);
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al traer el registro seleccionado" + ex;
            }

            return result;
        }


    }
}
