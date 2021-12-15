using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JuegoPeliculas
{
    class ConverterImageGenero : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string genero = (string)value;
            string imagenGenero = "";

            switch (genero)
            {
                case "Drama":
                    imagenGenero = "Assets/drama.png";
                    break;
                case "Terror":
                    imagenGenero = "Assets/terror.png";
                    break;
                case "Comedia":
                    imagenGenero = "Assets/comedia.png";
                    break;
                case "Acción":
                    imagenGenero = "Assets/accion.png";
                    break;
                case "Ciencia-Ficción":
                    imagenGenero = "Assets/ciencia_ficcion.png";
                    break;
            }
            return imagenGenero;    
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
