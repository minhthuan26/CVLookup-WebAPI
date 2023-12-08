using CVLookup_WebAPI.DBContext;
using CVLookup_WebAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FirstWebApi.Models.Database
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Account>()
            //    .HasIndex(prop => prop.Email)
            //    .IsUnique();
            modelBuilder.Entity<Account>()
                .HasIndex(prop => prop.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(prop => prop.Email)
                .IsUnique();        

			modelBuilder.Entity<UserRole>()
                .HasKey(prop => new { prop.RoleId, prop.UserId });

            modelBuilder.Entity<AccountUser>()
                .HasKey(prop => new { prop.AccountId, prop.UserId });

            modelBuilder.Entity<RecruitmentCV>()
                .HasKey(prop => new { prop.RecruitmentId, prop.CurriculumVitaeId });

            modelBuilder.Entity<Token>()
                .HasKey(prop => new { prop.UserId, prop.AccountId });

            modelBuilder.SeedData();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }


        #region DBSet
        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<JobAddress> JobAddress { get; set; }
        public DbSet<JobCareer> JobCareer { get; set; }
        public DbSet<JobPosition> JobPosition { get; set; }
        public DbSet<JobField> JobField { get; set; }
        public DbSet<JobForm> JobForm { get; set; }
        public DbSet<Recruitment> Recruitment { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<CurriculumVitae> CurriculumVitae { get; set; }
        public DbSet<AccountUser> AccountUser { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<RecruitmentCV> RecruitmentCV { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Token> Token { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<HubConnection> HubConnection { get; set; }
        #endregion
    }

    public class AppDBContextFactory : IDesignTimeDbContextFactory<AppDBContext>
    {
        public AppDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuilder.UseSqlServer("server=localhost,1433;database=CVLookup;uid=cvlookup-admin;pwd=cvlookup-sgu2023;encrypt=true;TrustServerCertificate=true");

            return new AppDBContext(optionsBuilder.Options);
        }
    }
}
