using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class DahaOnceCalistigiYerler
    {
        public int Id { get; set; }
        public string kurumAdi { get; set; }
        public string CalistigiRutbe { get; set; }
        public string CalistigiAlan { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public DateTime IstenCikisTarihi { get; set; }
        public string IsYeriKonumu { get; set; }
        public string IsYeriLogo { get; set; }

        public int UsersId { get; set; }
        public Users users { get; set; }

    }
}
