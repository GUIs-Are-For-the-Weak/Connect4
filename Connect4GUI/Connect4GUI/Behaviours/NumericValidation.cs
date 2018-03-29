using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Connect4GUI.Behaviours
{
    public static class NumericValidation
    {
        public static readonly DependencyProperty ValidationTypeProperty = DependencyProperty.RegisterAttached("ValidationType",
            typeof(ValidationMethod), typeof(TextBox), new PropertyMetadata(ValidationMethod.None, OnValidationTypeChanged));

        public static void SetValidationType(DependencyObject dObj, ValidationMethod value) => dObj.SetValue(ValidationTypeProperty, value);
        public static ValidationMethod GetValidationType(DependencyObject dObj) => (ValidationMethod)dObj.GetValue(ValidationTypeProperty);

        public static readonly DependencyProperty MinIntegerValueProperty = DependencyProperty.RegisterAttached("MinIntegerValue",
            typeof(int), typeof(TextBox), new PropertyMetadata(int.MinValue));

        public static void SetMinIntegerValue(DependencyObject dObj, int value) => dObj.SetValue(MinIntegerValueProperty, value);
        public static int GetMinIntegerValue(DependencyObject dObj) => (int) dObj.GetValue(MinIntegerValueProperty);

        public static readonly DependencyProperty MaxIntegerValueProperty = DependencyProperty.RegisterAttached("MaxIntegerValue",
            typeof(int), typeof(TextBox), new PropertyMetadata(int.MaxValue));

        public static void SetMaxIntegerValue(DependencyObject dObj, int value) => dObj.SetValue(MaxIntegerValueProperty, value);
        public static int GetMaxIntegerValue(DependencyObject dObj) => (int)dObj.GetValue(MaxIntegerValueProperty);

        private static readonly Dictionary<TextBox, string> CurrentTextValues = new Dictionary<TextBox, string>();

        public static void OnValidationTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is TextBox b) || CurrentTextValues.ContainsKey(b))
                return;

            b.TextChanging += OnTextChanging;
            CurrentTextValues[b] = b.Text;
        }

        private static void OnTextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (sender.Text == string.Empty)
            {
                CurrentTextValues[sender] = string.Empty;
                return;
            }
            int selectionStart = sender.SelectionStart - 1;

            foreach (char c in sender.Text)
            {
                switch (GetValidationType(sender))
                {
                    case ValidationMethod.IntegerRange:
                    case ValidationMethod.None:
                        break;
                    case ValidationMethod.PositiveInteger:
                        if (c > '9' || c < '0')
                        {
                            sender.Text = CurrentTextValues[sender];
                            sender.SelectionStart = selectionStart;
                            return;
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(ValidationMethod), "Invalid ValidationMethod");
                }
            }

            //TODO: Move this to LostFocus (or something...?)
            if (GetValidationType(sender) == ValidationMethod.IntegerRange)
            {
                if (!int.TryParse(sender.Text, out int result) || result < GetMinIntegerValue(sender) ||
                    result > GetMaxIntegerValue(sender))
                {
                    sender.Text = CurrentTextValues[sender];
                    sender.SelectionStart = selectionStart;
                    return;
                }
            }


            CurrentTextValues[sender] = sender.Text;
        }
    }
}