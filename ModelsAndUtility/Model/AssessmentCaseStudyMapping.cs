using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class AssessmentCaseStudyMapping
    {
        [Key]
        public int ASCID { get; set; }
        public int AssmtID { get; set; }
        public int CSID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
