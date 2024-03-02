using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using Lab01Shvachka.Models;
using Lab01Shvachka.Tools;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab01Shvachka.Services
{
    class DateAnalyser
    {
        private BirthdayAnalysisModel _birthdayModel;

        public DateAnalyser(BirthdayAnalysisModel model)
        {
            _birthdayModel = model;
        }

        public void AnalyseDate()
        {
            _birthdayModel.Age = CalculateAge();
            if (IsValid())
            {
                CalculateZodiacSigns();
            }
            else
                throw new ArgumentException("Incorrect date");
        }

        private int CalculateAge()
        {
            int age = DateTime.Today.Year - _birthdayModel.Date.Year;
            if (_birthdayModel.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        private bool IsValid()
        {
            return _birthdayModel.Age >= 0 && _birthdayModel.Age <= 135;
        }

        private void CalculateZodiacSigns()
        {
            _birthdayModel.WesternZodiac = ZodiacCalculator.CalculateWesternZodiac(_birthdayModel.Date);
            _birthdayModel.ChineseZodiac = ZodiacCalculator.CalculateChineseZodiac(_birthdayModel.Date);
        }

        public bool IsBirthdayToday()
        {
            return DateTime.Today.Month == _birthdayModel.Date.Month && DateTime.Today.Day == _birthdayModel.Date.Day;
        }

        public int CalculateDaysUntilBirthday()
        {
            var nextBirthday = new DateTime(DateTime.Today.Year, _birthdayModel.Date.Month, _birthdayModel.Date.Day);

            int days = (nextBirthday - DateTime.Today).Days;
            if (days < 0)
            {
                days += 365;
            }
            return days;
        }

    }
}
