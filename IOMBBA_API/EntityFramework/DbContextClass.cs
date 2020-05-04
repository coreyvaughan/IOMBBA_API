using Microsoft.EntityFrameworkCore;
using Objects.Models;

namespace IOMBBA_System.Models
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options)
            : base(options)
        {
            
        }

        public DbSet<MemberModel> Member { get; set; }
        public DbSet<TeamModel> Team { get; set; }
        public DbSet<MemberTeamModel> MemberTeam { get; set; }
        public DbSet<FixtureModel> Fixture { get; set; }
        public DbSet<PeriodModel> Period { get; set; }
        public DbSet<CompetitionModel> Competition { get; set; }
        public DbSet<GameplayStatModel> GameplayStat { get; set; }
        public DbSet<ShotModel> Shot { get; set; }
        public DbSet<FoulModel> Foul{ get; set; }
    }
}
