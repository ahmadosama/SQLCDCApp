using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SQLCDCApp
{
    class SQLCDCApp
    {
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string AuthenticationType { get; set; }
        public string Password { get; set; }
        public bool connect { get; set; }
        

        /// <summary>
        /// Connects to sql server
        /// returns true when successfull
        /// </summary>
        /// <returns></returns>
        public bool fn_connecttosql()
        {
            string _ConnectionString="";
            try
            {
                if (AuthenticationType == "Windows")
                {
                    _ConnectionString = "Initial Catalog=master;Data Source=" + ServerName + ";Integrated Security=True;";
                }
                else
                {
                    _ConnectionString = "Initial Catalog=master;Data Source=" + ServerName + ";user id=" + UserName + ";password=" + Password;
                }
             
                SqlConnection _sqlcon = new SqlConnection();
                _sqlcon.ConnectionString = _ConnectionString;
                _sqlcon.Open();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


    }
}
