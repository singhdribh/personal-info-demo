using Microsoft.EntityFrameworkCore;
using PersonalInfomrationProject.Data.Entities;
using System.Threading.Tasks;

namespace PersonalInfomrationProject.Data
{
    public class ApplicationDbContext : DbContext
    {
       

        public DbSet<PersonalInformationEntity> PersonalInformationEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=database.db");
            base.OnConfiguring(optionsBuilder);
        }


        public Task DatabaseMigrateAsync()
        {
            return Database.MigrateAsync();
        }
    }
}
