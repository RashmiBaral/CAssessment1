using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class AssessmentUserMapping
    {
        public int AssmtUserID { get; set; }
        public int AssmtID { get; set; }
        public int ID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
