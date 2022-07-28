using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class CaseStudySolutions
    {
        [Key]
        public int CSSID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Solution { get; set; }

        [Column(TypeName = "int")]
        
        public int CSID { get; set; }

        [Column(TypeName = "int")]
        public int CompetencyID { get; set; }

        


    }
}