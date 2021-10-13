using System;
using Xamarin.Forms;

namespace ExampleCalendar.ViewModels
{
    public class DateLabelViewModel : BaseViewModel
    {
        //* private Properties
        private Color foregroundColor;
        private DateTime date;

        //* public properties
        public Color ForegroundColor
        {
            get => foregroundColor;
            set => setProperty(ref foregroundColor, value);
        }

        public DateTime Date
        {
            get => date;
            set
            {
                setProperty(ref date, value);
                OnPropertyChanged(nameof(ShortDayName));
            }
        }

        public string ShortDayName => Date.ToString("ddd").ToUpper();



        public DateLabelViewModel(DateTime date) => Date = date;

    }
}
