//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MyElectricCar.Commons
{

    public enum VisibilityEnum
    {
        Not,
        Normal
    }

    /// <summary>
    /// Convert an object status to Visibility.Visible (true) or Visibility.Collapsed (false).
    /// Assists in avoiding having the view model keep references to UI types.
    /// </summary>
    public class VisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Convert a object into a member of the Visibility enum, true for Visible, false for Collapsed.
        /// </summary>
        /// <param name="value">The bool passed in</param>
        /// <param name="targetType">Ignored.</param>
        /// <param name="parameter">Ignored</param>
        /// <param name="language">Ignored</param>
        /// <returns>Visibility.Visible if value was a true bool, otherwise Visibility.Collapsed</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var visiblityAction = VisibilityEnum.Normal;
            if (parameter != null)
            {
                Enum.TryParse(parameter.ToString(), out visiblityAction);
            }

            var visibility = Visibility.Collapsed;
            if (value is bool)
            {
                if ((bool)value == true)
                {
                    visibility = Visibility.Visible;
                }
            }
            else if (value != null)
            {
                visibility = Visibility.Visible;
            }

            return visiblityAction == VisibilityEnum.Normal ?
                        visibility : (visibility == Visibility.Visible ?
                                            Visibility.Collapsed : Visibility.Visible);
        }

        /// <summary>
        /// Not used, converter is not intended for two-way binding. 
        /// </summary>
        /// <param name="value">Ignored</param>
        /// <param name="targetType">Ignored</param>
        /// <param name="parameter">Ignored</param>
        /// <param name="language">Ignored</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
