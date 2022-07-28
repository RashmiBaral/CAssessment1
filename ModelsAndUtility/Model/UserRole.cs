using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class UserRole
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }

    }
}
