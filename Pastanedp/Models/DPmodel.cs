using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Pastanedp.Models
{
    public class DPmodel
    {
        public class DPModel
        {
            private static string conncetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pastane;Integrated Security=True;";


            public static void ExecuteWithoutReturn(string procadi, DynamicParameters param = null)
            {
                using (SqlConnection baglanti = new SqlConnection(conncetionString))
                {
                    baglanti.Open();
                    baglanti.Execute(procadi, param, commandType: CommandType.StoredProcedure);
                }
            }

            public static T ExecuteReturnScalar<T>(string procadi, DynamicParameters param = null)
            {
                using (SqlConnection baglanti = new SqlConnection(conncetionString))
                {
                    baglanti.Open();
                    return (T)Convert.ChangeType(baglanti.ExecuteScalar(procadi, param, commandType: CommandType.StoredProcedure),
                        typeof(T));
                }
            }
            public static IEnumerable<T> ReturnList<T>(string procadi, DynamicParameters param = null)
            {
                using (SqlConnection baglanti = new SqlConnection(conncetionString))
                {
                    baglanti.Open();
                    return baglanti.Query<T>(procadi, param, commandType: CommandType.StoredProcedure);
                }

            }
        }

    }
}
