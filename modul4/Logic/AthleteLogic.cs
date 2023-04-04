using Microsoft.Toolkit.Mvvm.Messaging;
using modul4.Models;
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

        public AthleteLogic(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void AddToRace(Athlete athlete)
        {
            race.Add(athlete);
            messenger.Send("Athlete added", "RaceInfo");
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
