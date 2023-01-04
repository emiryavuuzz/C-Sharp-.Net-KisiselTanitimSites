using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Yetenekler
    {
        public int Id { get; set; }
        public string YetenekAdi { get; set; }
        public int TecrubeYili { get; set; }
        public int BilgiOrani { get; set; }
        public int UsersId { get; set; }

        public Users users { get; set; }

    }
}
