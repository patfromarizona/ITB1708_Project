﻿using Microsoft.EntityFrameworkCore;
using TeamUP.Data.Party;

namespace TeamUP.Infra
{
    public sealed class TeamUPDb : DbContext
    {
        public TeamUPDb(DbContextOptions<TeamUPDb> options) : base(options) { }
        public DbSet<StudentData> Students { get; set; }
        public DbSet<TeamWorkData> TeamWorks { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            base.OnModelCreating(b);
            InitializeTables(b);
        }  

        public static void InitializeTables(ModelBuilder b) 
        {
            var s = nameof(TeamUPDb).Substring(0, 6);
            b?.Entity<StudentData>().ToTable(nameof(Students), s);
            b?.Entity<TeamWorkData>().ToTable(nameof(TeamWorks), s);
        }
    }
}