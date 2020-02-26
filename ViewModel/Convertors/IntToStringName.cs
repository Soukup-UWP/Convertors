using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertors.ViewModel.Convertors
{
    class IntToStringName
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int)
            {
                int cislo = ((int)value) % 3;
                switch (cislo)
                {
                    case 0: { return "Kámen"; }
                    case 1: { return "Nůžky"; }
                    case 2: { return "Papír"; }
                }
            }
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is string && targetType == typeof(string))
            {
                switch (value)
                {
                    case "Kámen": { return 1; }
                    case "Nůžky": { return 2; }
                    case "Papír": { return 3; }
                    default: return "Alice";
                }
            }
            return value.ToString();
        }

    }
}
