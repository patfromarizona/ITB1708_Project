using Microsoft.EntityFrameworkCore;
using TeamUP.Data.Party;

namespace TeamUP.Infra {
    public sealed class TeamUPDb : DbContext {
        public TeamUPDb(DbContextOptions<TeamUPDb> options) : base(options) { }
        public DbSet<StudentData>? Students { get; internal set; }
        public DbSet<TeamWorkData>? TeamWorks { get; internal set; }
        public DbSet<UniversityData>? Universities { get; internal set; }
        public DbSet<LocationData>? Locations { get; internal set; }
        public DbSet<UniversityStudentData>? UniversityStudent { get; internal set; }
        public DbSet<TeamWorkStudentData>? TeamWorkStudent { get; internal set; }

        protected override void OnModelCreating(ModelBuilder b) {
            base.OnModelCreating(b);
            InitializeTables(b);
        }

        public static void InitializeTables(ModelBuilder b) {
            var s = nameof(TeamUPDb)[0..^2];
            _ = (b?.Entity<StudentData>().ToTable(nameof(Students), s));
            _ = (b?.Entity<TeamWorkData>().ToTable(nameof(TeamWorks), s));
            _ = (b?.Entity<UniversityData>().ToTable(nameof(Universities), s));
            _ = (b?.Entity<LocationData>().ToTable(nameof(Locations), s));
            _ = (b?.Entity<UniversityStudentData>().ToTable(nameof(UniversityStudent), s));
            _ = (b?.Entity<TeamWorkStudentData>().ToTable(nameof(TeamWorkStudent), s));
        }
    }
}
