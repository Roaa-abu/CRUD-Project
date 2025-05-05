using CRUDOP.Domains.Entities;
using CRUDOP.Domains.Enum;


namespace CRUDOP.Domains.Interface;

public interface IUser
{
    public OpStatus AddUser(User user);
    public OpStatus DeleteUser(int id);
    public OpStatus UpdateUser(int id, User user);
    public User GetUserById(int id);
    public List<User> GetAllUsers();
}
