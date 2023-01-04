using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Egitim 
    {
        public int Id { get; set; }
        public string OkulAdi { get; set; }
        public string BolumAdi { get; set; }
        public DateTime MezuniyetYili { get; set; }
        public DateTime BaslamaYili { get; set; }

        public int UsersId { get; set; }

        public Users users { get; set; }

    }
}
