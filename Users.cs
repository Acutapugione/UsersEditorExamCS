using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UsersModel
{
    public static class UserManager
    {
        private class Users
        {
            private List<User> _users;

            public Users(List<User> users = null)
            {
                _users = users ?? new List<User>();
            }
            public void Add(User user)
            {
                if (user is null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                _users.Add(user);
            }
            public void Add(string name, string pwd, Role role)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException($"\"{nameof(name)}\" не может быть неопределенным или пустым.", nameof(name));
                }

                if (string.IsNullOrEmpty(pwd))
                {
                    throw new ArgumentException($"\"{nameof(pwd)}\" не может быть неопределенным или пустым.", nameof(pwd));
                }
                _users.Add(new User(name, pwd, role: role));
            }
            public bool IsExists(User user)
            {
                return _users.Exists(x => x.Name == user.Name);
            }
            public bool IsExists(string name)
            {
                return _users.Exists(x => x.Name == name);
            }
            public void Save(string filename, JsonSerializerOptions options)
            {
                using (FileStream fs = new(filename, FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize(_users, typeof(List<User>), options);
                    Console.WriteLine("Saved");
                }
            }
            public void Load(string filename, JsonSerializerOptions options)
            {
                using (StreamReader fs = new(filename))
                {
                    _users = (List<User>)JsonSerializer.Deserialize(fs.ReadToEnd(), typeof(List<User>), options);
                }
            }
            public int Count { get { return _users.Count; } }
            public void Print()
            {
                foreach (var item in _users)
                {
                    Console.WriteLine($"{ item.Name} {item.Role}");
                }
            }
        }
        
        private static Users _users = new();
        public static int Count => _users.Count;

        public static JsonSerializerOptions Json_options = new ()
        {
            WriteIndented = false,
            AllowTrailingCommas = false,
            IgnoreNullValues = false,
            IgnoreReadOnlyProperties = false,
        };
        public static bool Add(string name, string pwd, Role role)
        {
            if (IsExists(name))
            {
                return false;
            }
            _users.Add(name, pwd, role);

            return true;
        }
        public static bool Add(User user)
        {
            if (IsExists(user))
            {
                return false;
            }
            _users.Add(user);

            return true;
        }
        public static bool IsExists(User user) => _users.IsExists(user);
        public static bool IsExists(string name) => _users.IsExists(name);
        public static void Print()
        {
            _users.Print();
        }
        
        public static void Save(string filename)
        {
            _users.Save(filename, Json_options);
        }
        public static void Load(string filename)
        {
            _users.Load(filename, Json_options);
        }
    }
   
}
