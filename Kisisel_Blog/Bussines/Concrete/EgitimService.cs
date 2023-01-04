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
    public class EgitimService:Repository<Egitim>,IEgitimService
    {
        public EgitimService(BlogContext contex) : base(contex)
        {

        }
    }
}
