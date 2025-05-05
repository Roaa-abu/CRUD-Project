using CRUDOP.Domains.Interface;
using CRUDOP.Domains.Entities;
using CRUDOP.Domains.Enum;
using CRUDOP.Infra;

namespace CRUDOP.ServiceUser;
public class UserService : IUser
{
    public static List<User> Users;

    public UserService()
    {
        if (Users == null)
        {
            Users = new List<User>();

        }
        if (Users.Count == 0)
            AddDefaultUsers();

    }
    #region Public Methods
    public OpStatus AddUser(User user)
    {
        try
        {
            if (user == null
                || string.IsNullOrEmpty(user.FullName)
                || string.IsNullOrEmpty(user.PhoneNumber)
                || string.IsNullOrEmpty(user.password))
            {
                return OpStatus.Failed;
            }
            else if (Users.Any(u => u.PhoneNumber == user.PhoneNumber))
            {
                return OpStatus.AlreadyExists;
            }
            else
            {
               return UserInfo(user);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return OpStatus.Error;
        }
    }

    public OpStatus UpdateUser(int id, User user)
    {
        try
        {

            if (user == null
                || string.IsNullOrEmpty(user.FullName)
                || string.IsNullOrEmpty(user.PhoneNumber)
                || string.IsNullOrEmpty(user.password))
            {
                return OpStatus.Failed;
            }
            else
            {
                User oldUser = Users.Find(u => u.Id == id);
                oldUser.FullName = user.FullName;
                oldUser.PhoneNumber = user.PhoneNumber;
                if (!string.IsNullOrEmpty(user.password))
                {
                    string hashpass = HashPass.HashPassword(user.password);
                    oldUser.password = hashpass;
                }
                oldUser.Status = user.Status;
            }
            return OpStatus.Success;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return OpStatus.Error;
        }
    }
    public OpStatus DeleteUser(int id)
    {
        try
        {
            User? x = Users.Find(u => u.Id == id);
            if (x == null)
                return OpStatus.Error;
            else
            {
                x.Status = UserStatus.Deleted;
                return OpStatus.Success;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return OpStatus.Error;
        }
    }
    public List<User> GetAllUsers()
    {
        try
        {
            if (Users == null)
                return new List<User>();
            else
            {
                return Users;
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public User GetUserById(int id)
    {
        try
        {
            User? user = Users.Find(u => u.Id == id);
            if (user == null)
                return new User();
            else
                return user;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    


    #endregion

    #region Private Methods

    private int GetNextId()
    {
        if (Users.Count == 0)
            return 1;
        else
            return Users.Max(u => u.Id) + 1;
    }
    private OpStatus UserInfo(User user){
        User newUser = new User();
        if (user.Id == 0)
            newUser.Id = GetNextId();

                newUser.Status = UserStatus.Active;
                string hashpass = HashPass.HashPassword(user.password);
                newUser.password = hashpass;
                newUser.FullName = user.FullName;
                newUser.PhoneNumber = user.PhoneNumber;
                Users.Add(newUser);
                return OpStatus.Success;}
    private void AddDefaultUsers()
    {
        Users.Add(new User() { Id = 1, FullName = "Roaa", PhoneNumber = "0797166359", password = HashPass.HashPassword("15822"), Status = UserStatus.Active });
        Users.Add(new User() { Id = 2, FullName = "Shatha", PhoneNumber = "078999763", password = HashPass.HashPassword("15822"), Status = UserStatus.Active });
        Users.Add(new User() { Id = 3, FullName = "Misk", PhoneNumber = "0797166358", password = HashPass.HashPassword("15822"), Status = UserStatus.Active });
        Users.Add(new User() { Id = 4, FullName = "Muna", PhoneNumber = "07971663588", password = HashPass.HashPassword("15822"), Status = UserStatus.Active });
        Users.Add(new User() { Id = 5, FullName = "Munier", PhoneNumber = "078899955", password = HashPass.HashPassword("15822"), Status = UserStatus.Active });
    }
    #endregion
}
