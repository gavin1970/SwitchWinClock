using SwitchWinClock.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace SwitchWinClock.utils
{
    public class JSONData : JSONHelper
    {
        #region Constructor
        /// <example>
        /// JSONData jsonData = new JSONData(new NetworkCredential(jsonFile, pass_salt));
        /// jsonFile : required.  @"\data\myjson.json"
        /// pass_salt: not required.  If null passed in, json will not be encrypted.
        /// </example>
        /// <param name="connectionString"></param>
        public JSONData(NetworkCredential connectionString)
        {
            ConnectionString = connectionString;
            Startup();
        }
        #endregion

        #region Everthing Json
        /// <summary>
        /// Save Json file to disk.
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public ResultStatus SaveJson(string jsonData)
        {
            return SaveJsonData(jsonData);
        }
        /// <summary>
        /// Get all raw data via JSON
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public string GetJson()
        {
            CheckFilePath();
            return GetJsonData();
        }

        /// <summary>
        /// Check up and Set up monitor.
        /// </summary>
        private void Startup()
        {
            CheckFilePath();
            SetFileMonitor();
        }
        #endregion

        #region Everthing Datasets
        /// <summary>
        /// Create new dataset name or update existing.
        /// </summary>
        /// <param name="dataSetName"></param>
        /// <returns></returns>
        public void SetDatasetName(string dataSetName)
        {
            CheckFilePath();
            lock (DSetLock)
            {
                if (RecordData == null)
                    RecordData = new DataSet(dataSetName);
                else
                    RecordData.DataSetName = dataSetName;
            }
        }

        /// <summary>
        /// Get all tables and records as a DataSet
        /// </summary>
        /// <param name="DataSet"></param>
        /// <returns></returns>
        public DataSet GetDataset()
        {
            CheckFilePath();
            return RecordData;
        }
        #endregion

        #region Everthing Tables
        /// <summary>
        /// Check if table exists.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool TableExists(string tableName)
        {
            //check to ensure a valid connections tring was passed.
            if (string.IsNullOrWhiteSpace(tableName))
                //create error
                ThrowException($"Connection string is required when initializing {About.AppTitle}");

            CheckFilePath();

            bool retVal = false;

            DataSet ds = RecordData;
            if (ds != null && ds.Tables.Contains(tableName))
                retVal = true;

            return retVal;
        }

        /// <summary>
        /// Get all data and structure of a specific table.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public List<string> GetTableNames(bool sort = false)
        {
            CheckFilePath();

            List<string> tableNames = new List<string>();

            //we don't want send this back to caller since it's an internal table.
            lock (DSetLock)
            {
                DataSet ds = RecordData.Copy();

                if (ds.Tables.Contains(SCHEMA_TABLE_NAME))
                    ds.Tables.Remove(SCHEMA_TABLE_NAME);

                foreach (DataTable dt in ds.Tables)
                    tableNames.Add(dt.TableName);

                //clear up.
                ds.Dispose();
            }

            if (sort)
                tableNames.Sort();

            return tableNames;
        }

        /// <summary>
        /// Create new table.  If table already exists, it will be overwritten, including structure and all data.
        /// </summary>
        /// <param name="newTable"></param>
        /// <returns></returns>
        public ResultStatus CreateTable(DataTable newTable)
        {
            CheckFilePath();

            lock (DSetLock)
            {
                DataSet ds = RecordData;
                if (ds.Tables.Contains(newTable.TableName))
                    ThrowException("Table name already exists.");
            }

            return UpdateTable(newTable);
        }

        /// <summary>
        /// create a table
        /// </summary>
        /// <param name="fieldValues"></param>
        /// <returns></returns>
        public ResultStatus CreateTable(string tableName, List<FIELD_VALUE> fieldValues)
        {
            ResultStatus retVal = new ResultStatus();
            DataTable dataTable = new DataTable { TableName = tableName };

            try
            {
                //create table headers..
                foreach (var field in fieldValues)
                    dataTable.Columns.Add(field.FieldName);

                DataRow dr = dataTable.NewRow();

                foreach (var field in fieldValues)
                    dr[field.FieldName] = field.Value;

                dataTable.Rows.Add(dr);

                retVal = CreateTable(dataTable);
            }
            catch (Exception ex)
            {
                retVal.Description = ex.Message;
                retVal.Status = RESULT_STATUS.EXCEPTION;
                retVal.StackTrace = ex.StackTrace;
            }

            return retVal;
        }

        /// <summary>
        /// Get all data and structure of a specific table.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public DataTable GetTable(string tableName)
        {
            CheckFilePath();

            lock (DSetLock)
            {
                if (RecordData != null && RecordData.Tables.Count > 0)
                {
                    if (RecordData.Tables.Contains(tableName))
                        return RecordData.Tables[tableName];
                }
            }

            return new DataTable(tableName);
        }

        /// <summary>
        /// Update Data Set
        /// </summary>
        /// <param name="newTable"></param>
        /// <returns></returns>
        public ResultStatus UpdateTable(DataTable newTable)
        {
            if (string.IsNullOrWhiteSpace(newTable.TableName))
                ThrowException("newTable.TableName is required to be set.");

            lock (DSetLock)
            {
                if (RecordData != null && RecordData.Tables.Contains(newTable.TableName))
                    RecordData.Tables.Remove(newTable.TableName);

                RecordData.Tables.Add(newTable.Copy());
                newTable.Dispose();
            }

            return SaveData();
        }
        /// <summary>
        /// Delte Data table
        /// </summary>
        /// <param name="newTable"></param>
        /// <returns></returns>
        public ResultStatus DropTable(DataTable newTable)
        {
            if (string.IsNullOrWhiteSpace(newTable.TableName))
                ThrowException("newTable.TableName is required to be set.");

            ResultStatus rs = DropTable(newTable.TableName);
            if (rs.Status != RESULT_STATUS.OK)
                return rs;
            else
                return SaveData();
        }
        /// <summary>
        /// get DataSet and remove dataset, even if empty.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public ResultStatus DropTable(string tableName)
        {
            if (string.IsNullOrWhiteSpace(tableName))
                ThrowException("TableName is required to be set.");

            CheckFilePath();

            lock (DSetLock)
            {
                if (RecordData != null && RecordData.Tables.Contains(tableName))
                    RecordData.Tables.Remove(tableName);
            }

            return SaveData();
        }
        #endregion

        #region Everthing Records
        /// <summary>
        /// Query table by where clause and ordering the return as an array of rows.
        /// </summary>
        /// <example>
        /// DataRow[] drArray = jsonData.GetRecords(dataType, "Type LIKE '%American%'", "Type DESC");
        /// </example>
        /// <param name="tableName"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public DataRow[] GetRecords(string tableName, string where, string orderBy = null)
        {
            CheckFilePath();

            if (where != null && where.StartsWith("WHERE "))
                where = where.Replace("WHERE ", "");

            if (orderBy != null && orderBy.StartsWith("ORDER BY "))
                orderBy = orderBy.Replace("ORDER BY ", "");

            DataTable dt = GetTable(tableName);
            return dt.Select(where, orderBy);
        }
        /// <summary>
        /// Delete Record from Table
        /// </summary>
        /// <param name="newTable"></param>
        /// <returns></returns>
        public ResultStatus DeleteRecord(string tableName, string where)
        {
            CheckFilePath();

            if (where != null && where.StartsWith("WHERE "))
                where = where.Replace("WHERE ", "");

            DataTable dt = GetTable(tableName);
            DataRow[] rs = dt.Select(where);

            foreach (DataRow dr in rs)
                dr.Delete();

            dt.AcceptChanges();

            return UpdateTable(dt);
        }
        /// <summary>
        /// Update specific record/records
        /// </summary>
        /// <example>
        /// List<JSONHelper.FIELD_VALUE> fieldValues = new List<JSONHelper.FIELD_VALUE>();
        /// fieldValues.Add(new JSONHelper.FIELD_VALUE { FieldName = "PMType", Value = inventoryModel.PMType });
        /// fieldValues.Add(new JSONHelper.FIELD_VALUE { FieldName = "ShapeType", Value = inventoryModel.ShapeType });
        /// ResultStatus rs = jsonData.UpdateRecord("Inventory", fieldValues, $"InventoryId='{inventoryModel.InventoryId}'");
        /// </example>
        /// <param name="tableName"></param>
        /// <param name="fieldValues"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public ResultStatus SaveRecord(string tableName, List<FIELD_VALUE> fieldValues, string where, bool createTable = false)
        {
            CheckFilePath();

            ResultStatus retVal = new ResultStatus();
            DataTable dt = GetTable(tableName);

            try
            {
                if (dt != null)
                {
                    foreach (FIELD_VALUE fv in fieldValues)
                    {
                        if (!dt.Columns.Contains(fv.FieldName))
                            dt.Columns.Add(fv.FieldName);
                    }
                }
                else if (dt == null && createTable)
                {
                    CreateTable(tableName, fieldValues);
                    return retVal;
                }
                else if (dt == null)
                    ThrowException($"'{tableName}' table does not exists.  Use CreateTable() first.");

                DataRow[] exists = null;

                if (where != null)
                    exists = dt.Select(where);

                if (exists != null && exists.Length > 0)
                {
                    for (int i = 0; i < exists.Length; i++)
                    {
                        dt.Rows.Remove(exists[i]);
                        DataRow dr = dt.NewRow();

                        foreach (FIELD_VALUE fv in fieldValues)
                            dr[fv.FieldName] = JsonClean(fv.Value);

                        dt.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow newRow = dt.NewRow();
                    foreach (FIELD_VALUE fv in fieldValues)
                        newRow[fv.FieldName] = JsonClean(fv.Value);
                    dt.Rows.Add(newRow);
                }

                lock (DSetLock)
                {
                    RecordData.Tables.Remove(tableName);
                    RecordData.Tables.Add(dt);
                }
                SaveData();
            }
            catch (Exception ex)
            {
                retVal.Status = RESULT_STATUS.EXCEPTION;
                retVal.Description = ex.Message;
                retVal.StackTrace = ex.StackTrace;
            }

            return retVal;
        }
        #endregion
    }
}
