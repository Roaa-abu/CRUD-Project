using CRUDOP.Domains.Dto;
using CRUDOP.Domains.Entities;
using CRUDOP.Domains.Enum;
using CRUDOP.Domains.Interface;
using CRUDOP.Infra;
using CRUDOP.ServiceUser;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_OP.Controllers
{
    public class UsersController : Controller
    {
        public readonly IUser _userService;
        public UsersController()
        {
            _userService = new UserService();
            //_userService.AddDefaultUsers();
        }
        [HttpGet]
        public IActionResult InsertUser(OpStatus status)
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUserInfo(User user)
        {
            OpStatus status = _userService.AddUser(user);
            return View("InsertUser", status); // Ensure a return statement is present
        }
        [HttpPost]
        public IActionResult UpdateUser(UserInfoDto userinfo)
        {
            OpStatus status = OpStatus.Failed;
            string message = string.Empty;
            if (userinfo != null || string.IsNullOrEmpty(userinfo.FullName)
                || string.IsNullOrEmpty(userinfo.PhoneNumber)
                || string.IsNullOrEmpty(userinfo.Password))
            {
                User userX = _userService.GetUserById(userinfo.Id);
                userX.FullName = userinfo.FullName;
                userX.PhoneNumber = userinfo.PhoneNumber;
                userX.password = HashPass.HashPassword( userinfo.Password);
                status = OpStatus.Success;
            }
            if(status == OpStatus.Success)
            {
                message = "User updated successfully";
            }
            else
            {
                message = "Failed to update user";
            }
            ViewBag.Message = message;
            ViewBag.Status = status;
            UserInfoDto user = new UserInfoDto
            {
                Id = userinfo.Id,
                FullName = userinfo.FullName,
                PhoneNumber = userinfo.PhoneNumber,
               
            };
            return View("EditeUser", user);
        }
        [HttpGet]
        public IActionResult EditeUser( int id)
        {   var user = _userService.GetUserById(id);
            var UserRequest = new UserInfoDto
            {
                Id = user.Id,
                FullName = user.FullName,
                PhoneNumber = user.PhoneNumber
            };
            
            return View(UserRequest);
        }
       
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user != null)
            {
                OpStatus status = _userService.DeleteUser(id);
                ViewBag.Message = status == OpStatus.Success
                    ? "User deleted successfully"
                    : "Failed to delete user";
                ViewBag.Status = status;
            }
            else
            {
                ViewBag.Message = "User not found";
                ViewBag.Status = OpStatus.Error;
            }

            var users = _userService.GetAllUsers(); // Get the updated list
            return View("ManageUsers", users);      // Pass it to the view
        }

        [HttpGet]
        public IActionResult ManageUsers()
        {
            var UsersList=_userService.GetAllUsers();
            return View(UsersList);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
