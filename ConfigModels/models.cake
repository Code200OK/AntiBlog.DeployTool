public interface IDataModel
{
    object[] GetModelData();
}

public class DatabaseSettings
{
    public string ConnectionString { get; set; }
    public string DbCreationPath { get; set; }
    public string DbName { get; set; }
    public string TestConnString { get; set; }
}

public class Role : IDataModel
{
    public string Name { get; set; }
    public string ResponsibilityLevel { get; set; }
    public int AgeConstraint { get; set; }

    public object[] GetModelData()
    {
        return new object[] { Name, ResponsibilityLevel, AgeConstraint };
    }
}

