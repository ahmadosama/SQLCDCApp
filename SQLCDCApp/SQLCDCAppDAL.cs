using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace SQLCDCApp
{
    class SQLCDCAppDAL
    {
       public string Connectionstring;
       
       public SQLCDCAppDAL()
       {
       //    Connectionstring = _connectionstring;
       }

       /// <summary>
       /// overrides sqlcommand.executenonquery
       /// </summary>
       /// <param name="Query"></param>
       /// <param name="Connectionstring"></param>
       public void fn_ExecuteQuery(string Query,string Connectionstring)
       {
           try
           {
               using (SqlConnection _Sqlcon = new SqlConnection(Connectionstring))
               {
                   _Sqlcon.Open();
                   SqlCommand SqlCmd = new SqlCommand(Query, _Sqlcon);
                   SqlCmd.ExecuteNonQuery();
               }
           }
           catch (Exception)
           {
               throw;
           }
       }
        
       /// <summary>
       /// returns query results in a datatable
       /// </summary>
       /// <param name="Query"></param>
       /// <param name="Connectionstring"></param>
       /// <returns></returns>
       public DataTable fn_ExecuteQuery(string Query, string Connectionstring)
       {
         try
           {
               using (SqlConnection _Sqlcon = new SqlConnection(Connectionstring))
               {
                   _Sqlcon.Open();
                   SqlCommand SqlCmd = new SqlCommand(Query, _Sqlcon);
                   SqlDataReader dr = SqlCmd.ExecuteReader();

                   var dt = new DataTable();
                   dt.Load(dr);

                   return dt;
               }
           }
           catch (Exception)
           {
               throw;
           }
       }

       /// <summary>
       /// returns query result as a string
       /// </summary>
       /// <param name="Query"></param>
       /// <param name="Connectionstring"></param>
       /// <returns></returns>
       public string fn_ExecuteQuery(string Query, string Connectionstring)
       {
           try
           {
               using (SqlConnection _Sqlcon = new SqlConnection(Connectionstring))
               {
                   _Sqlcon.Open();
                   SqlCommand SqlCmd = new SqlCommand(Query, _Sqlcon);
                   string output = (string)SqlCmd.ExecuteScalar();
                   return output;
               }
           }
           catch (Exception)
           {
               throw;
           }
       }
    }
}
