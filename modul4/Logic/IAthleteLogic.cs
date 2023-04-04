using modul4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4.Logic
{
    public interface IAthleteLogic
    {
        void AddToRace(Athlete athlete);
        void RemoveFromRace(Athlete athlete);
        void SetupCollections(IList<Athlete> athletes, IList<Athlete> race);
    }
}
