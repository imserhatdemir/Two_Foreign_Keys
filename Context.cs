using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            OptionsBuilder.UseSqlServer("server=SQLEXPRESS;database=ForeignDB;integrated security=true;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(x => x.HomeTeam)
                .WithMany(y => y.HomeMatches)
                .HasForeignKey(z => z.HomeTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Match>()
                .HasOne(x=>x.GuestTeam)
                .WithMany(y=>y.AwayMatches)
                .HasForeignKey(z=>z.GuestTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
       




        public DbSet<Match> matches { get; set; }
        public DbSet<Team> teams { get; set; }


        
    }
}
