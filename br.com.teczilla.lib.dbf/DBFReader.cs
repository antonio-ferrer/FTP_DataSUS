using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace br.com.teczilla.lib.dbf
{
    public class DBFReader : IDisposable
    {
        private OleDbConnection _conn;
        private Regex _rxIsNumber;
        private readonly List<Exception> _errors;
        public IEnumerable<Exception> Errors { get => _errors; }
        public string DirectoryPath { get; }
        public DBVersion Version { get; }

        public DBFReader(string directoryPath, DBVersion version)
        {
            this.DirectoryPath = directoryPath;
            this.Version = version;
            var strConn = $@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={directoryPath};Extended Properties=dBASE {GetDbVersion()};";
            this._conn = new OleDbConnection(strConn);
            _rxIsNumber = new Regex(@"^\d+((\.|,)\d+)?$");
            _errors = new List<Exception>();
        }

        private string GetDbVersion()
        {
            switch (this.Version)
            {
                case DBVersion.II: return "II";
                case DBVersion.III: return "III";
                case DBVersion.IV: return "IV";
            }
            throw new ArgumentOutOfRangeException("Version not supported");
        }

        private void UseCommand(Action<OleDbCommand> handle)
        {
            if (_conn.State != ConnectionState.Open)
                _conn.Open();
            using (var cmd = _conn.CreateCommand())
            {
                handle(cmd);
            }
        }

        public DataTable GetTable(string fileName)
        {
            try
            {
                DataTable table = new DataTable();
                UseCommand(cmd =>
                {
                    cmd.CommandText = $"SELECT * FROM {Path.Combine(DirectoryPath, fileName)}";
                    table.Load(cmd.ExecuteReader());
                });
                return table;
            }
            catch(Exception ex)
            {
                _errors.Add(ex);
                return null;
            }
        }

        /*public DataTable GetTable(string fileName, string whereConditions)
        {
            DataTable table = new DataTable();
            UseCommand(cmd =>
            {
                cmd.CommandText = $"SELECT * FROM {Path.Combine(DirectoryPath, fileName)} WHERE {whereConditions}";
                table.Load(cmd.ExecuteReader());
            });
            return table;
        }*/

        public string ToXML(string fileName)
        {
            DataTable table = GetTable(fileName) ?? new DataTable();
            table.TableName = Regex.Replace(fileName, @"\.dbf$", "", RegexOptions.IgnoreCase);
            fileName = Path.Combine(DirectoryPath, table.TableName + ".xml");
            if (File.Exists(fileName))
                File.Delete(fileName);
            table.WriteXml(fileName);
            return fileName;
        }

        private string GetStringValue(object v)
        {
            if (string.IsNullOrEmpty(v?.ToString()) || Convert.IsDBNull(v))
                return string.Empty;
            return v.ToString();
        }

        private string GetJSONValue(object v)
        {
            if (string.IsNullOrEmpty(v?.ToString()) || Convert.IsDBNull(v))
                return "null";
            if (v is string)
                return "'" + v.ToString().Replace("'", "´") + "'";
            else if (_rxIsNumber.IsMatch(v.ToString()))
            {
                return v.ToString().Replace(",", ".");
            }
            else if (v is DateTime)
            {
                return $"'{(DateTime)v:yyyy-MM-dd HH:mm:ss}'";
            }
            else if (v is bool)
                return $"{v.ToString().ToLower()}";
            else
                return $"'{v}'";
        }

        public string ToCSV(string fileName)
        {
            DataTable table = GetTable(fileName) ?? new DataTable();
            table.TableName = Regex.Replace(fileName, @"\.dbf$", "", RegexOptions.IgnoreCase);
            fileName = Path.Combine(DirectoryPath, table.TableName + ".csv");
            if (File.Exists(fileName))
                File.Delete(fileName);
            if (table.Rows.Count > 0)
            {
                using (var sw = new StreamWriter(fileName))
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (DataColumn col in table.Columns)
                    {
                        sb.Append(col.ColumnName).Append(';');
                    }
                    sb.Length--;
                    sw.WriteLine(sb.ToString());
                    sb.Clear();
                    foreach (DataRow row in table.Rows)
                    {
                        foreach (DataColumn col in table.Columns)
                        {
                            sb.Append(GetStringValue(row[col])).Append(';');
                        }
                        sb.Length--;
                        sw.WriteLine(sb.ToString());
                        sb.Clear();
                    }

                }
            }
            return fileName;
        }

        public string ToJSON(string fileName)
        {
            DataTable table = GetTable(fileName) ?? new DataTable();
            table.TableName = Regex.Replace(fileName, @"\.dbf$", "", RegexOptions.IgnoreCase);
            fileName = Path.Combine(DirectoryPath, table.TableName + ".json");
            if (File.Exists(fileName))
                File.Delete(fileName);
            if (table.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("[");
                foreach (DataRow row in table.Rows)
                {
                    sb.AppendLine("{");
                    foreach (DataColumn col in table.Columns)
                    {
                        sb.Append(col.ColumnName.ToLower());
                        sb.Append(':');
                        sb.AppendLine(GetJSONValue(row[col]));
                        sb.Append(',');
                    }
                    sb.Length--;
                    sb.AppendLine("}");
                    sb.Append(',');
                }
                sb.Length--;
                sb.AppendLine("]");
                File.WriteAllText(fileName, sb.ToString());
            }
            return fileName;
        }

        public void Dispose()
        {
            _conn?.Close();
            _conn?.Dispose();
        }
    }
}
