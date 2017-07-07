namespace LearnerRater.Tests.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text.RegularExpressions;

    public static class DatabaseCommands
    {
        public static void RunScriptFromFile(string connectionString, string scriptLocation, Dictionary<string, string> keysToReplace)
        {
            var connection = new SqlConnection(connectionString);

            var database = connection.Database.ToString();
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            try
            {
                var file = new FileInfo(scriptLocation);
                var script = file.OpenText().ReadToEnd();

                foreach (var pair in keysToReplace)
                {
                    script = Regex.Replace(script, pair.Key, pair.Value, RegexOptions.IgnoreCase);
                }
                script = Regex.Replace(script, "GO", "", RegexOptions.IgnoreCase);

                var sqlCmd = new SqlCommand(script, connection);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Error running script", ex);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
