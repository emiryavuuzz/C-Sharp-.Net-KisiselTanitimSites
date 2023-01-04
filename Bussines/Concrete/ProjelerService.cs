using Bussines.Abstract;
using DataAccess.Concrete;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class ProjelerService:Repository<Projeler>,IProjelerService
    {
        public ProjelerService(BlogContext contex) : base(contex)
        {

        }
    }
}
