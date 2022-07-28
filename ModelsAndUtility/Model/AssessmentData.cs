using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class AssessmentData
    {
        public CaseStudyDetails Assessment { get; set; }
        public List<CaseStudySolutions> lstSolution {get;set;}

        public List<Competency> Competency { get; set; }



    }
}
