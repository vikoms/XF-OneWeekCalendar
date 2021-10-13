using System;
using System.Collections.Generic;
using ExampleCalendar.ViewModels;
using Xamarin.Forms;

namespace ExampleCalendar.Control
{
    public partial class DateLabelControl : ContentView
    {
        public DateLabelControl(DateTime date, int row, int col)
        {
            InitializeComponent();
            BindingContext = viewModel = new DateLabelViewModel(date);

            SetValue(Grid.RowProperty, row);
            SetValue(Grid.ColumnProperty, col);
        }

        //* static properties
        public static readonly BindableProperty ForegroundProperty = BindableProperty.Create(
            propertyName: nameof(ForegroundColor),
            returnType: typeof(Color),
            declaringType: typeof(DayControl),
            defaultValue: Color.Black,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanged: ForegroundColorProperty_Changed);

        
        //* private properties
        private readonly DateLabelViewModel viewModel;

        //* Public Properties
        public Color ForegroundColor
        {
            get => viewModel.ForegroundColor;
            set => viewModel.ForegroundColor = value;
        }

        //* event handlers
        private static void ForegroundColorProperty_Changed(BindableObject bindable, object oldValue, object newValue)
        {
            DateLabelControl control = (DateLabelControl)bindable;
            control.ForegroundColor = (Color)newValue;
        }
    }
}
