using System;
using System.Collections.Generic;
using System.Windows.Input;
using ExampleCalendar.Control;
using ExampleCalendar.Models;
using Xamarin.Forms;

namespace ExampleCalendar.ViewModels
{
    public class WeekControlViewModel : BaseViewModel
    {

        //* Private Properties
        private bool showDayName = false;

        private Color foregroundColor;

        private DateTime shownDate;
        private DateTime selectedDate;

        //* public properties

        public bool ShowDayName
        {
            get => showDayName;
            set => setProperty(ref showDayName, value);
        }

        public Color ForegroundColor
        {
            get => foregroundColor;
            set => setProperty(ref foregroundColor, value);
        }

        public DateTime ShownDate
        {
            get => shownDate;
            set
            {
                setProperty(ref shownDate, value);
                OnPropertyChanged(nameof(MonthFormatted));
            }
        }

        /// <summary>
        /// DateTime object of the date selected on the calendar.
        /// </summary>
        ///
        public DateTime SelectedDate
        {
            get => selectedDate;
            set
            {
                setProperty(ref selectedDate, value);
                ShownDate = value;
                MessagingCenter.Send(this, MessagingEvent.SelectedDateChanged.ToString(), value);
            }
        }

        public ICommand ShiftDatesBackwardsCommand { get; }
        public ICommand ShiftDatesForwardsCommand { get; }

        public List<DayControl> DayControls;

        public string MonthFormatted => ShownDate.ToString("MMMM");


        public WeekControlViewModel()
        {
            SelectedDate = DateTime.Today;
            DayControls = new List<DayControl>();

            MessagingCenter.Subscribe<DayViewModel, DateTime>(this,
                MessagingEvent.DayButtonClicked.ToString(),
                (sender, args) => SelectedDate = args.Date);

            ShiftDatesBackwardsCommand = new Command(() => ExecuteShiftDatesCommand(false));
            ShiftDatesForwardsCommand = new Command(() => ExecuteShiftDatesCommand(true));
        }


        // * Public Events
        public void ExecuteShiftDatesCommand(bool shiftForward)
        {
            int offset = shiftForward ? 7 : -7;

            MessagingCenter.Send(this, MessagingEvent.ShiftDays.ToString(),
                offset);

            ShownDate = DayControls[0].Date;
        }

        public void OverrideSelectedDate(DateTime newSelectedDate)
        {
            SelectedDate = newSelectedDate;

            while (SelectedDate < DayControls[0].Date || SelectedDate > DayControls[6].Date)
                ExecuteShiftDatesCommand(SelectedDate >= DayControls[0].Date);
        }
    }
}
