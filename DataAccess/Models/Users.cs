using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Users
    {
        public int Id { get; set; } 

        public string Name { get; set; }

        public DateTime BornDate { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }

        public string Country { get; set; }

        public string Linkedin { get; set; }

        public string Instagram { get; set; }

        public string Github { get; set; }  

        public string Twitter { get; set; }

        public string Level { get; set; }
        public string Yetki { get; set; } = "admin";
        public DateTime SonGuncelleme { get; set; }

        public string ProfilPhoto { get; set; }

        public IList<Egitim> egitim{ get; set; }
        public IList<Projeler> projeler{ get; set; }
        public IList<DahaOnceCalistigiYerler> DahaOnceCalistigiYerlers{ get; set; }
        public IList<Sertifikalar> sertifikalar{ get; set; }
        public IList<Servisler> servisler{ get; set; }
        public IList<Yetenekler> yetenekler{ get; set; }



    }
}
