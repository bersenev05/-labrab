using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace labrab5
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            datapicker.SelectedDate = DateTime.Now;
            textbox1.Text = "Анастасия Раскина";
            textbox2.Text = "Основы Программирования";
            combobox.Items.Add(Difficulty.low);
            combobox.Items.Add(Difficulty.medium);
            combobox.Items.Add(Difficulty.hard);

            buttonAdd.Click += AddElement;
            buttonDelete.Click += DeleteItem;

            Visual.init(this.listview);
            
            this.listview.Items.Add(new MyItem { Predmet = "ОП", Prepod = "David" , Difficulty = Difficulty.hard.ToString(), Exam = DateTime.Now, Prepare = DateTime.Now});
        }

        public void AddElement(object sender, RoutedEventArgs e)
        {
            listview.Items.Add(new MyItem
            {
                Predmet = textbox2.Text,
                Prepod = textbox1.Text,
                Difficulty = combobox.Text,
                Exam = datapicker.SelectedDate ?? DateTime.Now,
                Prepare = DateTime.Parse("16.03.2005")
            }
          );
        }

        public void DeleteItem(object sender, RoutedEventArgs e)
        {
            listview.Items.RemoveAt(listview.SelectedIndex);
        }
    }

    public class Visual
    {
        public static void init(ListView listview)
        {
            var gridView = new GridView();
            listview.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Предмет",
                DisplayMemberBinding = new Binding("Predmet")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Преподаватель",
                DisplayMemberBinding = new Binding("Prepod")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Сложность",
                DisplayMemberBinding = new Binding("Difficulty")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Экзамен",
                DisplayMemberBinding = new Binding("Exam")
            });

            gridView.Columns.Add(new GridViewColumn
            {
                Header = "Подготовка",
                DisplayMemberBinding = new Binding("Prepare")
            });
        }
    }

    public class MyItem
    {
        public string Predmet { get; set; }

        public string Prepod { get; set; }

        public string Difficulty { get; set; }

        public DateTime Exam { get; set; }

        public DateTime Prepare { get; set; }
    }

    public enum Difficulty
    {
        hard, medium, low
    }

}
