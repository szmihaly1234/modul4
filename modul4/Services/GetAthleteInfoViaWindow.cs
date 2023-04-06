using modul4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4.Services
{
    public class GetAthleteInfoViaWindow : IGetAthleteInfo
    {
        public void GetInfo(Athlete current)
        {
            new DataWindow(current).ShowDialog();
        }
    }
}
