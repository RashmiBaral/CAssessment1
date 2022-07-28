using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class AssessmentDetails
    {
        [Key]
        public int AssessmentID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string AssessmentName { get; set; }

        [DataType(DataType.Date)]
        public DateTime AssmtDate { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Description { get; set; }

        [Column(TypeName = "bit")]
        public bool IsActive { get; set; }


    }
}
