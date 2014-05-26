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
            catch (Exception ex)
            {
                throw ex;
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
           catch(Exception ex) 
            {
               throw ex;
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
                SqlCmd.ExecuteNonQuery();
                
                return true;
            }
            catch (Exception ex)
            {
               

                throw ex;
            }

            finally { _Sqlcon.Close(); }
        }

        private DataTable fn_ExecuteReader(string sqlqry, string DatabaseName)
        {
            SqlConnection _Sqlcon = new SqlConnection();
            SqlDataReader dr ;
            //IENumerableExtensions ie;
            _Sqlcon = fn_ConnecttoSQL();
            try
            {

                if (_Sqlcon.State.ToString() == "Closed")
                {
                    _Sqlcon.Open();
                }

                
                 _Sqlcon.ChangeDatabase(DatabaseName);
                SqlCommand SqlCmd = new SqlCommand(sqlqry, _Sqlcon);
                dr=SqlCmd.ExecuteReader();

                var dt = new DataTable();
                dt.Load(dr);
             
                return dt;
                

            }
            catch (SqlException ex)
            {
                throw;
            }

          //  finally { _Sqlcon.Close(); }
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
            catch(Exception ex)
            {
               

                throw ex;
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
                    string Qrygettables = "Select '" + db + "',[schemaname]=ss.name,st.name,is_tracked_by_cdc from sys.Tables st  " +
                        "join sys.schemas ss on st.schema_id=ss.schema_id order by name";
                    SqlCommand SQLGetDatabases = new SqlCommand(Qrygettables, _Sqlcon);
                    
                    Datareader = SQLGetDatabases.ExecuteReader();
                    while (Datareader.Read())
                    {
                        Tables _tb = new Tables();
                        _tb.Databasename = Datareader[0].ToString();
                        _tb.schema = Datareader[1].ToString();
                       _tb.name = Datareader[2].ToString();
                       _tb.is_tracked_by_cdc = Datareader[3].ToString();
                        _listtables.Add(_tb);
                    }
                    Datareader.Close();
                }
                
                return _listtables;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            finally
            {
                
                _Sqlcon.Close();
            }
        }

        public string fn_EnableCDCOnTable(List<CDC> cdclist,bool Enable)
        {
            string QryEnableCdcOnTable = "";
            string returnmsg = "";
            foreach (CDC cdcobj in cdclist)
            {

                if (Enable)
                {
                    returnmsg = "CDC enabled on selected table.";
                    QryEnableCdcOnTable = "EXECUTE sys.sp_cdc_enable_table @source_schema = '" + cdcobj.source_schema + "' , @source_name = '" + cdcobj.source_name + "',";
                }else
                {
                    returnmsg = "CDC disabled on selected table.";
                    QryEnableCdcOnTable = "EXECUTE sys.sp_cdc_disable_table @source_schema = '" + cdcobj.source_schema + "' , @source_name = '" + cdcobj.source_name + "'";
                }
                if(!string.IsNullOrEmpty(cdcobj.role_name))
                {
                    QryEnableCdcOnTable+= " @role_name = '" + cdcobj.role_name + "',";
                }else if(Enable)
                {
                    QryEnableCdcOnTable += " @role_name =NULL,";
                }
                if (!string.IsNullOrEmpty(cdcobj.capture_instance))
                {
                    QryEnableCdcOnTable = QryEnableCdcOnTable + " @capture_instance='" + cdcobj.capture_instance + "',";
                }else if(string.IsNullOrEmpty(cdcobj.capture_instance) && Enable==false)
                {
                    QryEnableCdcOnTable = QryEnableCdcOnTable + " ,@capture_instance='all',";
                }
                if (!string.IsNullOrEmpty(cdcobj.index_name))
                {
                    QryEnableCdcOnTable = QryEnableCdcOnTable + " @index_name='" + cdcobj.index_name + "',";
                }

                if (!string.IsNullOrEmpty(cdcobj.captured_column_list))
                {
                    QryEnableCdcOnTable = QryEnableCdcOnTable + " @captured_column_list='" + cdcobj.captured_column_list + "',";
                }

                if (!string.IsNullOrEmpty(cdcobj.filegroup_name))
                {
                    QryEnableCdcOnTable = QryEnableCdcOnTable + " @filegroup_name='" + cdcobj.filegroup_name + "',";
                }
            
                if (cdcobj.supports_net_changes == 1)
                {
                    QryEnableCdcOnTable = QryEnableCdcOnTable + " @supports_net_changes='" + cdcobj.supports_net_changes + "',";
                }
                if (cdcobj.allow_partition_switch == 1)
                {
                    QryEnableCdcOnTable = QryEnableCdcOnTable + " @allow_partition_switch='" + cdcobj.allow_partition_switch + "',";
                }

                fn_ExecuteQuery(QryEnableCdcOnTable.Substring(0,QryEnableCdcOnTable.Length-1), cdcobj.Databasename);
            }

            return returnmsg;
        } 

        public List<string> fn_CaptureInstance(List<CDC> cdclist)
        {
            List<string> lst = new List<string>();
            SqlConnection _Sqlcon = new SqlConnection();
            SqlDataReader Datareader; 
            _Sqlcon = fn_ConnecttoSQL();
            try
            {
                if (_Sqlcon.State.ToString() == "Closed")
                {
                    _Sqlcon.Open();
                }

                foreach(CDC cdcobj in cdclist)
                {
                    _Sqlcon.ChangeDatabase(cdcobj.Databasename);
                    string Qry= "Select capture_instance from cdc.change_tables where source_object_id=object_id('" + cdcobj.source_schema + "." + cdcobj.source_name + "')";
                    SqlCommand sqlcmd = new SqlCommand(Qry, _Sqlcon);
                    Datareader=sqlcmd.ExecuteReader();
                    while (Datareader.Read())
                    {
                        lst.Add(Datareader[0].ToString());
                    }

                    lst.Add(cdcobj.source_schema + "_" + cdcobj.source_name);
                    lst.Add(cdcobj.Databasename);
                    
                }

                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _Sqlcon.Close();
            }

        }
     
        public DataTable fn_GetChangeData(int ChangeDataType,string Databasename,string tablename,string captureinstance,DateTime starttime,DateTime endtime)
        {
            string msg = "Table doesn't supports net changes";
            string _Qrygetalldata = "";
            DataTable result = new DataTable(); ;
            //DataRow drow = new DataRow()
            // return all records
             if(ChangeDataType==1)
            {
                // get all data

                 _Qrygetalldata = "Declare @start_lsn binary(10), " +
                                        "@end_lsn binary(10), " +
                                        "@capture_instance varchar(100) " +
                    //  "Select @capture_instance=capture_instance from cdc.change_tables where source_object_id=object_id('" + tablename + "')" +
                                        "Set @start_lsn=sys.fn_cdc_get_min_lsn('" + captureinstance + "')" +
                                        "set @end_lsn = sys.fn_cdc_get_max_lsn(); " +
                                        "select *, CASE __$Operation When 1 THEN 'DELETE' WHEN  2 THEN 'INSERT' WHEN 3 THEN 'UPDATE BEFORE'  " +
                                        "WHEN 4 THEN 'UPDATE AFTER'  END AS Operation " +
                                        "from [cdc].[fn_cdc_get_all_changes_" +  tablename + "](@start_lsn,@end_lsn,'all'); ";

               
            }else 
                 if(ChangeDataType == 2)
                 {
                     // check if it's enabled for net changes
                     Int32 supports_net_changes=-1;
                     string _sqlqry = "select supports_net_changes from cdc.change_tables where capture_instance='" + captureinstance + "'";
                     DataTable dt = fn_ExecuteReader(_sqlqry, Databasename);
                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                          supports_net_changes = Convert.ToInt32(dt.Rows[i]["supports_net_changes"]);
                         
                     }
                     if (supports_net_changes == 0)
                     {
                         
                         DataColumn col = new DataColumn("Message");
                         col.DefaultValue = msg;
                         DataRow drow = result.NewRow();
                         result.Columns.Add(col);
                         result.Rows.Add(drow);
                         
                     }else
                         if(supports_net_changes>0)
                         {
                              _Qrygetalldata = "Declare @start_lsn binary(10), " +
                                        "@end_lsn binary(10), " +
                                        "@capture_instance varchar(100) " +
                    //  "Select @capture_instance=capture_instance from cdc.change_tables where source_object_id=object_id('" + tablename + "')" +
                                        "Set @start_lsn=sys.fn_cdc_get_min_lsn('" + captureinstance + "')" +
                                        "set @end_lsn = sys.fn_cdc_get_max_lsn(); " +
                                        "select *, CASE __$Operation When 1 THEN 'DELETE' WHEN  2 THEN 'INSERT' WHEN 3 THEN 'UPDATE BEFORE'  " +
                                        "WHEN 4 THEN 'UPDATE AFTER'  END AS Operation " +
                                        "from [cdc].[fn_cdc_get_all_changes_" + tablename + "](@start_lsn,@end_lsn,'all'); ";
                         }
                         

                 }else if(ChangeDataType==3)
                 {
                     _Qrygetalldata = "DECLARE @begin_time datetime, @end_time datetime, @start_lsn binary(10), @end_lsn binary(10); " +
                                      "SET @begin_time = '" + starttime + "'" +
                                      "SET @end_time ='" + endtime + "'" +
                                      "SELECT @start_lsn = sys.fn_cdc_map_time_to_lsn('smallest greater than', @begin_time);" +
                                      "SELECT @end_lsn = sys.fn_cdc_map_time_to_lsn('largest less than or equal', @end_time);"+
                                      "select *, CASE __$Operation When 1 THEN 'DELETE'" +
	                                  "WHEN  2 THEN 'INSERT'" +
	                                  "WHEN 3 THEN 'UPDATE BEFORE'" +
	                                  "WHEN 4 THEN 'UPDATE AFTER' END AS Operation"+
                                      " from [cdc].[fn_cdc_get_all_changes_" + tablename + "](@start_lsn,@end_lsn,'all')";
                 }
            


            try
            {
                result = fn_ExecuteReader(_Qrygetalldata, Databasename);
                
                return result;

            }
            catch(SqlException ex)
            {
                throw;
            }
              
        }

        public void fn_ExportToDB(DataTable srctable,string desttable,bool createtable,string DestDatabase)
        {
            try
            {
                // create destination table if doesn't exists
                if(createtable)
                {
                    string sql = "CREATE TABLE [" + desttable + "] (";
                    // columns
                    foreach (DataColumn column in srctable.Columns)
                    {
                        sql += "[" + column.ColumnName + "] " + SQLGetType(column) + ",";
                    }
                    sql = sql.Substring(0,sql.Length-1) + ")";

                    fn_ExecuteQuery(sql, DestDatabase);

                }


                // bulk copy srctable into sql server
                SqlConnection _Sqlcon = fn_ConnecttoSQL();
                _Sqlcon.ChangeDatabase(DestDatabase);
                using (SqlBulkCopy sbc = new SqlBulkCopy(_Sqlcon))
                    {
                        sbc.DestinationTableName=desttable;
                        foreach (var column in srctable.Columns)
                            sbc.ColumnMappings.Add(column.ToString(), column.ToString());
                        sbc.WriteToServer(srctable);
                    }
                
            }
            catch (Exception)
            {
                throw;
            }
        }


     

        public static string SQLGetType(object type, int columnSize, int numericPrecision, int numericScale)
        {
            switch (type.ToString())
            {
                case "System.String":
                    return "VARCHAR(" + ((columnSize == -1) ? "255" : (columnSize > 8000) ? "MAX" : columnSize.ToString()) + ")";

                case "System.Decimal":
                    if (numericScale > 0)
                        return "REAL";
                    else if (numericPrecision > 10)
                        return "BIGINT";
                    else
                        return "INT";

                case "System.Double":
                case "System.Single":
                    return "REAL";

                case "System.Int64":
                    return "BIGINT";

                case "System.Int16":
                case "System.Int32":
                    return "INT";

                case "System.DateTime":
                    return "DATETIME";

                case "System.Boolean":
                    return "BIT";

                case "System.Byte":
                    return "TINYINT";

                case "System.Guid":
                    return "UNIQUEIDENTIFIER";

                default:
                    throw new Exception(type.ToString() + " not implemented.");
            }
        }

        // Overload based on row from schema table
        public static string SQLGetType(DataRow schemaRow)
        {
            return SQLGetType(schemaRow["DataType"],
                                int.Parse(schemaRow["ColumnSize"].ToString()),
                                int.Parse(schemaRow["NumericPrecision"].ToString()),
                                int.Parse(schemaRow["NumericScale"].ToString()));
        }
        // Overload based on DataColumn from DataTable type
        public static string SQLGetType(DataColumn column)
        {
            return SQLGetType(column.DataType, column.MaxLength, 10, 2);
        }
    }


    public class Tables
    {
        public string Databasename { get; set; }
        public string schema { get; set; }
        public string name { get; set; }
        public string is_tracked_by_cdc { get; set; }

    }

   public class CDC:Tables
    {
      
         
        public string source_schema { get; set; }
        public string source_name { get; set; }
        public string capture_instance { get; set; }
        public byte supports_net_changes { get; set; }
        public string role_name { get; set; }
        public string index_name { get; set; }
        public string captured_column_list { get; set; }
        public string filegroup_name { get; set; }
        public byte allow_partition_switch { get; set; }
        public List<CDC> cdclist { get; set; }
        


    }

}