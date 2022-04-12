using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Interface.Data
{
    public class QuizDbContextFactory : IDesignTimeDbContextFactory<QuizDbContext>
    {
        public QuizDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuizDbContext>();
            optionsBuilder.UseSqlServer("server=DESKTOP-4UGJ1EH\\SQLEXPRESS;Database=QuizDB;Trusted_Connection=True;MultipleActiveResultSets=True;");

            return new QuizDbContext(optionsBuilder.Options);
        }
    }
}
