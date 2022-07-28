using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class CaseStudyDetails
    {
        [Key]
        public int CSID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string CaseStudy { get; set; }

        [Column(TypeName = "int")]
        public int AssessmentID { get; set; }

        [Column(TypeName = "bit")]
        public bool ReviewStatus { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string CreatedBy { get; set; }

        [ForeignKey("CSID")]
        public List<CaseStudySolutions> CaseStudySolution { get; set; }

        public List<Competency> Competencies { get;set; }

        public bool Selected { get; set; }

    }
}
