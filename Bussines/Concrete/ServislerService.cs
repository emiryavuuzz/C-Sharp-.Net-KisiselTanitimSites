﻿using Bussines.Abstract;
using DataAccess.Concrete;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class ServislerService:Repository<Servisler>,IServislerService
    {
        public ServislerService(BlogContext contex) : base(contex)
        {

        }
    }
}
