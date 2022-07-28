using Infrastructure.Abstract;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAssessment.Controllers
{
    public class AssessmentDetailsController : Controller
    {
        IAssessmentRepository _repo = new AssessmentRepository();
        public IActionResult Create()
        {
            return View();
        }




        [HttpPost]
        public IActionResult Create(AssessmentDetails objAssessment)
        {
            string message=_repo.InsertCaseStudyDetails(objAssessment);
            return RedirectToAction("Create");
        }

        public IActionResult AssessmentUserMap()
        {
            AssessmentUserMappingVM objMapping = new AssessmentUserMappingVM();

            objMapping.AssessmentInfo = _repo.GetAssessmentInfo();
            objMapping.UserInfo = _repo.GetUserDetailInfo();
            return View(objMapping);
        }
        [HttpPost]
        public IActionResult AssessmentUserMap(AssessmentUserMappingVM objUserMapping)
        {
            _repo.InsertAssessmentUserMap(objUserMapping);

            return RedirectToAction("AssessmentUserMap");
        }


        public IActionResult AssessmentCaseStudyMap()
        {
            AssessmentCaseStudyMappingVM objMapping = new AssessmentCaseStudyMappingVM();

            objMapping.AssessmentInfo = _repo.GetAssessmentInfo();
            objMapping.CaseStudyInfo = _repo.GetCaseStudyDetailInfo();
            return View(objMapping);
        }
        [HttpPost]
        public IActionResult AssessmentCaseStudyMap(AssessmentCaseStudyMappingVM objUserMapping)
        {
            _repo.InsertAssessmentCaseStudyMap(objUserMapping);

            return RedirectToAction("AssessmentCaseStudyMap");
        }
    }
}
