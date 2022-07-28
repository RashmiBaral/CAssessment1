using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Abstract
{
    public interface IContentManagementRepository
    {
        public CaseStudyCompetencyRepoModel GetCaseStudyDetails();
        public string InsertCaseStudyDetails(CaseStudyDetails objCaseStudy);
        public List<Competency> GetCompetencyInfo();

        public List<CaseStudyDetails> CaseStudyList(string UserID);

        public CaseStudyDetails CaseStudyInfo(int CSID);

        public string UpdateCaseStudyInfo(CaseStudyDetails objCaseStudyDetails);


    }
}
