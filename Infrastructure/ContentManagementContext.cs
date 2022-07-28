using Microsoft.EntityFrameworkCore;
using ModelsAndUtility.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    class ContentManagementContext : DbContext
    {
        //public DbSet<CaseStudyDetails> CaseStudyInfo { get; set; }
        //public DbSet<CaseStudySolutions> CaseStudySolutionInfo { get; set; }
        //public DbSet<Competency> CompetencyInfo { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=DESKTOP-I3BL8NK\\LOCAL;Database=ProductDetailDB;Integrated Security=true;");
        //    }

        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
