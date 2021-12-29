using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Tumblro
{
    public class ByteToImageConverter : IValueConverter
    {
        public ImageSource ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        {
            try
            {
                if (imageByteArray.Length > 0 && imageByteArray != null)
                {

                    ImageSource img = ImageSource.FromStream(() => new MemoryStream(imageByteArray));
                    return img;
                }
                else
                {
                    ImageSource img = ImageSource.FromFile("Empty.png");
                    return img;
                }


            }
            catch (Exception ex)
            {
                ImageSource img = ImageSource.FromFile("Empty.png");
                return img;
            }

        }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                ImageSource img = ImageSource.FromFile("Empty.png");
                if (value != null)
                {
                    img = this.ConvertByteArrayToBitMapImage(value as byte[]);
                }
                return img;
            }
            catch (Exception ex)
            {
                ImageSource img = ImageSource.FromFile("Empty.png");
                return img;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
