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
        public string Name { get; set; }
        public int PersonalBest { get;set; }
        public int YearlyBest { get;set; }
        public string Club { get; set; }
        public int RaceNumber { get; set; }
        public int Value { get; set; }
        public bool CanRace { get; set; }

        public Athlete(string Name, int PersonalBest, int YearlyBest, string Club, int RaceNumber)
        {
            this.Name = Name;
            this.PersonalBest = PersonalBest;
            this.YearlyBest = YearlyBest;
            this.Club = Club;
            this.RaceNumber = RaceNumber;
            Value = YearlyBest * PersonalBest;
        }

        public Athlete GetCopy()
        {
            return new Athlete(this.Name, this.PersonalBest, this.YearlyBest, this.Club, this.RaceNumber);
        }
    }
}
