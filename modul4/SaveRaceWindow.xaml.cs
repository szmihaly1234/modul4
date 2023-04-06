using modul4.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace modul4
{
    /// <summary>
    /// Interaction logic for SaveRaceWindow.xaml
    /// </summary>
    public partial class SaveRaceWindow : Window
    {
        private ObservableCollection<Athlete> currentRace;
        public SaveRaceWindow(ObservableCollection<Athlete> race)
        {
            InitializeComponent();
            currentRace = race;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            string jsonData = JsonConvert.SerializeObject(currentRace);
            File.WriteAllText(race_name.Text + "_" + race_date.Text + ".json", jsonData);
            Close();
        }
    }
}
