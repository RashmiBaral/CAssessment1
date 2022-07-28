using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class UserDetail
    {
        [Key]
        public int ID { get; set; }
      
        public string UserID { get; set; }
        
        public string Password { get; set; }
        
        public string Name { get; set; }
        
        public string EmpID { get; set; }
        
        public string Email { get; set; }
        
        public int RoleID { get; set; }
        
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string PasswordChangeDate { get; set; }

        public List<UserRole> UserRoles { get; set; }

        [Display(Name="Upload User Photo")]
        [NotMapped]
        public IFormFile UserPhoto { get; set; }

        public bool selected { get; set; }

    }
}
