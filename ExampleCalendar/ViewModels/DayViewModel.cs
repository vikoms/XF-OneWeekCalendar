﻿using System;
using System.Windows.Input;
using ExampleCalendar.Models;
using Xamarin.Forms;

namespace ExampleCalendar.ViewModels
{
    public class DayViewModel : BaseViewModel
    {
        //* Private Properties
        private Color foregroundColor;

        private DateTime date;
        private DateTime selectedDate;

        private double numOpacity;
        private double outlineOpacity;

        //* Public Properties
        public Color ForegroundColor
        {
            get => foregroundColor;
            set => setProperty(ref foregroundColor, value);
        }

        /// <summary>The date represented by the viewmodel.</summary>
        public DateTime Date
        {
            get => date;
            set => setProperty(ref date, value);
        }

        ///  <summary>
        /// The opacity of the month number. Used to make the old dates faded.
        /// </summary>
        public double NumOpacity
        {
            get => numOpacity;
            set => setProperty(ref numOpacity, value);
        }
        /// <summary>
        /// The opacity of the button, which has a circular outline. When a user
        /// selects a date, it becomes circled (Opacity = 1).
        /// </summary>
        public double OutlineOpacity
        {
            get => outlineOpacity;
            set => setProperty(ref outlineOpacity, value);
        }

        public ICommand DayClickedCommand { get; }

        //* Constructors

        /// <param name="date">The date represented by the viewmodel.</param>
        /// <param name="selectedDate">The selected date.</param>
        public DayViewModel(DateTime date, DateTime selectedDate)
        {
            Date = date;
            updateOpacities(selectedDate);

            DayClickedCommand = new Command(() =>
                MessagingCenter.Send(this, MessagingEvent.DayButtonClicked.ToString(), Date));

            MessagingCenter.Subscribe<WeekControlViewModel, int>(this,
                MessagingEvent.ShiftDays.ToString(),
                (sender, args) =>
                {
                    Date = Date.AddDays(args);
                    updateOpacities(this.selectedDate);
                });

            MessagingCenter.Subscribe<WeekControlViewModel, DateTime>(this,
                MessagingEvent.SelectedDateChanged.ToString(),
                (sender, args) => updateOpacities(args));
        }

        //* private methods
        private void updateOpacities(DateTime selectedDate)
        {
            this.selectedDate = selectedDate;

            int compare = DateTime.Compare(Date.Date, DateTime.Today);
            NumOpacity = compare < 0 ? 0.6 : 1;

            OutlineOpacity = Date.Date == selectedDate.Date ? 1 : 0;
        }
    }
}
