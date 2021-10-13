using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExampleCalendar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void ChangeSelectedDate_Clicked(System.Object sender, System.EventArgs e)
        {
        }

        void CalendarWeekControl_SelectedDateChanged(System.Object sender, ExampleCalendar.Models.SelectedDateChangedEventArgs e)
        {
        }
    }
}
