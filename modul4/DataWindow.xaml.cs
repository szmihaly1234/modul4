using modul4.Models;
using modul4.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        private Athlete athlete;
        public DataWindow(Athlete athlete)
        {
            InitializeComponent();
            var vm = new DataViewModel();
            vm.Setup(athlete);
            this.DataContext = vm;
        }

    }
}
