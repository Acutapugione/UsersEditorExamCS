namespace UsersModel
{
    public interface IUser
    {
        string Name { get; set; }
        string Pwd { get; set; }
        Role Role { get; set; }
    }
}