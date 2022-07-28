using Infrastructure.Abstract;
using Infrastructure.Factory;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAssessment.Controllers
{
    public class ContentManagementController : Controller
    {
        IContentManagementRepository _repo = new ContentManagementRepository();

        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            string UserName = TempData["LoggedInUser"].ToString();
            CaseStudyDetails objCaseStudy = new CaseStudyDetails();
            objCaseStudy.CreatedBy = UserName;
            objCaseStudy.Competencies = _repo.GetCompetencyInfo();

            TempData["LoggedInUser"] = UserName;
            return View(objCaseStudy);

        }

        [HttpGet]
        [ActionName("Edit")]
        public IActionResult Edit(int id)
        {
            CaseStudyDetails objCaseStudy = _repo.CaseStudyInfo(id);

            TempData["LoggedInUser"] = objCaseStudy.CreatedBy;

            return View(objCaseStudy);

        }


        [HttpPost]
        [ActionName("Edit")]
        public IActionResult Edit(CaseStudyDetails objCaseStudyInfo)
        {
            // Update without Factory Design pattern
            //string msg = _repo.UpdateCaseStudyInfo(objCaseStudyInfo);
            ContentManagerFactory objFactory = new ContentManagerFactory();
            // Update with Factory Design Pattern
            IContent objContent = objFactory.GetObjInstance(objCaseStudyInfo.CSID);
            objContent.AddEditContent(objCaseStudyInfo);

            TempData["LoggedInUser"] = objCaseStudyInfo.CreatedBy;

            return RedirectToAction("Details");

        }

        [HttpPost]
        public IActionResult Create(CaseStudyDetails objCaseStudyInfo)
        {
            string msg = "";
            // msg = _repo.InsertCaseStudyDetails(objCaseStudyInfo);
            ContentManagerFactory objFactory = new ContentManagerFactory();
            IContent objContent = objFactory.GetObjInstance(objCaseStudyInfo.CSID);
            objContent.AddEditContent(objCaseStudyInfo);

            if (msg.ToLower().Equals("success"))
            {
                CaseStudyDetails objCaseStudy = new CaseStudyDetails();
                objCaseStudy.Competencies = _repo.GetCompetencyInfo();
                TempData["LoggedinUser"] = objCaseStudyInfo.CreatedBy;

                objCaseStudy.CaseStudy = null;
                objCaseStudy.CaseStudySolution = null;
                return RedirectToAction("Create");
            }
            else
            {
                TempData["Info"] = "Data not inserted, try again latter";
                CaseStudyDetails objCaseStudy = new CaseStudyDetails();
                objCaseStudy.Competencies = _repo.GetCompetencyInfo();
                TempData["LoggedinUser"] = objCaseStudyInfo.CreatedBy;
                objCaseStudy.CaseStudy = null;
                objCaseStudy.CaseStudySolution = null;
                return RedirectToAction("Create");
            }

           // return View();


       
        }


        [HttpGet]
        public IActionResult Details()
        {
            string UserName = TempData["LoggedinUser"].ToString();
            List<CaseStudyDetails> objUsersList = new List<CaseStudyDetails>();

            objUsersList = _repo.CaseStudyList(UserName);

            TempData["LoggedinUser"] = UserName;

           return View(objUsersList); 


        }


        

    }
}
