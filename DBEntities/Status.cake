  public class Status : IDataModel
    {
        public string Name { get; set; }

        public object[] GetModelData()
        {
            return new object[] {Name};
        }
    }