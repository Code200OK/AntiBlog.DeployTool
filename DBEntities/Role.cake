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