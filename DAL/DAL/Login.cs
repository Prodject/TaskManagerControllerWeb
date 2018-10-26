using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class Login
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string EPosta { get; set; }
        public string FirmaAdi { get; set; }
        public string AdminYetki { get; set; }
        public string Client1 { get; set; }
        public string ClientYetki1 { get; set; }
        public string Client2 { get; set; }
        public string ClientYetki2 { get; set; }
        public string Client3 { get; set; }
        public string ClientYetki3 { get; set; }
        public string Client4 { get; set; }
        public string ClientYetki4 { get; set; }
        public string Client5 { get; set; }
        public string ClientYetki5 { get; set; }
        public string Guncelleme { get; set; }
        public string ProgramAdi { get; set; }
        public string PKomut { get; set; }
        public string CKomut { get; set; }
        public string EKomut { get; set; }
        public string resim { get; set; }
        public string yedek1 { get; set; }
        public string yedek2 { get; set; }
        public string yedek3 { get; set; }

    }
}
