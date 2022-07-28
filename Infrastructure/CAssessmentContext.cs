using CAssessmentKeyVault;
using Microsoft.EntityFrameworkCore;
using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
   public class CAssessmentContext : DbContext
    {
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CaseStudyDetails> CaseStudyDetails { get; set; }
        public DbSet<CaseStudySolutions> CaseStudySolutions { get; set; }

        public DbSet<CaseStudyDetails> CaseStudyInfo { get; set; }
        public DbSet<CaseStudySolutions> CaseStudySolutionInfo { get; set; }
        public DbSet<Competency> CompetencyInfo { get; set; }

        public DbSet<AssessmentDetails> AssessmentDetail { get; set; }

        public DbSet<AssessmentUserMapping> AssessmentUserMap { get; set; }
        public DbSet<AssessmentCaseStudyMapping> AssessmentCaseStudyMap { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(new CADBConnection().ConString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
