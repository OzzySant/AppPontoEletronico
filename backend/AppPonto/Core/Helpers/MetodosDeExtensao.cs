using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Core.Helpers
{
    public static class MetodosDeExtensao
    {
        public static DateTime ConverterStringParaData(this string data, string formato = "dd/MM/yyyy")
        {
            return DateTime.ParseExact(data, formato, CultureInfo.InvariantCulture);
        }
    }
}
