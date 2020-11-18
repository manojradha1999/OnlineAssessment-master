using System.Data.Entity;


namespace OnlineAssessmentApplication.DomainModel
{
    public class AssessmentDbContext : DbContext
    {
        public AssessmentDbContext() : base("connectionStringToDB")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
