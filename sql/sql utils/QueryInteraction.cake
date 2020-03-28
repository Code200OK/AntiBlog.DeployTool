using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public static class QueryInteraction
{
    public static int ExecuteNonQuery(string connectionString, string commandText, CommandType commandType,
          params SqlParameter[] parameters)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            using (var cmd = new SqlCommand(commandText, conn))
            {
                cmd.CommandType = commandType;
                cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public static void Insert<T>(string tableName, string connectionString) where T : IDataModel
    {
        var streamReader = new StreamReader($"ModelDataJson/{tableName}.json");
        var deserializeObject = JsonConvert.DeserializeObject<T[]>(streamReader.ReadToEnd());

        var parameters = new List<SqlParameter>();
        var commandText = new StringBuilder($"INSERT INTO {tableName} VALUES");

        int valueIndex = 1;

        foreach (T obj in deserializeObject)
        {
            object[] modelData = obj.GetModelData();

            commandText.Append("(");

            string valuePlaceholder = string.Empty;

            foreach (var modelFiled in modelData)
            {
                valuePlaceholder = $"@Value{valueIndex++}";

                commandText.Append($"{valuePlaceholder},");

                parameters.Add(new SqlParameter(valuePlaceholder, modelFiled));
            }

            commandText.Replace($"{valuePlaceholder},", $"{valuePlaceholder}),");
        }

        commandText.Remove(commandText.Length - 1, 1);

        int rows = ExecuteNonQuery(connectionString, commandText.ToString(), CommandType.Text,
            parameters.ToArray());

        Console.WriteLine($"Count of inserted rows:{rows}");
    }
}