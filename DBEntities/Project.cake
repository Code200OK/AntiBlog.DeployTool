  public class Project : IDataModel
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public int UserId { get; set; }

        public bool StatusId { get; set; }

        public object[] GetModelData()
        {
            return new object[]
            {
                Name, Color, UserId, StatusId
            };
        }
    }