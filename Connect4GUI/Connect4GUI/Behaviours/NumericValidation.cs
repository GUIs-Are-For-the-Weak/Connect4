using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Connect4GUI.Behaviours;

namespace Connect4GUI.Behaviours
{
    public static class NumericValidation
    {
        public static readonly DependencyProperty ValidationType = DependencyProperty.RegisterAttached("ValidationType", typeof(ValidationMethod), typeof(TextBox), new PropertyMetadata(ValidationMethod.None, OnValidationTypeChanged));

        public static void OnValidationTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //TODO: Attach event handler for Property Changed!!!!
        }
    }
}
