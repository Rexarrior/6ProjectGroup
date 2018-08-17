using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;

namespace Telephone
{

    public partial class MainWindow : Window
    {

        ApplicationContext db;

        public int answer { get; set; }

        public string newName { get; set; }
        public string newNumber { get; set; }
        public string newDescription { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Peoples.Load();

            answer = 0;

            Update();

        }

        public void Add_New(object sender, RoutedEventArgs e) {

            FIOLabel.IsEnabled = true;
            namebox.IsEnabled = true;
            numberbox.IsEnabled = true;
            addButton.IsEnabled = true;

        }

        public void Add_Button(object sender, RoutedEventArgs e) {

            if ((namebox.Text != "") & (numberbox.Text != ""))
            {
                db.Peoples.Add(new People {
                    Name = namebox.Text,
                    Number = numberbox.Text,
                    Description = ""                   
                });

                db.SaveChanges();
            }
            else {
                MessageBox.Show("Не указан номер телефона или имя контакта!");
            }

            Update();

            FIOLabel.IsEnabled = false;
            namebox.IsEnabled = false;
            numberbox.IsEnabled = false;
            addButton.IsEnabled = false;

            namebox.Text = "";
            numberbox.Text = "";

        }

        public void Update_Button(object sender, RoutedEventArgs e)
        {
            Update();
        }

        public void Edit_Button(object sender, RoutedEventArgs e) {

            Ask ask = new Ask();
            ask.Owner = this;

            if (ask.ShowDialog() == true)
            {

                Edit edit = new Edit();
                edit.Owner = this;

                if (edit.ShowDialog() == true)
                {
                    People p = db.Peoples.Find(answer);  // Null is possible. R.
                    p.Name = newName;
                    p.Number = newNumber;
                    p.Description = newDescription;
                    if (p == null) { return; }          // Exception will be thrown earlier. R.
                    db.Entry(p).State = EntityState.Modified;
                    db.SaveChanges();

                    Update();

                }
            }
        }

        public void Delete_Button(object sender, RoutedEventArgs e) {

            Ask ask = new Ask();
            ask.Owner = this;

            if (ask.ShowDialog() == true) {

                People p = db.Peoples.Find(answer);
                if (p == null) { return; }
                db.Peoples.Remove(p);
                db.SaveChanges();

                Update();

            }
        }

        private void Update() {

            spanel.Children.Clear();

            foreach (People p in db.Peoples)
            {
                TextBlock t = new TextBlock();
                t.FontSize = 16;
                t.Text = "ID:"+ p.Id.ToString() + " | " + p.Name + " " + p.Number + " | " + p.Description;

                spanel.Children.Add(t);
            }

        }

    }
}
