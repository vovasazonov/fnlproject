/*  Файл расширения класса.
 *  ©.
 *  Дата создания: 2019, дата последнего изменения: 2020.
 *  Контактная информация: vova.sazonovvv@gmail.com.
 */

using System.Drawing;
using System.Windows.Forms;

namespace FNL.Extensions
{
    /// <summary>
    /// Extension default class color.
    /// </summary>
    public static class ColorExtension
    {
        /// <summary>
        /// Chose color via dialog form.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color ChoseColorDialog(this Color color)
        {
            ColorDialog MyDialog = new ColorDialog
            {
                // Keeps the user from selecting a custom color.
                AllowFullOpen = true,
                // Allows the user to get help. (The default is false.)
                ShowHelp = true,
            };

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                return MyDialog.Color;
            }

            return Color.White;
        }
    }
}
