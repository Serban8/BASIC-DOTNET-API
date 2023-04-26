using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class GradesRepository : RepositoryBase<Class>
    {
        public GradesRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
