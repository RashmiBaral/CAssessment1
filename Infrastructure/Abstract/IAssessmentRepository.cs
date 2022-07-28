using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Abstract
{
    public interface IAssessmentRepository
    {
        string InsertCaseStudyDetails(AssessmentDetails objAssessment);
        List<AssessmentDetails> GetAssessmentInfo();
        List<UserDetail> GetUserDetailInfo();
        List<CaseStudyDetails> GetCaseStudyDetailInfo();
        string InsertAssessmentUserMap(AssessmentUserMappingVM objUserMapping);
        string InsertAssessmentCaseStudyMap(AssessmentCaseStudyMappingVM objCaseStudyMapping);
    }
}
