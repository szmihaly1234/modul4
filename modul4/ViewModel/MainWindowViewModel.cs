using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using modul4.Logic;
using modul4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace modul4.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {
        public IAthleteLogic logic;
        public ObservableCollection<Athlete> Athletes { get; set; }
        public ObservableCollection<Athlete> Race { get; set; }
        private Athlete selectedFromAthletes;
        public Athlete SelectedFromAthletes
        {
            get { return selectedFromAthletes; }
            set
            {
                SetProperty(ref selectedFromAthletes, value);
                (AddToRaceCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetInfo as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        private Athlete selectedFromRace;
        public Athlete SelectedFromRace
        {
            get { return selectedFromRace; }
            set
            {
                SetProperty(ref selectedFromRace, value);
                (RemoveFromRaceCommand as RelayCommand).NotifyCanExecuteChanged();
                (GetInfo as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public ICommand AddToRaceCommand { get; set; }
        public ICommand RemoveFromRaceCommand { get; set; }
        public ICommand Load { get; set; }
        public ICommand GetInfo { get; set; }
        public ICommand Save { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
            : this(IsInDesignMode ? null : Ioc.Default.GetService<IAthleteLogic>())
        {

        }

        public MainWindowViewModel(IAthleteLogic athleteLogic)
        {
            this.logic = athleteLogic;
            Athletes = new ObservableCollection<Athlete>();
            Race = new ObservableCollection<Athlete>();

            

            logic.SetupCollections(Athletes,Race);

            AddToRaceCommand = new RelayCommand(
                () => logic.AddToRace(SelectedFromAthletes),
                () => SelectedFromAthletes != null);

            RemoveFromRaceCommand = new RelayCommand(
                ()=> logic.RemoveFromRace(SelectedFromRace),
                () => SelectedFromRace != null);

            Load = new RelayCommand(
                () => {
                    Athletes.Add(new Athlete("Ügyes Béla", 130, 119, "random club", 1,true));
                    Athletes.Add(new Athlete("Béna Bendegúz", 150, 119, "random club1", 2,false));
                    Athletes.Add(new Athlete("Lakatos Lóci", 150, 119, "random club2", 4, true));
                    Athletes.Add(new Athlete("Lakatos Kemál", 10, 1, "random club3", 14, false));
                    Athletes.Add(new Athlete("Korsós Anna", 1150, 1119, "random club2", 42, true));
                    Athletes.Add(new Athlete("Vajas István", 1350, 1219, "random club1", 46, true));
                    Athletes.Add(new Athlete("Nagy Patrik", 1150, 1139, "random club3", 144, true));
                    Athletes.Add(new Athlete("Kalányos Vajk", 150, 1199, "random club5", 3, true));
                    (Load as RelayCommand).NotifyCanExecuteChanged();
                },
                ()=>Athletes.Count() == 0);


            GetInfo = new RelayCommand(
                () => logic.GetAthleteInfo(SelectedFromAthletes),
                () => SelectedFromAthletes != null);


            Save = new RelayCommand(() => {
                string jsonData = JsonConvert.SerializeObject(Race);
                File.WriteAllText("race.json", jsonData);
                (Save as RelayCommand).NotifyCanExecuteChanged();
            });

            Messenger.Register<MainWindowViewModel, string, string>(this, "RaceInfo", (recipient, msg) =>
            {
                
            });

        }
    }
}
