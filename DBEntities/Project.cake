 public class Project : IDataModel
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public bool Status { get; set; }

        public int UserId { get; set; }

        public object[] GetModelData()
        {
            return new object[]
            {
                Name, Color, Status, UserId
            };
        }
    }