﻿using System;
using Lab01Shvachka.Tools;

namespace Lab01Shvachka.Models
{
    public class BirthdayAnalysisModel
    {

        #region Fields
        private DateTime _date;
        private int _age;
        private WesternZodiacSign _wZodiac;
        private ChineseZodiacSign _cZodiac;
        #endregion

        public BirthdayAnalysisModel(DateTime date)
        {
            _date = date;
        }

        #region Properties
        public DateTime Date
        {
            get
            {
                return _date;
            }
        }

        public String DateString
        {
            get
            {
                return _date.ToString("dd.MM.yyyy");
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }

        public WesternZodiacSign WesternZodiac
        {
            get
            {
                return _wZodiac;
            }
            set
            {
                _wZodiac = value;
            }
        }

        public ChineseZodiacSign ChineseZodiac
        {
            get
            {
                return _cZodiac;
            }
            set
            {
                _cZodiac = value;
            }
        } 
        #endregion

    }

}