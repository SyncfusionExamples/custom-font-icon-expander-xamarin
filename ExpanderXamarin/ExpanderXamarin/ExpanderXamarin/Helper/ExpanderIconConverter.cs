using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ExpanderXamarin
{
 public class ExpanderIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                if ((string)parameter == "Android")
                    return "\ue704";
                else if((string)parameter == "iOS")
                    return "\ue700";
                else
                    return "\ue702";
            }
            else
            {
                if ((string)parameter == "Android")
                    return "\ue705";
                else if ((string)parameter == "iOS")
                    return "\ue701";
                else
                    return "\ue703";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
