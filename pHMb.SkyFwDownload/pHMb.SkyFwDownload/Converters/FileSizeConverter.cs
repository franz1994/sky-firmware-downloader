﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;

namespace pHMb.TS_Demux
{
    [ValueConversion(typeof(long), typeof(string))]
    class FileSizeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] units = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            double size;

            if (value.GetType() == typeof(ulong))
            {
                size = (ulong)value;
            }
            else if (value.GetType() == typeof(uint))
            {
                size = (uint)value;
            }
            else
            {
                size = (long)value;
            }

            int unit = 0;

            while (size >= 1024)
            {
                size /= 1024;
                ++unit;
            }

            return String.Format("{0:0.#} {1}", size, units[unit]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
