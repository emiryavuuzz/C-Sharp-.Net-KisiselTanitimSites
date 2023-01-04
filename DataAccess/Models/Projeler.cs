using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Projeler
    {
        public int Id { get; set; }
        public string ProjeAdi { get; set; }
        public string ProjeAmaci { get; set; }
        public string ProjeCategory { get; set; }
        public string ProjeninYapildigiKurum { get; set; }
        public string ProjeAlanAdi { get; set; }
        public string ProjePhoto { get; set; }
        public DateTime YapilisTarihi { get; set; }

        public int UsersId { get; set; }
        public Users users { get; set; }
    }
}
