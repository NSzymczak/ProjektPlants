using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektPlant
{
    public class ClassAction
    {
            public int ID { get; set; }
            public string nameOfPlant { get; set; }
            public string action { get; set; }
            public string description { get; set; }

            public ClassAction()
            {

            }

            public ClassAction(int id, string nazwarosliny, string action, string description)
            {
                this.ID = id;
                this.nameOfPlant = nazwarosliny;
                this.action = action;
                this.description = description;
            }

            public ClassAction(ClassAction c)
            {
                this.ID = c.ID;
                this.nameOfPlant = c.nameOfPlant;
                this.action = c.action;
                this.description = c.description;
            }
    }
}
