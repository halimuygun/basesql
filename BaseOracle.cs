/*
  BaseSql - C# basic database library
  Written by Halim Uygun @halimuygun
  Basic SQL commands for SQLServer, Oracle, MySQL, SQLite, PostgreSQL, etc..
*/

using System;
using System.Data;
using System.Data.OracleClient;

namespace BaseOracle
{
    public class DataBase
    {
        public string ConnectionString_ = "";

        public void Run(string SQL_)
        {
            try
            {
                using (OracleConnection oConnection = new OracleConnection())
                {
                    oConnection.ConnectionString = ConnectionString_;
                    oConnection.Open();

                    OracleCommand command = new OracleCommand();
                    command.CommandText = SQL_;
                    command.Connection = oConnection;
                    command.ExecuteNonQuery();
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public DataTable Read(string SQL_)
        {
            try
            {
                DataTable Table = new DataTable();
                OracleDataAdapter Adapter = new OracleDataAdapter();
                OracleCommand Command = new OracleCommand();

                OracleConnection Connection = new OracleConnection(ConnectionString_);
                Connection.Open();
                Table.Clear();

                Command.Connection = Connection;
                Command.CommandText = SQL_;
                Adapter.SelectCommand = Command;
                Adapter.Fill(Table);
                Connection.Close();
                return Table;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public string Insert(string Table_, string[] Cells_, string[] Values_)
        {
            try
            {
                using (OracleConnection oConnection = new OracleConnection())
                {
                    string Totals1 = "";
                    string Totals2 = "";
                    for (int i = 0; i <= Cells_.Length - 1; i++)
                    {
                        Cells_[i] = Cells_[i].Replace("'", "''");
                        Values_[i] = Values_[i].Replace("'", "''");

                        if (i == Cells_.Length - 1)
                        {
                            Totals1 += Cells_[i];
                            if (Values_[i] == "null")
                                Totals2 += Values_[i];
                            else
                                Totals2 += "'" + Values_[i] + "'";
                        }
                        else
                        {
                            Totals1 += Cells_[i] + ", ";
                            if (Values_[i] == "null")
                                Totals2 += Values_[i] + ", ";
                            else
                                Totals2 += "'" + Values_[i] + "', ";
                        }
                    }

                    oConnection.ConnectionString = ConnectionString_;
                    oConnection.Open();

                    OracleCommand command = new OracleCommand();
                    command.CommandText = "INSERT INTO " + Table_ + "(" + Totals1 + ") VALUES (" + Totals2 + ") SELECT SCOPE_IDENTITY()";
                    command.Connection = oConnection;
                    string id = command.ExecuteScalar().ToString();
                    oConnection.Close();

                    return id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Update(string Table_, string ID, string IDValue_, string[] Cells_, string[] Values_)
        {
            try
            {
                using (OracleConnection oConnection = new OracleConnection())
                {
                    string Totals = "";
                    for (int i = 0; i <= Cells_.Length - 1; i++)
                    {
                        Cells_[i] = Cells_[i].Replace("'", "''");
                        Values_[i] = Values_[i].Replace("'", "''");

                        if (i == Cells_.Length - 1)
                        {
                            if (Values_[i] == "null")
                                Totals += Cells_[i] + "= " + Values_[i];
                            else
                                Totals += Cells_[i] + "= '" + Values_[i] + "'";
                        }
                        else
                        {
                            if (Values_[i] == "null")
                                Totals += Cells_[i] + "= " + Values_[i] + ", ";
                            else
                                Totals += Cells_[i] + "= '" + Values_[i] + "', ";
                        }
                    }

                    oConnection.ConnectionString = ConnectionString_;
                    oConnection.Open();

                    OracleCommand command = new OracleCommand();
                    command.CommandText = "UPDATE " + Table_ + " SET " + Totals + " WHERE " + ID + "= '" + IDValue_ + "'";
                    command.Connection = oConnection;
                    command.ExecuteNonQuery();
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Update2(string Table_, string ID, string IDValue_, string ID2, string ID2Value_, string[] Cells_, string[] Values_)
        {
            try
            {
                using (OracleConnection oConnection = new OracleConnection())
                {
                    string Totals = "";
                    for (int i = 0; i <= Cells_.Length - 1; i++)
                    {
                        Cells_[i] = Cells_[i].Replace("'", "''");
                        Values_[i] = Values_[i].Replace("'", "''");

                        if (i == Cells_.Length - 1)
                        {
                            if (Values_[i] == "null")
                                Totals += Cells_[i] + "= " + Values_[i];
                            else
                                Totals += Cells_[i] + "= '" + Values_[i] + "'";
                        }
                        else
                        {
                            if (Values_[i] == "null")
                                Totals += Cells_[i] + "= " + Values_[i] + ", ";
                            else
                                Totals += Cells_[i] + "= '" + Values_[i] + "', ";
                        }
                    }

                    oConnection.ConnectionString = ConnectionString_;
                    oConnection.Open();

                    OracleCommand command = new OracleCommand();
                    command.CommandText = "UPDATE " + Table_ + " SET " + Totals + " WHERE " + ID + "= '" + IDValue_ + "' and " + ID2 + "= '" + ID2Value_ + "' ";
                    command.Connection = oConnection;
                    command.ExecuteNonQuery();
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void Delete(string Table_, string ID_, string Value_)
        {
            try
            {
                using (OracleConnection oConnection = new OracleConnection())
                {
                    oConnection.ConnectionString = ConnectionString_;
                    oConnection.Open();

                    OracleCommand command = new OracleCommand();
                    command.CommandText = "DELETE FROM " + Table_ + " WHERE " + ID_ + " = '" + Value_ + "'";
                    command.Connection = oConnection;
                    command.ExecuteNonQuery();
                    oConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
