using Microsoft.Data.SqlClient;
using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CAssessmentKeyVault;
using Infrastructure.Abstract;
using System.Linq;
using ModelsAndUtility.Utility;

namespace Infrastructure.Repository
{
    public class UserManagementRepository : IUserManagementRepository
    {
        CAssessmentContext _context = new CAssessmentContext();

        //login with ADO
        public string AuthenticateUser(UserDetail User)
        {

            string DBCon = new CADBConnection().ConString;

            string msg = "";
            try
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(DBCon);


                SqlCommand com = new SqlCommand("USER_SELECT_FOR_LOGIN", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@UserID", User.UserID);
                com.Parameters.AddWithValue("@Password", User.Password);

                SqlDataAdapter ad = new SqlDataAdapter(com);

                ad.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    msg = "Success";
                }
                else
                {
                    msg = "Fail";
                }
                con.Close();

            }
            catch (Exception ex)
            {

                msg = "Exception";
            }


            return msg;


        }
        //login with Entity Framework
        public UserDetail LoginUser(UserDetail User)
        {
            //string msg = string.Empty;

            UserDetail UserInfo = _context.UserDetails.FirstOrDefault(U => (U.UserID == User.UserID && U.Password == User.Password));

            //if(UserInfo!=null)
            //{
            //    msg = "success";
            //}
            //else
            //{
            //    msg = "fail";
            //}
            return UserInfo;

        }
        public string RegisterUser(UserDetail usr)
        {
            string msg = string.Empty;
            usr.Password = "Welcome";
            usr.CreatedBy = "WebUser";
            usr.CreatedDate = DateTime.Now.ToString();

            _context.Add(usr);
            _context.SaveChanges();

            if (usr.ID > 0)
            {
                msg = "success";
                if (usr.IsActive == true)
                {
                    string subject = "Registration Successful";
                    string body = "User ID: " + usr.UserID + " Pasword: " + usr.Password;
                    CAssessmentUtility objUtility = new CAssessmentUtility();
                    objUtility.SendMail(subject, body, usr.Email);

                }
            }
            else
            {
                msg = "exception";
            }

            return msg;
        }

        public string UpdatePassword(UserDetail user, string OldPassword, string NewPassword, string ConfirmPassword)
        {
            string msg = string.Empty;

            if (NewPassword == ConfirmPassword)
            {
                UserDetail CurrentUser = _context.UserDetails.FirstOrDefault(CU => CU.UserID == user.UserID);

                if (CurrentUser.Password == OldPassword)
                {
                    CurrentUser.Password = NewPassword;
                    CurrentUser.ModifiedBy = CurrentUser.UserID;
                    CurrentUser.ModifiedDate = DateTime.Now.ToString();
                    CurrentUser.PasswordChangeDate = DateTime.Now.ToString();
                }

                _context.SaveChanges();
                msg = "Password is Updated";

            }
            else
            {
                msg = "Password and Confirm Password value does not match";
            }

            return msg;
        }

        public List<UserRole> GetUserRoles()
        {
            List<UserRole> RoleList = new List<UserRole>();
            RoleList = _context.UserRoles.ToList();

            return RoleList;
        }


        public string CreateRole(UserRole Role)
        {
            string msg = string.Empty;
            Role.CreatedDate = DateTime.Now.ToString();

            _context.Add(Role);
            _context.SaveChanges();

            if (Role.RoleID > 0)
            {
                msg = "success";
            }
            else
            {
                msg = "exception";
            }

            return msg;
        }


        public string EditUser(UserDetail user)
        {
            string msg = string.Empty;

            UserDetail CurrentUserDetails = _context.UserDetails.FirstOrDefault(CU => CU.UserID == user.UserID);

            CurrentUserDetails.Email = user.Email;
            CurrentUserDetails.Name = user.Name;
            CurrentUserDetails.IsActive = user.IsActive;

            _context.SaveChanges();
            msg = "User Data is Updated";

            if (user.IsActive == true)
            {

                string subject = "Registration Successful";
                string body = "User ID: " + user.UserID + " Pasword: " + user.Password;
                CAssessmentUtility objUtility = new CAssessmentUtility();
                objUtility.SendMail(subject, body, user.Email);
            }

            return msg;
        }

        public List<UserDetail> RegisteredUsersList()
        {
            List<UserDetail> objUsersList = new List<UserDetail>();

            objUsersList = _context.UserDetails.ToList<UserDetail>();


            return objUsersList;
        }

        public UserDetail EditUserDetail(int id)
        {

            UserDetail CurrentUserDetails = _context.UserDetails.FirstOrDefault(CU => CU.ID == id);


            return CurrentUserDetails;
        }
    }
}
