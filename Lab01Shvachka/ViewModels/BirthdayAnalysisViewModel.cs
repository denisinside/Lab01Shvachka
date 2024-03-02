using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Lab01Shvachka.Models;
using Lab01Shvachka.Services;

namespace Lab01Shvachka.ViewModels
{
    public class BirthdayAnalysisViewModel : INotifyPropertyChanged
    {

        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        #region Commands
        private RelayCommand<object> _calculate;
        private RelayCommand<object> _clear; 

        public RelayCommand<object> CalculateCommand
        {
            get
            {
                return _calculate ??= new RelayCommand<object>(_ => AddBirthday());
            }
        }
        public RelayCommand<object> ClearCommand
        {
            get
            {
                return _clear ??= new RelayCommand<object>(_ => ClearData());
            }
        }
        #endregion

        private ObservableCollection<BirthdayAnalysisModel> _dates;
        private DateAnalyser _dateAnalyser;
        private Visibility _visibility;
        private String _resultText;
        private int _listViewWidth;
        private int _listColumnWidth;
        public BirthdayAnalysisViewModel()
        {
            SelectedDate = DateTime.Today;
            _dates = new();
            Visibility = Visibility.Hidden;
            ResultText = "\n\n\n\n";
        }

        public ObservableCollection<BirthdayAnalysisModel> Dates 
        { 
            get 
            {
                return _dates; 
            }
            set 
            {
                _dates = value;
            } 
        }
        
        public DateTime SelectedDate
        {
            get; 
            set; 
        }
        public BirthdayAnalysisModel ModelToDisplay
        {
            get; set;
        }
        public Visibility Visibility
        {  
           get
            {
                return _visibility;
            }
           set
            {
                _visibility = value;
                OnPropertyChanged();
            }
        }
        public String ResultText
        {
            get
            {
                return _resultText;
            }
            set
            {
                _resultText = value;
                OnPropertyChanged();
            }
        }
        public int ListViewWidth
        {
            get { return _listViewWidth; }
            set
            {
                MessageBox.Show($"_listColumnWidth");
                _listViewWidth = value;
                ListColumnWidth = _listViewWidth / 4;
                OnPropertyChanged();
            }
        }

        public int ListColumnWidth
        {
            get { return _listColumnWidth; }
            set
            {
                _listColumnWidth = value;

                OnPropertyChanged();
            }
        }

        public void ClearData()
        {
            Dates.Clear();
            Visibility = Visibility.Hidden;
        }

        public void AddBirthday()
        {
            BirthdayAnalysisModel birthdayAnalysisModel = new(SelectedDate);
            try
            {
                _dateAnalyser = new DateAnalyser(birthdayAnalysisModel);
                _dateAnalyser.AnalyseDate();
            }
            catch (ArgumentException)
            {
                MessageBox.Show($"Incorrect birthday date. You must be older than 1 year and younger than 135.");
                return;
            }

            if (Dates.All(saved => saved.Date != SelectedDate))
            {
                    Dates.Add(birthdayAnalysisModel);
            }

            if(_dateAnalyser.IsBirthdayToday())
            {
                MessageBox.Show("Happy Birthday!");

            }

            ModelToDisplay = birthdayAnalysisModel;
            UpdateResultString();
        }

        private void UpdateResultString()
        {
            if (ModelToDisplay == null)
            {
                return;
            }
            Visibility = Visibility.Visible;
            ResultText = $"Date: {ModelToDisplay.Date} \nAge: {ModelToDisplay.Age} \nDays until birthday: {_dateAnalyser.CalculateDaysUntilBirthday()} \nWest. zodiac: {ModelToDisplay.WesternZodiac} \nChin. zodiac: {ModelToDisplay.ChineseZodiac}";
        }
    }
}
