using Microsoft.Toolkit.Mvvm.Messaging;
using modul4.Models;
using modul4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul4.Logic
{
    public class AthleteLogic : IAthleteLogic
    {
        IList<Athlete> athletes;
        IList<Athlete> race;
        IMessenger messenger;
        IGetAthleteInfo getInfo;

        public AthleteLogic(IMessenger messenger, IGetAthleteInfo info)
        {
            this.messenger = messenger;
            this.getInfo = info;
        }

        public void AddToRace(Athlete athlete)
        {
            race.Add(athlete.GetCopy());
            messenger.Send("Athlete added", "RaceInfo");
        }

        public void GetAthleteInfo(Athlete athlete)
        {
            getInfo.GetInfo(athlete);
        }

        public void RemoveFromRace(Athlete athlete)
        {
            race.Remove(athlete);
            messenger.Send("Athlete removed", "RaceInfo");
        }


        public void SetupCollections(IList<Athlete> athletes, IList<Athlete> race)
        {
            this.athletes = athletes;
            this.race = race;
        }
    }
}
