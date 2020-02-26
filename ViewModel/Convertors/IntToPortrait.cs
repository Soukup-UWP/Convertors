using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Convertors.ViewModel.Convertors
{
    class IntToPortrait : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int)
            {
                int cislo = ((int)value) % 3;
                switch (cislo)
                {
                    case 0: { return Portrait1; }
                    case 1: { return Portrait2; }
                    case 2: { return Portrait3; }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public BitmapImage Portrait1 { get; set; }
        public BitmapImage Portrait2 { get; set; }
        public BitmapImage Portrait3 { get; set; }
    }
}
