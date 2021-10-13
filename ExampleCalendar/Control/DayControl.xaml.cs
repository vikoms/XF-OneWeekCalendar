using System;
using System.Collections.Generic;
using ExampleCalendar.ViewModels;
using Xamarin.Forms;

namespace ExampleCalendar.Control
{
    public partial class DayControl : ContentView
    {
        public DayControl(DateTime date, DateTime selectedDate, int row, int col)
        {
            InitializeComponent();
            SetValue(Grid.RowProperty, row);
            SetValue(Grid.ColumnProperty, col);

            BindingContext = viewModel = new DayViewModel(date, selectedDate);

            viewModel.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName);
        }

        //* static properties
        public static readonly BindableProperty ForegroundColorProperty = BindableProperty.Create(
            propertyName: nameof(ForegroundColor),
            returnType: typeof(Color),
            declaringType: typeof(DayControl),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ForegroundColorProperty_Changed);

        private readonly DayViewModel viewModel;

        //* Public Properties
        public Color ForegroundColor
        {
            get => viewModel.ForegroundColor;
            set => viewModel.ForegroundColor = value;
        }

        public DateTime Date => viewModel.Date;

        //* Event Handlers
        private static void ForegroundColorProperty_Changed(BindableObject bindable, object oldValue, object newValue)
        {
            DayControl control = (DayControl)bindable;
            control.ForegroundColor = (Color)newValue;
        }
    }
}
