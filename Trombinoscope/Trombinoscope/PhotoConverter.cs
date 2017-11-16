using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Trombinoscope
{
    class PhotoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                var ProfileImg = new BitmapImage(new Uri("/Images/abathur_pleure.gif", UriKind.Relative));
                return ProfileImg;
            }
            else
            {
                byte[] photo = ((System.Data.Linq.Binary)value).ToArray();
                BitmapImage image = new BitmapImage();
                MemoryStream stream = new MemoryStream(photo);
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();
                return image;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
