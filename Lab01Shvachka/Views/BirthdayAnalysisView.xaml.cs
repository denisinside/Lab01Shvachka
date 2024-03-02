using System.Windows.Controls;
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
    }
}
