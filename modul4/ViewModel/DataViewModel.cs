using modul4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4.ViewModel
{
    public class DataViewModel
    {
        public Athlete actual { get; set; }
        public void Setup(Athlete athlete)
        {
            this.actual = athlete;
        }

        public DataViewModel()
        {

        }
    }
}
