using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Security.Cryptography;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Crypto;
using SQLDBManager;
namespace SQLCDCApp
{
    
 
    class SQLCDCApp
    {

        public string DatabaseName { get; set; }
        public  string is_cdc_enabled { get; set; }
        
        public bool fn_SQLAgentStatusCheck()
        {
            QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true), "master", Settings1.Default.AuthenticationType);
        
            string _sqlagentcheckqry = "select '1' from sys.sysprocesses where program_name = N'SQLAgent - Generic Refresher'";
            string output = _qe.fn_ExecuteScalor(_sqlagentcheckqry);
            bool result=false;
            if(output=="1")
            {
                result = true;
            }


            return result;
        }

        /// <summary>
        /// Connects to sql server
        /// returns true when successfull
        /// </summary>
        /// <returns></returns>
        public DataTable fn_GetDatabases(string where)
        {
            QueryExecution _qe = new QueryExecution();
            if(where=="source")
            {
                 _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
                  "master", Settings1.Default.AuthenticationType);
            }else
                if(where=="destination")
                {
                     _qe = new QueryExecution(Settings1.Default.Destserver, Settings1.Default.Destuser, Crypto.Crypto.Decrypt(Settings1.Default.Destpassword, true),
                  "master", Settings1.Default.Destauthtype);
                }
            try
            {
                Genericsql _gs = new Genericsql();
                DataTable dtdbs=_gs.databaselist(_qe);
                return dtdbs;
            }
            
           catch(Exception) 
            {
               throw;
            }
           
           
        }
        
        /// <summary>
        /// Enable CDC on selected databases
        /// </summary>
        /// <param name="ListDbtoEnableCDC"></param>
        /// <returns></returns>
        public bool fn_ConfigureCDC(List<string> ListDbtoEnableCDC,bool Enable)
        {
            string _sqlqry;
           
            if(Enable)
            {
                _sqlqry="Exec sp_cdc_enable_db ";
            }
            else
            {
                _sqlqry = "Exec sp_cdc_disable_db ";
            }
            try
            {
                foreach (string db in ListDbtoEnableCDC)
                {
                    //fn_ExecuteQuery (_sqlqry, db);
                    QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
                                db, Settings1.Default.AuthenticationType);
                    _qe.fn_ExecuteQuery(_sqlqry);
                    
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
        public DataSet fn_GetTables(List<string> Dblist,string srv="Source")
        {
            
            try
            {
                QueryExecution _qe = new QueryExecution();
                DataSet _ds = new DataSet();
                foreach (string db in Dblist)
                {
                       
                    DataTable _dttbist = new DataTable();
                    string _Qrygettables = " Select '" + db + "' AS DatabaseName,[schemaname]=ss.name,st.name, " +
                    "Case is_tracked_by_cdc WHEN 0 THEN 'False' WHEN 1 THEN 'True' END As is_tracked_by_cdc  " + 
                        " from sys.Tables st  " +
                        "  join sys.schemas ss on st.schema_id=ss.schema_id order by name";
                  
                    if (srv == "Destination")
                    {
                         _qe = new QueryExecution(Settings1.Default.Destserver, Settings1.Default.Destuser, 
                             Crypto.Crypto.Decrypt(Settings1.Default.Destpassword, true),db, Settings1.Default.Destauthtype);
                    }
                    else
                    {
                         _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, 
                             Crypto.Crypto.Decrypt(Settings1.Default.Password, true),db, Settings1.Default.AuthenticationType);
                    }

                    _dttbist = _qe.fn_ExecuteTable(_Qrygettables);
                    _ds.Tables.Add(_dttbist); 
                }
                
                return _ds;
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

                    QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
    cdcobj.Databasename, Settings1.Default.AuthenticationType);
                    _qe.fn_ExecuteQuery(QryEnableCdcOnTable.Substring(0, QryEnableCdcOnTable.Length - 1));
                    // update meta table

                }
               // update meta data tables
                fn_disablecaptureinstance(cdclist);
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
            try
            {
                foreach(CDC cdcobj in cdclist)
                {
                    //_Sqlcon.ChangeDatabase(cdcobj.Databasename);
                    string _qry= "Select capture_instance from cdc.change_tables where source_object_id= " + 
                        " object_id('" + cdcobj.source_schema + "." + cdcobj.source_name + "')";
                    QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
    cdcobj.Databasename, Settings1.Default.AuthenticationType);
                    DataTable _dt = _qe.fn_ExecuteTable(_qry);
                    
                    foreach (DataRow _dr in _dt.Rows)
                    {
                        lst.Add(_dr[0].ToString());
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
        public DataTable fn_GetChangeData(int ChangeDataType,string Databasename,string tablename,string captureinstance,
            DateTime starttime,DateTime endtime)
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
                     QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
    Databasename, Settings1.Default.AuthenticationType);
                     DataTable dt = _qe.fn_ExecuteTable(_sqlqry);
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
                    QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
    Databasename, Settings1.Default.AuthenticationType);
                    result = _qe.fn_ExecuteTable(_Qrygetalldata);
                }
                return result;

            }
            catch(SqlException)
            {
                throw;
            }
              
        }
      
        /// <summary>
        /// expot full tabl
        /// </summary>
        /// <param name="srcdb"></param>
        /// <param name="srctable"></param>
        /// <param name="destdb"></param>
        /// <param name="desttable"></param>
        public int fn_exportalldata(string srcdb,string srctable,string destdb,string desttable)
        {
            try
            {
                QueryExecution _srcqe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, 
                    Crypto.Crypto.Decrypt(Settings1.Default.Password, true),srcdb, Settings1.Default.AuthenticationType);
                // create destination table
                string _qrytblcols = " select stuff((select ',' + sc.name from sys.objects so join sys.schemas ss " +
                                  "  ON so.schema_id=ss.schema_id join sys.columns sc ON sc.object_id=so.object_id " +
                                  "  where so.object_id=object_id('" + srctable + "') for xml path('')),1,1,'')";
                string _collist = _srcqe.fn_ExecuteScalor(_qrytblcols);

                DataTable _dtsrctable = _srcqe.fn_ExecuteTable("SELECT " + _collist + ",'INSERT' AS Operation from " + srctable);
                if(_dtsrctable.Rows.Count==0)
                {
                    throw new ApplicationException("No data to export!!");
                }
                QueryExecution _destqe = new QueryExecution(Settings1.Default.Destserver, Settings1.Default.Destuser, 
                    Crypto.Crypto.Decrypt(Settings1.Default.Destpassword, true),destdb, Settings1.Default.Destauthtype);

                _destqe.fn_sqlbulkinsert(_dtsrctable, desttable);

                return _dtsrctable.Rows.Count;
            }catch(Exception)
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
        public int fn_ExportToDB(DataTable srctable,string desttable,string DestDatabase,
            string exportcheck="true",string sourcedb=null,string destinationdb=null)
        {
            DataTable tmpsrctable = srctable.Copy();

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

                QueryExecution _qe = new QueryExecution(Settings1.Default.Destserver, Settings1.Default.Destuser, Crypto.Crypto.Decrypt(Settings1.Default.Destpassword, true),
    DestDatabase, Settings1.Default.Destauthtype);
                int _recordcount = 0;
                // bulk copy srctable into sql server
                //if (exportcheck == "true")
                //{
                //    if(srctable.Rows.Count==0)
                //    { throw new ApplicationException("No data to export!!!"); }
                //    _qe.fn_sqlbulkinsert(tmpsrctable, desttable);
                //    _recordcount = tmpsrctable.Rows.Count;
                //}else if (exportcheck=="false")
                //{
                   _recordcount=fn_exportalldata(sourcedb,srctable.TableName.ToString() , destinationdb, desttable);
                

                return _recordcount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void fn_copytableschema(string srctable, string desttable, string DestDatabase,string srcdb)
        {
            try
            {
                QueryExecution _dqe = new QueryExecution(Settings1.Default.Destserver, Settings1.Default.Destuser,
                    Crypto.Crypto.Decrypt(Settings1.Default.Destpassword, true), DestDatabase, Settings1.Default.Destauthtype);
                QueryExecution _sqe = new QueryExecution(Settings1.Default.Server,
                    Settings1.Default.User,Crypto.Crypto.Decrypt(Settings1.Default.Password, true),srcdb,Settings1.Default.AuthenticationType);
                string _sql = "If (object_id('" + desttable + "')) is null CREATE TABLE [" + desttable + "] (";
                DataTable _tde = _sqe.fn_ExecuteTable("Select * from " + srctable + " where 1=2");

                foreach (DataColumn column in _tde.Columns)
                {
                    _sql += "[" + column.ColumnName + "] " + SQLGetType(column) + ",";
                }
               // _sql = _sql.Substring(0, (_sql.Length - 1)) + ')';
                _sql = _sql + " Operation varchar(100), DateLastUpdated Datetime default(getdate()))";

                _dqe.fn_ExecuteQuery(_sql);
            }catch(Exception)
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
       

        /// <summary>
        /// creates the meta database
        /// </summary>
        public void fn_CreateDatabase()
        {
            QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
    "master", Settings1.Default.AuthenticationType);
           _qe.fn_ExecuteQuery("if not exists(Select 1 from sys.databases where name='SQLCDCApp') BEGIN Create Database SQLCDCApp END ");

        }

        /// <summary>
        /// creates the meta tables and marks an entry for each export
        /// </summary>
        /// <param name="srcserver"></param>
        /// <param name="destserver"></param>
        /// <param name="srcdb"></param>
        /// <param name="destdb"></param>
        /// <param name="srctable"></param>
        /// <param name="desttable"></param>
        /// <param name="captureinstance"></param>
        public void fn_Updatemetatables(string srcserver, string destserver,string srcdb,string destdb,string srctable,
            string desttable,string captureinstance,string userid,string password)
        {
            if(string.IsNullOrEmpty(userid))
            {
                userid = "$$@#$$";
            }

                        string _sqlqrygetmaxlsn = " BEGIN TRAN " +
                                      " DECLARE @start_lsn BINARY(10),@end_lsn BINARY(10),@reccount int ,@maxlsn nvarchar(42) " +
                                      " SET @start_lsn=[" + srcdb + "].sys.Fn_cdc_get_min_lsn('" + captureinstance + "') " +
                                      " SET @end_lsn = [" + srcdb + "].sys.Fn_cdc_get_max_lsn() " +
                                      " SELECT @maxlsn=UPPER(sys.fn_varbintohexstr(MAX(__$start_lsn))),@reccount=COUNT(*) " +
                                      " FROM [" + srcdb + "].[cdc].[fn_cdc_get_net_changes_" + srctable + "](@start_lsn, @end_lsn, 'all') ";
            /*        
            string _sqlqrygetmaxlsn = " BEGIN TRAN " +
                                   " DECLARE @start_lsn BINARY(10),@end_lsn BINARY(10),@reccount int ,@maxlsn nvarchar(42) " +
                                   " SET @start_lsn=[" + srcdb + "].sys.Fn_cdc_get_min_lsn('" + captureinstance + "') ";
                                   //" SET @end_lsn = [" + srcdb + "].sys.Fn_cdc_get_max_lsn() " +
                                   //" SELECT @maxlsn=UPPER(sys.fn_varbintohexstr(MAX(__$start_lsn))),@reccount=COUNT(*) " +
                                   //" FROM [" + srcdb + "].[cdc].[fn_cdc_get_net_changes_" + srctable + "](@start_lsn, @end_lsn, 'all') ";
            */
            string _sqlqryinsert = _sqlqrygetmaxlsn + " if not exists(select 1 from sqlcdcapp.connection_details " +
            " where srcserver='" + srcserver + "' and destserver='" + destserver + "' and srcdb='" + srcdb + "' and srctable='" + 
            srctable.ReplaceFirstOccurrance("_", ".") + "' " +
            " and desttable='" + desttable + "' and captureinstance='" + captureinstance + "')" +
            " begin " +
            " INSERT INTO sqlcdcapp.connection_details " +
            " (srcserver,destserver,srcdb,destdb,srctable,desttable,userid,password,captureinstance) " +
                //" OUTPUT INSERTED.Cnid,'" + captureinstance + "',@reccount,@maxlsn,getdate(),SUSER_NAME() into sqlcdcapp.IDLoad" +
            " VALUES('" + srcserver + "','" + destserver + "','" + srcdb + "','"
                + destdb + "','" + srctable.ReplaceFirstOccurrance("_", ".") + "','" + desttable + "','" + userid + "','" +
                password + "','" + captureinstance + "')" +
            " INSERT INTO sqlcdcapp.IDLoad (captureInstance,srclaststartlsn,srclastsyncdate,srcsynclogin,recordsinserted) " +
            " VALUES('" + captureinstance + "',@maxlsn,GetDate(),SUser_Name(),0) END " +
            " COMMIT TRAN ";
            


           // _sqlqrycreatetable = _sqlqrycreatetable + _sqlqryinsert;
            QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
    "SQLCDCApp", Settings1.Default.AuthenticationType);

            _qe.fn_ExecuteQuery(_sqlqryinsert);

        }

        /// <summary>
        /// check whether table has been initialised for export.
        /// </summary>
        /// <param name="captureinstane"></param>
        /// <param name="databasename"></param>
        /// <returns></returns>
        public string fn_CheckExportDone(string captureinstane,string databasename)
        {

            //string _query = " if exists (select top(1) Cnid from SQLCDCApp.sqlcdcapp.connection_details ssc join SQLCDCApp.sqlcdcapp.IDLoad ssi " +
            //               " on ssc.captureinstance=ssi.captureinstance where (ssc.SQLJobID is null and ssi.SQLJobID is null) and ssi.srclaststartlsn " +
            //               " is not null and ssc.captureinstance='" + captureinstane + "' and ssc.srcserver='" + Settings1.Default.Server + "' and ssc.srcdb='" + databasename + "' ) " +
            //               " begin select 'true' end else begin select 'False' end";
            string _query = " if exists (select top(1) Cnid from SQLCDCApp.sqlcdcapp.connection_details ssc join SQLCDCApp.sqlcdcapp.IDLoad ssi " +
                          " on ssc.captureinstance=ssi.captureinstance where (ssc.SQLJobID is null and ssi.SQLJobID is null) " +
                          " and ssc.captureinstance='" + captureinstane + "' and ssc.srcserver='" + Settings1.Default.Server + "' and ssc.srcdb='" + databasename + "' ) " +
                          " begin select 'true' end else begin select 'False' end";
            string output = "";
            QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
     "SQLCDCApp", Settings1.Default.AuthenticationType);
            output = _qe.fn_ExecuteScalor(_query);
            return output;
        }

        /// <summary>
        /// create meta tables
        /// </summary>
        public void fn_initialiseMetatables()
        {
            try
            {
                string _sqlqrycreatetable = "if not exists(select 1 from sys.schemas where name ='sqlcdcapp')" +
                " BEGIN " +
                " EXEC('CREATE SCHEMA sqlcdcapp authorization dbo') " +
                " END " +
                " if (object_id('sqlcdcapp.connection_details')) is null " +
                " BEGIN " +
                " CREATE TABLE sqlcdcapp.connection_details ( " +
                " Cnid int identity Primary Key,srcserver varchar(50), destserver varchar(50), srcdb varchar(50), " +
                " destdb varchar(50), srctable varchar(100), desttable varchar(100),userid varchar(100) DEFAULT('$$@#$$'), " +
                " password nvarchar(200),Enabled bit Default(1),captureinstance varchar(100),SQLJobID uniqueidentifier Default(NULL),DateModified Datetime Default(Getdate())) END ";

                _sqlqrycreatetable = _sqlqrycreatetable + System.Environment.NewLine + " if (object_id('sqlcdcapp.IDLoad')) is null  " +
                " BEGIN " +
                " Create table sqlcdcapp.IDLoad (" +
                " sdid int identity Primary Key,captureinstance varchar(100), srclaststartlsn nvarchar(42), " +
                " srclastsyncdate datetime,srcsynclogin varchar(100),SQLJobID UniqueIdentifier DEFAULT(NULL),RecordsInserted int default(0) " +
                " ,RecordsDeleted int Default(0),RecordsUpdated int Default(0)) END";
                QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
    "SQLCDCApp", Settings1.Default.AuthenticationType);
                _qe.fn_ExecuteQuery(_sqlqrycreatetable);
            }catch(Exception)
            {
                throw;
            }
        }

        public void fn_disablecaptureinstance(List<CDC> cdclist)
        {
            try
            {
                string _query;
                QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User,
                  Crypto.Crypto.Decrypt(Settings1.Default.Password, true), "SQLCDCApp", Settings1.Default.AuthenticationType);

                foreach (CDC obj in cdclist)
                {
                    _query = " update sqlcdcapp.connection_details set Enabled=0, DateModified=getdate() where srcserver='" + Settings1.Default.Server + "' and srcdb='"
                        + obj.Databasename + "' and srctable='" + obj.source_schema + "." + obj.source_name + "'";
                    _qe.fn_ExecuteQuery(_query);
                }
            }catch(Exception)
            {
                throw;
            }
            
        }

        /*
        public DataTable fn_Getcaptureinstances()
        {
            string _qry = " select captureinstance from sqlcdcapp.connection_details where srcserver='" + Settings1.Default.Server +
                "' and srcdb='" + db + "' and srctable='" + tablename + "'";
            try
            {
                QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User,
                    Crypto.Crypto.Decrypt(Settings1.Default.Password, true), "SQLCDCApp", Settings1.Default.AuthenticationType);
                DataTable _dtci = _qe.fn_ExecuteTable(_qry);
                return _dtci;

            }catch(Exception)
            {
                throw;
            }
        }
        */
 /*
        public DataTable fn_getexportrecord()
        {
            try
            {
                string query = " select distinct ssc.captureinstance,ssc.srcserver,ssc.srcdb,ssc.srctable, " +
                              " ssc.destserver,ssc.destdb,ssc.desttable from SQLCDCApp.sqlcdcapp.connection_details ssc " +
                              " join SQLCDCApp.sqlcdcapp.IDLoad ssi on ssc.captureinstance=ssi.captureinstance where " +
                              " (ssc.SQLJobID is null and ssi.SQLJobID is null) and ssi.srclaststartlsn  is not null ";
                DataTable dtresult = fn_ExecuteReader(query, "SQLCDCApp");
                return dtresult;
            }catch(Exception)
            {
                throw;
            }
        }
   */
        public void fn_setsqljobid(Guid sqljobid,string captureinstance,string database,string srctable,string desttable,string destdb,string destserver)
        {
            try
            {
                string _query = "update sqlcdcapp.connection_details set sqljobid='" + sqljobid + "'" +
                    " where captureinstance='" + captureinstance + "' and srcserver='" + Settings1.Default.Server + "' and desttable='" + desttable + "'" +
                    " and srcdb ='" + database + "' and srctable='" + srctable.ReplaceFirstOccurrance("_", ".") + "' and sqljobid is null " +
                    " and destserver='" + destserver + "' and destdb='" + destdb + "'" + 
                    " update sqlcdcapp.IDload set sqljobid='" + sqljobid + "' where captureinstance='" + captureinstance + "'";
                QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
    "SQLCDCApp", Settings1.Default.AuthenticationType);
                _qe.fn_ExecuteQuery(_query);

            }catch(Exception)
            {
                throw;
            }

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
            QueryExecution _qe = new QueryExecution(Settings1.Default.Server, Settings1.Default.User, Crypto.Crypto.Decrypt(Settings1.Default.Password, true),
   Database, Settings1.Default.AuthenticationType);
            string output = _qe.fn_ExecuteScalor(_sqlqry );
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
    
    /// <summary>
    /// extends string to add new generic functions
    /// </summary>
   public static class StringExtenstion
   {

       public static string ReplaceFirstOccurrance(this string original, string oldValue, string newValue)
       {
           if (String.IsNullOrEmpty(original))
               return String.Empty;
           if (String.IsNullOrEmpty(oldValue))
               return original;
           if (String.IsNullOrEmpty(newValue))
               newValue = String.Empty;
           int loc = original.IndexOf(oldValue);
           return original.Remove(loc, oldValue.Length).Insert(loc, newValue);
       }
   }
}