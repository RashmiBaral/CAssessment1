using Infrastructure.Abstract;
using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
    public class AssessmentRepository : IAssessmentRepository
    {
        CAssessmentContext _context = new CAssessmentContext();
        public string InsertCaseStudyDetails(AssessmentDetails objAssessment)
        {
            string msg = string.Empty;
            objAssessment.AssessmentName = objAssessment.AssessmentName;
            objAssessment.AssmtDate = objAssessment.AssmtDate;
            objAssessment.Description = objAssessment.Description;
            objAssessment.IsActive = objAssessment.IsActive;


            //Add Table no1
            _context.Add(objAssessment);
            _context.SaveChanges();

            if (objAssessment.AssessmentID > 0)
            {
                //Add Table no 2 when CSID>0
                msg = "success";

            }
            else
            {
                msg = "exception";
            }

            return msg;
        }

        public List<AssessmentDetails> GetAssessmentInfo()
        {
            List<AssessmentDetails> objAssessmentDetails = _context.AssessmentDetail.ToList();
            return objAssessmentDetails;
        }

        public List<UserDetail> GetUserDetailInfo()
        {
            List<UserDetail> objUserDetails = _context.UserDetails.ToList();
            return objUserDetails;
        }

        public List<CaseStudyDetails> GetCaseStudyDetailInfo()
        {
            List<CaseStudyDetails> objCaseStudyDetails = _context.CaseStudyDetails.ToList();
            return objCaseStudyDetails;
        }
        public string InsertAssessmentUserMap(AssessmentUserMappingVM objUserMapping)
        {
            string msg = string.Empty;

            
            

            foreach (var item in objUserMapping.UserInfo)
            {
                if(item.selected==true)
                {
                    AssessmentUserMapping objMapping = new AssessmentUserMapping();
                    objMapping.AssmtID = objUserMapping.AssessmentID;
                    objMapping.AssmtUserID = item.ID;

                   var objUsersList = _context.AssessmentUserMap.Where(AsstID => AsstID.AssmtID== objMapping.AssmtID & AsstID.AssmtUserID == objMapping.AssmtUserID);

                    if(objUsersList.Count()==0)
                    {
                        _context.Add(objMapping);
                    }
                                        
                }
                
            }

            _context.SaveChanges();
            //Add Table no1



            // objMapping.AssessmentInfo = _repo.GetAssessmentInfo();
            //objMapping.UserInfo = _repo.GetUserDetailInfo();


            return msg;
        }


        public string InsertAssessmentCaseStudyMap(AssessmentCaseStudyMappingVM objCaseStudyMapping)
        {
            string msg = string.Empty;


            

            foreach (var item in objCaseStudyMapping.CaseStudyInfo)
            {
                if (item.Selected == true)
                {
                    AssessmentCaseStudyMapping objMapping = new AssessmentCaseStudyMapping();

                    objMapping.AssmtID = objCaseStudyMapping.AssessmentID;
                    objMapping.CSID = item.CSID;

                    var objUsersList = _context.AssessmentCaseStudyMap.Where(AsstID => AsstID.AssmtID == objMapping.AssmtID & AsstID.CSID == objMapping.CSID);

                    if (objUsersList.Count() == 0)
                    {
                        _context.Add(objMapping);
                    }

                }

        }

        _context.SaveChanges();
           // Add Table no1






            return msg;
        }

    }
}
