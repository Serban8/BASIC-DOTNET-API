using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GradeService
    {
        private readonly DataLayer.UnitOfWork unitOfWork;

        public GradeService(DataLayer.UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
