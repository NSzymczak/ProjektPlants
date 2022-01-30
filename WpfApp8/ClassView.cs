using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPlant
{
    public class ClassView
    {
        public int ID { get; set; }
        public string nameOfPlant { get; set; }
        public int water { get; set; }
        public string light { get; set; }
        public string subsoil { get; set; }
        public string action { get; set; }
        public string description { get; set; }

        public ClassView()
        {

        }
    }
}
