using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class AssessmentCaseStudyMappingVM
    {
        public int AssessmentID { get; set; }
        public List<AssessmentDetails> AssessmentInfo { get; set; }
        public List<CaseStudyDetails> CaseStudyInfo { get; set; }
    }
}
