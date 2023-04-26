using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Teacher : User
    {
        public List<Class> Classes { get; set; } = new List<Class>();
    }
}
