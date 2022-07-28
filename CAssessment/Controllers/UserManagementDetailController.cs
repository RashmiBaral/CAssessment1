using Infrastructure.Abstract;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FBLoginService;
using System.IO;

using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace CAssessment.Controllers
{
    public class UserManagementDetailController : Controller
    {
        IUserManagementRepository _repo = new UserManagementRepository();

        [AllowAnonymous]
        public IActionResult Index()
        {
            string UserName = TempData["LoggedInUser"].ToString();

            TempData["LoggedInUser"] = UserName;
            return View();

        }
        [HttpGet]

        [AllowAnonymous]
        public IActionResult RegisterUser()
        {
            UserDetail objUserDetail = new UserDetail();
            objUserDetail.UserRoles = _repo.GetUserRoles();
            return View(objUserDetail);

        }

        [HttpPost]
        public IActionResult RegisterUser(UserDetail usr)
        {


         


            if (usr.UserPhoto != null)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserPhoto");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                //get file extension
                FileInfo fileInfo = new FileInfo(usr.UserPhoto.FileName);
                string fileName = fileInfo.Name;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    usr.UserPhoto.CopyTo(stream);
                }
                



               

            }

            string status = _repo.RegisterUser(usr);
            if (status.ToLower() == "success")
            {
                TempData["Status"] = "User registration complete.";
                //Navigate to Login Page.
                return RedirectToAction("LoginUser");
            }
            else
            {
                TempData["Status"] = "User registration unsuccessful. Please try agin";
                //Stay in the current page
                return View();
            }

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> LoginUserAsync(UserDetail usr, string Login, string FBLogin)
        {
            if (!string.IsNullOrWhiteSpace(Login) && Login.ToLower().Equals("login"))
            {
                //Authentication

                UserDetail UserInfo = _repo.LoginUser(usr);
                


                if (UserInfo != null)
                {
                    if (UserInfo.PasswordChangeDate == null)
                    {

                        return RedirectToAction("UpdatePassword", usr);
                    }

                    else
                    {
                        string[] userRoles = new string[3] { "HRManager", "Admin", "SME" };

                        //Storing User ID / Unique Id and Role into claim and passing it to authentication cookie.

                        var claims = new List<Claim>();
                        claims.Add(new Claim("username", usr.UserID));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, usr.UserID));

                        foreach (var Role in userRoles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, Role));
                        }

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                        await HttpContext.SignInAsync(claimsPrincipal);

                        TempData["LoggedInUser"] = usr.UserID;
                        TempData["Status"] = "Login Successful";
                        //Navigate to Home Page.
                        return RedirectToAction("Index");
                    }

                }
                else
                {
                    TempData["Status"] = "Login UnSuccessful";
                    return View();
                }
            }
            else
            {
                return RedirectToAction("FBLogin", usr);
                if (ViewBag.Info == "success")
                {
                    //return View();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }



        }



        [HttpGet]
        public IActionResult UpdatePassword(UserDetail usr)
        {
            return View(usr);

        }

        [HttpPost]
        public IActionResult UpdatePassword(UserDetail usr, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            string status = _repo.UpdatePassword(usr, OldPassword, NewPassword, ConfirmPassword);
            ViewBag.PasswordUpdateStatus = status;

            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();

        }

        [HttpPost]
        public IActionResult CreateRole(UserRole Role)
        {
            string status = _repo.CreateRole(Role);

            if (status.ToLower() == "success")
            {
                @TempData["Status"] = "Role created successfully";
            }
            else
            {
                @TempData["Status"] = "Role creation unsuccessful";
            }


            return View();

        }

        public async Task<IActionResult> FBLogin(UserDetail usr)
        {
            string UID = usr.UserID;
            string PWD = usr.Password;
            ValidateLoginClient obj = new ValidateLoginClient();
            ValidateLoginInfoRequest request = new ValidateLoginInfoRequest(UID, PWD);
            var resp = await obj.ValidateLoginInfoAsync(request);

            if (resp.ValidateLoginInfoResult.UID != null)
            {
                TempData["Status"] = "Login Successful";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Status"] = "FB UID or Password mismatch";
                return RedirectToAction("LoginUser");
            }


        }


        /*
        public async Task<IActionResult> Index(string uid, string pwd)
        {
            string apiBaseUrl = "https://localhost:44320/";
            string endpoint = string.Empty;
            UserDetail info = null;
            using (HttpClient client = new HttpClient())
            {
                endpoint = apiBaseUrl + "api/MyUserAuth/AuthenticateUserData?uid=" + uid + "&pwd=" + pwd;
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    info = JsonConvert.DeserializeObject<UserDetail>(data);
                }
            }

            if (info != null)
                return RedirectToAction("Home");
            else
                ViewBag.Info = "Invalid user ID or password";
            return View();
        }

        */

        [HttpGet]
        public IActionResult EditUser(int ID)
        {
            UserDetail User = _repo.EditUserDetail(ID);
            return View(User);

        }

        [HttpPost]
        public IActionResult EditUser(UserDetail user)
        {
            string msg = _repo.EditUser(user);
            TempData["Status"] = msg;
            return View(user);

        }

        [HttpGet]
        public IActionResult RegisteredUsersList()
        {
            List<UserDetail> RegUserList = new List<UserDetail>();
            RegUserList = _repo.RegisteredUsersList();
            return View(RegUserList);

        }


        public IActionResult InstructionPage()
        {
            return View();
        }
    }
}
