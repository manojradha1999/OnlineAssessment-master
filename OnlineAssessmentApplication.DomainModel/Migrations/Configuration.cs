namespace OnlineAssessmentApplication.DomainModel.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineAssessmentApplication.DomainModel.AssessmentDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OnlineAssessmentApplication.DomainModel.AssessmentDbContext";
        }

        protected override void Seed(OnlineAssessmentApplication.DomainModel.AssessmentDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
