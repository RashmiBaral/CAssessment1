using Infrastructure.Abstract;
using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repository
{
   public class AddContent : IContent
    {
        CAssessmentContext _context = new CAssessmentContext();
        //public CaseStudyCompetencyRepoModel GetCaseStudyDetails()
        //{
        //    CaseStudyCompetencyRepoModel objWrapper = new CaseStudyCompetencyRepoModel();
        //    try
        //    {
        //        List<CaseStudyDetails> lstCaseStudy = _context.CaseStudyInfo.ToList();
        //        List<CaseStudySolutions> lstCaseStudySolution = _context.CaseStudySolutionInfo.ToList();

        //        List<Competency> lstCompetency = _context.CompetencyInfo.ToList();

        //    }
        //    catch (Exception ex)
        //    {

        //        string msg = ex.Message;
        //    }



        //    return objWrapper;

        //}


        public string InsertCaseStudyDetails(CaseStudyDetails objCaseStudy)
        {
            string msg = string.Empty;
            objCaseStudy.AssessmentID = 1;
            objCaseStudy.ReviewStatus = false;



            //Add Table no1
            _context.Add(objCaseStudy);
            _context.SaveChanges();

            if (objCaseStudy.CSID > 0)
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


        //public List<Competency> GetCompetencyInfo()
        //{
        //    List<Competency> CompetencyList = new List<Competency>();
        //    CompetencyList = _context.CompetencyInfo.ToList();

        //    return CompetencyList;
        //}

        //public List<CaseStudyDetails> CaseStudyList(string UserID)
        //{
        //    List<CaseStudyDetails> objUsersList = new List<CaseStudyDetails>();

        //    objUsersList = _context.CaseStudyDetails.Where(UID => UID.CreatedBy == UserID).OrderByDescending(uid => uid.CSID).ToList();


        //    return objUsersList;
        //}

        //public CaseStudyDetails CaseStudyInfo(int CSID)
        //{
        //    CaseStudyDetails objCaseStudy = new CaseStudyDetails();

        //    objCaseStudy = _context.CaseStudyDetails.Where(UID => UID.CSID == CSID).FirstOrDefault();

        //    List<CaseStudySolutions> objCaseStudySolutions = new List<CaseStudySolutions>();
        //    objCaseStudySolutions = _context.CaseStudySolutions.Where(UID => UID.CSID == CSID).ToList();

        //    List<Competency> objCompetencies = new List<Competency>();
        //    objCompetencies = _context.CompetencyInfo.ToList();

        //    objCaseStudy.CaseStudySolution = objCaseStudySolutions;
        //    objCaseStudy.Competencies = objCompetencies;


        //    return objCaseStudy;
        //}

        //public string UpdateCaseStudyInfo(CaseStudyDetails objCaseStudyDetails)
        //{
        //    string msg = string.Empty;

        //    //Get Exisitng Object
        //    //Assign values
        //    //Save values
        //    CaseStudyDetails CurrentCaseStudy = _context.CaseStudyDetails.FirstOrDefault(CU => CU.CSID == objCaseStudyDetails.CSID);
        //    //CurrentCaseStudy = objCaseStudyDetails;
        //    //_context.Update(objCaseStudyDetails);

        //    //_context.Update(objCaseStudyDetails);

        //    CurrentCaseStudy.CaseStudy = objCaseStudyDetails.CaseStudy;

        //    _context.SaveChanges();

        //    List<CaseStudySolutions> CurrentStudySolutions = new List<CaseStudySolutions>();
        //    CurrentStudySolutions = _context.CaseStudySolutions.Where(UID => UID.CSID == objCaseStudyDetails.CSID).ToList();

        //    for (int i = 0; i < 4; i++)
        //    {
        //        CurrentStudySolutions[i].Solution = objCaseStudyDetails.CaseStudySolution[i].Solution;
        //        CurrentStudySolutions[i].CompetencyID = objCaseStudyDetails.CaseStudySolution[i].CompetencyID;
        //    }



        //    _context.SaveChanges();

        //    return msg; ;

        //}

        public void AddEditContent(CaseStudyDetails objContent)
        {
            InsertCaseStudyDetails(objContent);
        }
    }
}
