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
            int selectionStart = sender.SelectionStart - 1;

            foreach (char c in sender.Text)
            {
                switch (GetValidationType(sender))
                {
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
            CurrentTextValues[sender] = sender.Text;
        }

        public static void SetValidationType(DependencyObject dp, ValidationMethod value)
        {
            dp.SetValue(ValidationTypeProperty, value);
        }

        public static ValidationMethod GetValidationType(DependencyObject dp)
        {
            return (ValidationMethod)dp.GetValue(ValidationTypeProperty);
        }
    }
}