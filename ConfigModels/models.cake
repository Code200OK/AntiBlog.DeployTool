public class DatabaseSettings
{
    public string ConnectionString { get; set; }
    public string DbCreationPath { get; set; }
    public string DbName { get; set; }
}

internal class Roles
{
        public string[] Values { get; set; }
}