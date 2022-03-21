using MahApps.Metro.Controls.Dialogs;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wordle.UI.Model;
using Wordle.UI.ViewModel;

namespace Wordle.UI.View
{
    /// <summary>
    /// Lógica de interacción para WordleControl.xaml
    /// </summary>
    public partial class WordleControl : UserControl
    {
        public WordleControl(string word)
        {
            InitializeComponent();
            DataContext = new WordleViewModel(new WordleModel { Word = word }, DialogCoordinator.Instance);
        }
    }
}
