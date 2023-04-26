using DataLayer.Entities;

namespace DataLayer.Repositories
{
    public class TeachersRepository : RepositoryBase<Teacher>
    {
        private readonly AppDbContext dbContext;
        public TeachersRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        public Teacher GetByEmail(string email)
        {
            return dbContext.Teachers.FirstOrDefault(s => s.Email == email);
        }

    }
}
