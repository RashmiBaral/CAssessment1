using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsAndUtility.Model
{
    public class CaseStudyCompetencyRepoModel
    {
        public List<CaseStudyDetails> CaseStudyList { get; set; }
        public List<CaseStudySolutions> CaseStudySolutionsList { get; set; }
        public List<Competency> CompetenciesList { get; set; }

    }
}
