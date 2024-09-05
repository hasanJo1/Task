using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EmployeeContextFactory : IDesignTimeDbContextFactory<EmployeeManagementContext>
    {
        public EmployeeManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeManagementContext>();
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=EmployeeDB;Persist Security Info=False;User ID=sa;Password=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

            return new EmployeeManagementContext(optionsBuilder.Options);
        }
    }
}
