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
    
    /// <summary>
    /// Main logic is here
    /// </summary>
    class SQLCDCApp
    {

        
        //public bool connect { get; set; }
        public string DatabaseName { get; set; }
        public  string is_cdc_enabled { get; set; }
       
        public SqlConnection fn_ConnecttoSQL()
        {
           
            string _ConnectionString = "";
            try
            {
                if (Settings1.Default.AuthenticationType == "Windows")
                {
                    _ConnectionString = "Initial Catalog=master;Data Source=" + Settings1.Default.Server + ";Integrated Security=True;";
                }
                else
                {
                    _ConnectionString = "Initial Catalog=master;Data Source=" + Settings1.Default.Server + ";user id=" + Settings1.Default.User + ";password=" + Settings1.Default.Password;
                }

                SqlConnection _sqlcon = new SqlConnection();
                _sqlcon.ConnectionString = _ConnectionString;
                _sqlcon.Open();
                return _sqlcon;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Connects to sql server
        /// returns true when successfull
        /// </summary>
        /// <returns></returns>
        
        public List<SQLCDCApp> fn_GetDatabases()
        {
            List<SQLCDCApp> _listdatabases= new List<SQLCDCApp>();
            SqlConnection _Sqlcon = new SqlConnection();
            _Sqlcon = fn_ConnecttoSQL();
           try
           {
               if (_Sqlcon.State.ToString() == "Closed")
            {
                _Sqlcon.Open();
            }

               SqlCommand SQLGetDatabases = new SqlCommand("Select name,is_cdc_enabled from sys.databases where database_id>4 and state_desc='Online' order by is_cdc_enabled desc ", _Sqlcon);
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
                _Sqlcon.Close();
            }
        }
        
        private bool fn_ExecuteQuery(string sqlqry,string DatabaseName)
        {
            SqlConnection _Sqlcon = new SqlConnection();
            _Sqlcon = fn_ConnecttoSQL();
            try
            {

                if (_Sqlcon.State.ToString() == "Closed")
                {
                    _Sqlcon.Open();
                }

                _Sqlcon.ChangeDatabase(DatabaseName);
                SqlCommand SqlCmd = new SqlCommand(sqlqry, _Sqlcon);
                SqlCmd.ExecuteReader();
                
                return true;
            }
            catch (Exception)
            {
                return false;

                throw;
            }

            finally { _Sqlcon.Close(); }
        }

        /// <summary>
        /// Enable CDC on selected databases
        /// </summary>
        /// <param name="ListDbtoEnableCDC"></param>
        /// <returns></returns>
        public bool fn_ConfigureCDC(List<string> ListDbtoEnableCDC,bool Enable)
        {
            string sqlqry;
            if(Enable)
            {
                sqlqry="Exec sp_cdc_enable_db ";
            }
            else
            {
                sqlqry = "Exec sp_cdc_disable_db ";
            }
            try
            {
                foreach (string db in ListDbtoEnableCDC)
                {
                    fn_ExecuteQuery (sqlqry, db);
                    
                }
                return true;
            }
            catch(Exception)
            {
                return false;

                throw;
            }
           
            
        }

        /// <summary>
        /// Returns list of all tables in a databases
        /// marks them as cdc enabled or not.
        /// </summary>
        /// <returns></returns>
        public List<Tables> fn_GetTables(List<string> Dblist)
        {
            
            List<Tables> _listtables = new List<Tables>();
            SqlConnection _Sqlcon = new SqlConnection();
            SqlDataReader Datareader;
            _Sqlcon = fn_ConnecttoSQL();
            try
            {
                if (_Sqlcon.State.ToString() == "Closed")
                {
                    _Sqlcon.Open();
                }

                foreach (string db in Dblist)
                {
                    _Sqlcon.ChangeDatabase(db);
                    string Qrygettables = "Select '" + db + "',name,is_tracked_by_cdc from sys.Tables order by is_tracked_by_cdc desc";
                    SqlCommand SQLGetDatabases = new SqlCommand(Qrygettables, _Sqlcon);
                    
                    Datareader = SQLGetDatabases.ExecuteReader();
                    while (Datareader.Read())
                    {
                        Tables _tb = new Tables();
                        _tb.Databasename = Datareader[0].ToString();
                        _tb.name = Datareader[1].ToString();
                        _tb.is_tracked_by_cdc = Datareader[2].ToString();
                        _listtables.Add(_tb);
                    }
                    Datareader.Close();
                }
                
                return _listtables;
            }
            catch (Exception)
            {
                
                throw;
            }

            finally
            {
                
                _Sqlcon.Close();
            }
        }

    }

    class Tables
    {
        public string Databasename { get; set; }
        public string name { get; set; }
        public string is_tracked_by_cdc { get; set; }

    }

    class CDC
    {
        /*
         [ @source_schema = ] 'source_schema', 
  [ @source_name = ] 'source_name' ,
  [,[ @capture_instance = ] 'capture_instance' ]
  [,[ @supports_net_changes = ] supports_net_changes ]
  , [ @role_name = ] 'role_name'
  [,[ @index_name = ] 'index_name' ]
  [,[ @captured_column_list = ] 'captured_column_list' ]
  [,[ @filegroup_name = ] 'filegroup_name' ]
  [,[ @allow_partition_switch = ] 'allow_partition_switch' ]
  [;]
         */
        public string source_schema { get; set; }
        public string source_name { get; set; }
        public string capture_instance { get; set; }
        public string supports_net_changes { get; set; }
        public string role_name { get; set; }
        public string index_name { get; set; }
        public string captured_column_list { get; set; }
        public string filegroup_name { get; set; }
        public string allow_partition_switch { get; set; }


    }
}
