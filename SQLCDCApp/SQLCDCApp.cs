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
        
        public string ServerName;
        public string UserName;
        public string AuthenticationType;
        public string Password;
        //public bool connect { get; set; }
        private SqlConnection SQLCon { get; set; }
        public string DatabaseName { get; set; }
        public  string is_cdc_enabled { get; set; }
       

        /// <summary>
        /// Connects to sql server
        /// returns true when successfull
        /// </summary>
        /// <returns></returns>
        private SqlConnection fn_connecttosql()
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
                SQLCon = _sqlcon;
                return SQLCon;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public List<SQLCDCApp> fn_GetDatabases()
        {
            List<SQLCDCApp> _listdatabases= new List<SQLCDCApp>();
            
            SQLCon = fn_connecttosql();
           try
            {
                if(SQLCon.State.ToString()=="Closed")
            {
                SQLCon.Open();
            }

            SqlCommand SQLGetDatabases = new SqlCommand("Select name,is_cdc_enabled from sys.databases where database_id>4 and state_desc='Online'", SQLCon);
            SqlDataReader Datareader;
            Datareader=SQLGetDatabases.ExecuteReader();
            while(Datareader.Read())
            {
                SQLCDCApp obj = new SQLCDCApp();
                obj.DatabaseName = Datareader[0].ToString();
                obj.is_cdc_enabled = Datareader[1].ToString();
                //obj.state = Datareader[2].ToString();
                _listdatabases.Add(obj);
            }

            return _listdatabases;
            }
           catch(Exception) 
            {
               throw;
            }
           
            finally{
                SQLCon.Close();
            }
        }
        
        public bool fn_EnableCDC(List<string> ListDbtoEnableCDC)
        {

            try
            {
                if (SQLCon.State.ToString() == "Closed")
                {
                    SQLCon.Open();
                }
                foreach (string db in ListDbtoEnableCDC)
                {
                    SQLCon.ChangeDatabase(db);
                    SqlCommand SqlCmd = new SqlCommand("Exec sp_cdc_enable_db ", SQLCon);
                    SqlCmd.ExecuteReader();
                }
                return true;
            }
            catch(Exception)
            {
                return false;

                throw;
            }
            
        }

    }
}
