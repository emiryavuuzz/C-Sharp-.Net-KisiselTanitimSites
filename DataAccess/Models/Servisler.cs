using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Servisler
    {
        public int Id { get; set; }
        public string ServisAdi { get; set; }
        public string ServisAciklama { get; set; }
        public string ServisFoto { get; set; }

        public int UsersId { get; set; }
        public Users users { get; set; }
    }
}
