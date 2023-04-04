using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using modul4.Logic;
using modul4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace modul4.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IAthleteLogic logic;
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
            }
        }
        private Athlete selectedFromRace;
        private IAthleteLogic? athleteLogic;

        public Athlete SelectedFromRace
        {
            get { return selectedFromRace; }
            set
            {
                SetProperty(ref selectedFromRace, value);
                (RemoveFromRaceCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public ICommand AddToRaceCommand { get; set; }
        public ICommand RemoveFromRaceCommand { get; set; }
        public ICommand Load { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IAthleteLogic>())
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
                    Athletes.Add(new Athlete("asd", 130, 119, "random club", 1));
                    Athletes.Add(new Athlete("asdfgasdf", 150, 119, "random club", 1));
                    (Load as RelayCommand).NotifyCanExecuteChanged();
                },
                ()=>Athletes.Count() == 0);
                

            Messenger.Register<MainWindowViewModel, string, string>(this, "RaceInfo", (recipient, msg) =>
            {
                
            });

        }
    }
}
