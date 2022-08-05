using enairaUHC.src;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace enairaUHC.AppDbContext
{
    public class EnairaDbContextFactory:IDesignTimeDbContextFactory<EnairaDbContext>
    {
        public EnairaDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return new EnairaDbContext(new DbContextOptionsBuilder<EnairaDbContext>().Options, configuration);
        }
    }
}
