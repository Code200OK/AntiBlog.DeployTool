class QueryInteraction
{
      /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns>Count of records</returns>
        private static int ExecuteNonQuery(string connectionString, string commandText, CommandType commandType,
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

        private static bool Insert()
        {
            var stringReader = new StreamReader("roles.json");
            var deserializeObject = JsonConvert.DeserializeObject<Roles>(stringReader.ReadToEnd());

            var parameters = new List<SqlParameter>();

            int paramCounter = 0;

            foreach (string value in deserializeObject.Values)
            {
                Console.WriteLine(value);
                parameters.Add(new SqlParameter("@Value1", value));
            }

            // const string commandText = "INSERT INTO Role (Name) VALUES (@Value1),(@Value2)";
            //
            //
            // const string connectionString =
            //     "Data Source=(LocalDB)\\MSSQLLocalDB;Database=AntiBlog;Integrated Security=True";
            //
            // int rows = ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameters);
            //
            // Console.WriteLine($"Count of rows:{rows}");
        }
}