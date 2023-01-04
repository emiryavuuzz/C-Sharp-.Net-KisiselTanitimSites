using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Sertifikalar
    {
        public int Id { get; set; }
        public string SertifikaAdi { get; set; }
        public string VerenKurum { get; set; }
        public DateTime AlinanTarih { get; set; }
        public int UsersId { get; set; }

        public Users users{ get; set; } 
    }
}
