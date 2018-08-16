using System.Windows;

namespace Telephone
{

    public partial class Edit : Window
    {
        public Edit()
        {
            InitializeComponent();
        }

        public void Accept_Click(object sender, RoutedEventArgs e)
        {
            if (newFIO.Text != "")
            {
                MainWindow main = Owner as MainWindow;
                main.newName = newFIO.Text;
                main.newNumber = newNumber.Text;
                main.newDescription = newDescription.Text;
                DialogResult = true;
            }
            else { MessageBox.Show("Имя контакта пусто!"); }
        }

    }
}
