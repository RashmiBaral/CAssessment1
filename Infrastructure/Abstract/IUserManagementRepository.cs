using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Abstract
{
    public interface IUserManagementRepository
    {
        string AuthenticateUser(UserDetail User);
        public UserDetail LoginUser(UserDetail User);
        string RegisterUser(UserDetail usr);
        public string UpdatePassword(UserDetail user, string OldPassword, string NewPassword, string ConfirmPassword);
        public List<UserRole> GetUserRoles();
        public string CreateRole(UserRole Role);
        public string EditUser(UserDetail user);
        public List<UserDetail> RegisteredUsersList();
        UserDetail EditUserDetail(int id);

    }
}
