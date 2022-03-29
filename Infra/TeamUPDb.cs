using Microsoft.EntityFrameworkCore;
using TeamUP.Data.Party;

namespace TeamUP.Infra
{
    public sealed class TeamUPDb : DbContext
    {
        public TeamUPDb(DbContextOptions<TeamUPDb> options) : base(options) { }
        public DbSet<StudentData>? Students { get; set; }
        public DbSet<TeamWorkData>? TeamWorks { get; set; }
        public DbSet<UniversityData>? Universities { get; set; }
        public DbSet<ScholarshipData>? Scholarships { get; set; }
        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            InitializeTables(b);
        }  

        public static void InitializeTables(ModelBuilder b) 
        {
            var s = nameof(TeamUPDb)[0..^2];
            _ = (b?.Entity<StudentData>().ToTable(nameof(Students), s));
            _ = (b?.Entity<TeamWorkData>().ToTable(nameof(TeamWorks), s));
            _ = (b?.Entity<UniversityData>().ToTable(nameof(Universities), s));
            _ = (b?.Entity<ScholarshipData>().ToTable(nameof(Scholarships), s));
        }
    }
}
