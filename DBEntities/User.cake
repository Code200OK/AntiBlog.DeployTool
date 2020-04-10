public class User : IDataModel
{
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int RoleId { get; set; }

        public object[] GetModelData()
        {
            return new object[]
            {
                Name, Surname, Email, Login, PasswordHash, RegistrationDate, RoleId
            };
        }
}