using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAL
{
    public class Uygulamalar
    {
        public int ID { get; set; }
        public int Userid { get; set; }
        public string UygulamaAdi { get; set; }
        public string Cpu { get; set; }
        public string Ram { get; set; }
        public bool IsAcik { get; set; }
        public string AcilmaZamani { get; set; }
        public string KapanmaZamani { get; set; }
        public bool IsServis { get; set; }
        public string PUzanti { get; set; }
    }
}
