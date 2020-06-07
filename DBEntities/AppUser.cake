    public class AppUser : IDataModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string RegistrationDate { get; set; }

        public int RoleId { get; set; }

        public object[] GetModelData()
        {
            return new object[]
            {
                Name, Surname, Email, Login, PasswordHash, PasswordSalt, RegistrationDate, RoleId
            };
        }
    }