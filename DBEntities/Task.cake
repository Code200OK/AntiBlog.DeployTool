  public class Task : IDataModel
    {
        public string Description { get; set; }

        public string Priority { get; set; }

        public string ProjectTag { get; set; }

        public DateTime Deadline { get; set; }

        public int ProjectId { get; set; }

        public object[] GetModelData()
        {
            return new object[]
            {
                Description, Priority, ProjectTag, Deadline, ProjectId
            };
        }
    }