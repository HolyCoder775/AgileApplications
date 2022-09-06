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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=dogus; database=CoreHappinessMetricDb; integrated security=true");
        }
        public DbSet<HappinessMetricCategory> HappinessMetricCategories { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<ScrumTeam> ScrumTeams { get; set; }
        public DbSet<ScrumTeamUser> ScrumTeamUsers { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserSprintHappinessMetricCategory> UserSprintHappinessMetricCategories { get; set; }
    }
}
