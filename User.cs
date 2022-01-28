namespace UsersModel
{
    using System;
    using System.Text.Json.Serialization;

    public class User : IUser
    {
        private string name;
        private Role role;
        private string pwd;

        public User(string name, string pwd, Role role)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
            }

            if (string.IsNullOrEmpty(pwd))
            {
                throw new ArgumentException($"\"{nameof(pwd)}\" не может быть неопределенным или пустым.", nameof(pwd));
            }

            this.name = name;
            this.role = role;
            this.pwd = pwd;
        }
        [JsonPropertyName("login")]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        [JsonPropertyName("role")]
        public Role Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }
        [JsonPropertyName("password")]
        public string Pwd
        {
            get
            {
                return pwd;
            }

            set
            {
                pwd = value;
            }
        }
    }
}