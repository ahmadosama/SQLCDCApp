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

        public string DatabaseName { get; set; }
        public  string is_cdc_enabled { get; set; }
  
        
        /// <summary>
        /// returns a sql connection
        /// </summary>
        /// <returns></returns>
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
        public DataTable fn_GetDatabases()
        {
            
            try
            {
                DataTable dtdbs = fn_ExecuteReader("Select name,CASE is_cdc_enabled WHEN 0 Then 'False' WHEN 1 THEN 'True' END AS is_cdc_enabled from sys.databases where database_id>4 " +
                "and state_desc='Online' order by is_cdc_enabled desc ", "master");
                return dtdbs;
            }
            
           catch(Exception) 
            {
               throw;
            }
           
           
        }
        
        /// <summary>
        /// execute non query
        /// </summary>
        /// <param name="sqlqry"></param>
        /// <param name="DatabaseName"></param>
        /// <returns></returns>
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
            catch (Exception)
            {
               

                throw;
            }

            finally { _Sqlcon.Close(); }
        }


        public string fn_Executescalor(string sqlqry, string DatabaseName)
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
                string output = (string)SqlCmd.ExecuteScalar();

                return output;
            }
            catch (Exception)
            {


                throw;
            }

            finally { _Sqlcon.Close(); }
        }

        /// <summary>
        /// executes a query and returns a datatable
        /// </summary>
        /// <param name="sqlqry"></param>
        /// <param name="DatabaseName"></param>
        /// <returns></returns>
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
            catch(Exception)
            {
               

                throw;
            }
           
            
        }

        /// <summary>
        /// Returns list of all tables in a databases
        /// marks them as cdc enabled or not.
        /// </summary>
        /// <returns></returns>
        public DataSet fn_GetTables(List<string> Dblist)
        {
            
           
            try
            {
               
                DataSet ds = new DataSet();
                foreach (string db in Dblist)
                {
                       
                    DataTable dttbist = new DataTable();
                    string Qrygettables = " Select '" + db + "' AS DatabaseName,[schemaname]=ss.name,st.name, " +
                    "Case is_tracked_by_cdc WHEN 0 THEN 'False' WHEN 1 THEN 'True' END As is_tracked_by_cdc  " + 
                        " from sys.Tables st  " +
                        "  join sys.schemas ss on st.schema_id=ss.schema_id order by name";
                    dttbist = fn_ExecuteReader(Qrygettables, db);
                    ds.Tables.Add(dttbist); 
                }
                
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }

        
        }
        
        /// <summary>
        /// enables cdc on a table
        /// </summary>
        /// <param name="cdclist"></param>
        /// <param name="Enable"></param>
        /// <returns></returns>
        public string fn_EnableCDCOnTable(List<CDC> cdclist, bool Enable)
        {

            string QryEnableCdcOnTable = "";
            string returnmsg = "";
            try
            {
                foreach (CDC cdcobj in cdclist)
                {

                    if (Enable)
                    {
                        returnmsg = "CDC enabled on selected table.";
                        QryEnableCdcOnTable = "EXECUTE sys.sp_cdc_enable_table @source_schema = '" + cdcobj.source_schema + "' , @source_name = '" + cdcobj.source_name + "',";
                    }
                    else
                    {
                        returnmsg = "CDC disabled on selected table.";
                        QryEnableCdcOnTable = "EXECUTE sys.sp_cdc_disable_table @source_schema = '" + cdcobj.source_schema + "' , @source_name = '" + cdcobj.source_name + "'";
                    }
                    if (!string.IsNullOrEmpty(cdcobj.role_name))
                    {
                        QryEnableCdcOnTable += " @role_name = '" + cdcobj.role_name + "',";
                    }
                    else if (Enable)
                    {
                        QryEnableCdcOnTable += " @role_name =NULL,";
                    }
                    if (!string.IsNullOrEmpty(cdcobj.capture_instance))
                    {
                        QryEnableCdcOnTable = QryEnableCdcOnTable + " @capture_instance='" + cdcobj.capture_instance + "',";
                    }
                    else if (string.IsNullOrEmpty(cdcobj.capture_instance) && Enable == false)
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

                    fn_ExecuteQuery(QryEnableCdcOnTable.Substring(0, QryEnableCdcOnTable.Length - 1), cdcobj.Databasename);
                }

                return returnmsg;
            }catch(Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// returns cdc captureinstance 
        /// </summary>
        /// <param name="cdclist"></param>
        /// <returns></returns>
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
            catch (Exception)
            {
                throw;
            }

            finally
            {
                _Sqlcon.Close();
            }

        }
        
        /// <summary>
        /// returns change data
        /// </summary>
        /// <param name="ChangeDataType"></param>
        /// <param name="Databasename"></param>
        /// <param name="tablename"></param>
        /// <param name="captureinstance"></param>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <returns></returns>
        public DataTable fn_GetChangeData(int ChangeDataType,string Databasename,string tablename,string captureinstance,DateTime starttime,DateTime endtime)
        {
            string msg = "Table doesn't supports net changes";
            string _Qrygetalldata = "";
            DataTable result = new DataTable(); ;
            
            
             if(ChangeDataType==1)
            {
                // get all data

                 _Qrygetalldata = "Declare @start_lsn binary(10), " +
                                        "@end_lsn binary(10), " +
                                        "@capture_instance varchar(100) " +
           
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
                         _Qrygetalldata = "";
                         
                     }else
                         if(supports_net_changes>0)
                         {
                              _Qrygetalldata = "Declare @start_lsn binary(10), " +
                                        "@end_lsn binary(10), " +
                                        "@capture_instance varchar(100) " +
                                        "Set @start_lsn=sys.fn_cdc_get_min_lsn('" + captureinstance + "')" +
                                        "set @end_lsn = sys.fn_cdc_get_max_lsn(); " +
                                        "select *, CASE __$Operation When 1 THEN 'DELETE' WHEN  2 THEN 'INSERT' WHEN 3 THEN 'UPDATE BEFORE'  " +
                                        "WHEN 4 THEN 'UPDATE AFTER'  END AS Operation " +
                                        "from [cdc].[fn_cdc_get_net_changes_" + tablename + "](@start_lsn,@end_lsn,'all'); ";
                         }


                 }
                 else if (ChangeDataType == 3)
                 {
                     _Qrygetalldata = "DECLARE @begin_time datetime, @end_time datetime, @start_lsn binary(10), @end_lsn binary(10); " +
                                      "SET @begin_time = '" + starttime + "'" +
                                      "SET @end_time ='" + endtime + "'" +
                                      "SELECT @start_lsn = sys.fn_cdc_map_time_to_lsn('smallest greater than', @begin_time);" +
                                      "SELECT @end_lsn = sys.fn_cdc_map_time_to_lsn('largest less than or equal', @end_time);" +
                                      "select *, CASE __$Operation When 1 THEN 'DELETE'" +
                                      "WHEN  2 THEN 'INSERT'" +
                                      "WHEN 3 THEN 'UPDATE BEFORE'" +
                                      "WHEN 4 THEN 'UPDATE AFTER' END AS Operation" +
                                      " from [cdc].[fn_cdc_get_all_changes_" + tablename + "](@start_lsn,@end_lsn,'all')";
                 }
            try
            {
                if (_Qrygetalldata != "")
                {
                    result = fn_ExecuteReader(_Qrygetalldata, Databasename);
                }
                return result;

            }
            catch(SqlException)
            {
                throw;
            }
              
        }

        /// <summary>
        /// create destination table
        /// export data to destination table
        /// prepare meta data table for job schedule
        /// </summary>
        /// <param name="srctable"></param>
        /// <param name="desttable"></param>
        /// <param name="createtable"></param>
        /// <param name="DestDatabase"></param>
        public void fn_ExportToDB(DataTable srctable,string desttable,bool createtable,string DestDatabase)
        {
            DataTable tmpsrctable = srctable;
            if (tmpsrctable.Columns.Contains("__$start_lsn") == true)
            { 
                tmpsrctable.Columns.Remove("__$start_lsn");
            }
            if (tmpsrctable.Columns.Contains("__$seqval") == true)
            {
                tmpsrctable.Columns.Remove("__$seqval");
            }
            if (tmpsrctable.Columns.Contains("__$operation") == true)
            {
                tmpsrctable.Columns.Remove("__$operation");
            }
            if (tmpsrctable.Columns.Contains("__$update_mask") == true)
            {
                tmpsrctable.Columns.Remove("__$update_mask");
            }
         
                
            try
            {
                

                
                

                // create destination table if doesn't exists
                if(createtable)
                {
                    string sql = "CREATE TABLE [" + desttable + "] (";
                    // columns
                    foreach (DataColumn column in tmpsrctable.Columns)
                    {
                        //if (column.ColumnName != "__$start_lsn" && column.ColumnName != "__$seqval" && column.ColumnName != "__$operation" && column.ColumnName != "__$update_mask")
                        sql += "[" + column.ColumnName + "] " + SQLGetType(column) + ",";
                    }
                    sql = sql + " DateLastUpdated Datetime default(getdate()))";
                    //sql = sql.Substring(0,sql.Length-1) + ")";

                    fn_ExecuteQuery(sql, DestDatabase);

                }

               
                // bulk copy srctable into sql server
                SqlConnection _Sqlcon = fn_ConnecttoSQL();
                _Sqlcon.ChangeDatabase(DestDatabase);
                //_Sqlcon.BeginTransaction("CDCDataExport");
                
                using (SqlBulkCopy sbc = new SqlBulkCopy(_Sqlcon))
                    {
                        sbc.DestinationTableName=desttable;
                        foreach (var column in tmpsrctable.Columns)
                            sbc.ColumnMappings.Add(column.ToString(), column.ToString());
                        sbc.WriteToServer(srctable);
                    }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// maps .net datatype to sql datatype
        /// </summary>
        /// <param name="type"></param>
        /// <param name="columnSize"></param>
        /// <param name="numericPrecision"></param>
        /// <param name="numericScale"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Overload based on row from schema table
        /// </summary>
        /// <param name="schemaRow"></param>
        /// <returns></returns>
        public static string SQLGetType(DataRow schemaRow)
        {
            return SQLGetType(schemaRow["DataType"],
                                int.Parse(schemaRow["ColumnSize"].ToString()),
                                int.Parse(schemaRow["NumericPrecision"].ToString()),
                                int.Parse(schemaRow["NumericScale"].ToString()));
        }
        
        /// <summary>
        /// // Overload based on DataColumn from DataTable type
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string SQLGetType(DataColumn column)
        {
            return SQLGetType(column.DataType, column.MaxLength, 10, 2);
        }

        public void fn_CreateMetaTables(string srcserver, string destserver,string srcdb,string destdb,string srctable,string desttable,string captureinstance)
        {
            string _sqlqrycreatetable ="if not exists(select 1 from sys.schemas where name ='sqlcdcapp')"+
            " BEGIN " +
	        " EXEC('CREATE SCHEMA sqlcdcapp authorization dbo') " +
            " END " + 
            " if (object_id('sqlcdcapp.connection_details')) is null " +
            " BEGIN " +
            " CREATE TABLE sqlcdcapp.connection_details ( " +
            " Cnid int identity Primary Key,srcserver varchar(50), destserver varchar(50), srcdb varchar(50), " +
            " destdb varchar(50), srctable varchar(100), desttable varchar(100)) END ";

            _sqlqrycreatetable = _sqlqrycreatetable + System.Environment.NewLine +" if (object_id('sqlcdcapp.IDLoad')) is null  " +
            " BEGIN " +
            " Create table sqlcdcapp.IDLoad (" +
            " sd_id int identity Primary Key,  cnid int, captureinstance varchar(100),recordcount int, srclaststartlsn nvarchar(42), " +
            " srclastsyncdate datetime,srcsynclogin varchar(100)) end ";

            string _sqlqrygetmaxlsn = " DECLARE @start_lsn BINARY(10),@end_lsn BINARY(10),@reccount int ,@maxlsn nvarchar(42) " +
                                      " SET @start_lsn=sys.Fn_cdc_get_min_lsn('" + captureinstance + "') " +
                                      " SET @end_lsn = sys.Fn_cdc_get_max_lsn() " +
                                      " SELECT @maxlsn=UPPER(sys.fn_varbintohexstr(MAX(__$start_lsn))),@reccount=COUNT(*) " +
                                      " FROM [cdc].[fn_cdc_get_net_changes_" + srctable + "](@start_lsn, @end_lsn, 'all') " +
                                      System.Environment.NewLine;
                                        
            string _sqlqryinsert = _sqlqrygetmaxlsn +  " if not exists(select 1 from sqlcdcapp.connection_details "+
            " where srcserver='" + srcserver + "' and destserver='" + destserver + "' and srcdb='" + srcdb + "' and srctable='" + srctable.Replace("_",".") + "' and desttable='" + desttable + "') " +
            " begin " +
            " INSERT INTO sqlcdcapp.connection_details " +
            " OUTPUT INSERTED.Cnid,'" + captureinstance + "',@reccount,@maxlsn,getdate(),SUSER_NAME() into sqlcdcapp.IDLoad" +
            " VALUES ('" + srcserver + "','" + destserver + "','" + srcdb + "','"
                + destdb + "','" + srctable.Replace("_", ".") + "','" + desttable + "') END ";

            _sqlqrycreatetable = _sqlqrycreatetable + _sqlqryinsert;
            fn_ExecuteQuery(_sqlqrycreatetable, srcdb);



        }
        
    }

   public class Tables
    {
        public string Databasename { get; set; }
        public string schema { get; set; }
        public string name { get; set; }
        public string is_tracked_by_cdc { get; set; }
        public bool _primary_key_enabled { get; set; }

        public Tables()
        { }

        public Tables(string Database,string name)
        {
            SQLCDCApp obj = new SQLCDCApp();
            string _sqlqry="SELECT 'true' FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE OBJECTPROPERTY(OBJECT_ID(constraint_name), 'IsPrimaryKey') = 1 " +
            " AND table_name ='" + name + "'";
            string output = obj.fn_Executescalor(_sqlqry, Database);
            if(string.IsNullOrEmpty(output))
            {
                this._primary_key_enabled = false;
            }else
            {
                this._primary_key_enabled = true;
            }
           

        }
        

    }

   public class CDC: Tables
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