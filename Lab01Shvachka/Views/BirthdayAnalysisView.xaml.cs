using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Lab01Shvachka.ViewModels;

namespace Lab01Shvachka.Views
{
    public partial class BirthdayAnalysisView : UserControl
    {
        private BirthdayAnalysisViewModel _viewModel;


        public BirthdayAnalysisView()
        {
            InitializeComponent();
            DataContext = _viewModel = new BirthdayAnalysisViewModel();
        }

        private void BirthdaysList_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            ListView listView = sender as ListView;
            GridView gView = listView.View as GridView;

            var workingWidth = listView.ActualWidth;

            gView.Columns[0].Width = workingWidth * 0.25;
            gView.Columns[1].Width = workingWidth * 0.25;
            gView.Columns[2].Width = workingWidth * 0.25;
            gView.Columns[3].Width = workingWidth * 0.25;
        }
    }
}
