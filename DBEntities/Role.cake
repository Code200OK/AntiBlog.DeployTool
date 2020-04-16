 public class Role : IDataModel
    {
        public string Name { get; set; }

        public object[] GetModelData()
        {
            return new object[] {Name};
        }
    }