using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WindowsService.Library
{
    public class UtilsDatabase
    {

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DbService"].ConnectionString;
        }

        public static void SetupDatabase()
        {
            try
            {
                var builder = new SqlConnectionStringBuilder(GetConnectionString());
                builder.InitialCatalog = "Master";

                using (SqlConnection con = new SqlConnection(builder.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        var schemaSql = Resources.SchemaDB;

                        foreach (var sql in schemaSql.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UtilsFile.WriteErrorLog(ex);
            }
        }

        public static string GetRandomMessage()
        {
            string message = String.Empty;
            try
            {
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 FileMessage FROM TB_Messages ORDER BY NEWID()", con))
                    {
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                                message = reader["FileMessage"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                UtilsFile.WriteErrorLog(ex);
            }

            return message;
        }

        public static void SaveLog(Exception ex)
        {
            try
            {
                string today = DateTime.Now.ToString();
                string registry = String.Format("{0} ==> {1}; {2}", today, ex.Source, ex.Message);
                string commandText = String.Format("INSERT INTO TB_Logs (LogMessage) VALUES ({0})", registry);

                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(commandText, con))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
            }
        }

    }

}
