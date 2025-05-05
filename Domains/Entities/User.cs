using CRUDOP.Domains.Enum;

namespace CRUDOP.Domains.Entities;

public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string password { get; set; }
    public UserStatus Status { get; set; }
}
