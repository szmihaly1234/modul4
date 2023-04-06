using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace modul4.Models
{
    public class Athlete : ObservableObject
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        private int personalBest;
        public int PersonalBest
        {
            get { return personalBest; }
            set { SetProperty(ref personalBest, value); }
        }
        private int yearlyBest;
        public int YearlyBest
        {
            get { return yearlyBest; }
            set { SetProperty(ref yearlyBest, value); }
        }
        private string club;
        public string Club
        {
            get { return club; }
            set { SetProperty(ref club, value); }
        }
        private int raceNumber;
        public int RaceNumber
        {
            get { return raceNumber; }
            set { SetProperty(ref raceNumber, value); }
        }
        public int Value
        {
            get { return yearlyBest * personalBest; }
        }
        private bool canRace;
        public bool CanRace
        {
            get { return canRace; }
            set
            {
                SetProperty(ref canRace, value);
            }
        }

        public Athlete(string Name, int PersonalBest, int YearlyBest, string Club, int RaceNumber, bool CanRace)
        {
            this.name = Name;
            this.personalBest = PersonalBest;
            this.yearlyBest = YearlyBest;
            this.club = Club;
            this.raceNumber = RaceNumber;
            this.canRace = CanRace;
        }

        public Athlete GetCopy()
        {
            return new Athlete(this.Name, this.PersonalBest, this.YearlyBest, this.Club, this.RaceNumber, this.canRace);
        }
    }
}
