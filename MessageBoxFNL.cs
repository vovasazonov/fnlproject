using System.Windows.Forms;

namespace FNL
{
    static internal class MessageBoxFNL
    {
        static public void MessageErrorDb()
        {
            MessageBox.Show("",
                    "Ошибка базы данных.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}
