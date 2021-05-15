using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_app_BrightEye.DataModel;

namespace Test_app_BrightEye
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NumberContext context;

        public MainWindow()
        {
            InitializeComponent();

            context = new NumberContext();
        }

        private void FillButton_Click(object sender, RoutedEventArgs e)
        {
            using (context = new NumberContext())
            {
                context.Numbers.RemoveRange(context.Numbers);

                Random rand = new Random();

                int count = rand.Next(1, 10);

                for(int i=0; i < count; i++)
                {
                    Number number = new Number();
                    number.Value = rand.Next(1, 11);
                    context.Numbers.Add(number);
                }

                context.SaveChanges();

                context.Numbers.Load();
                randNumbersGrid.ItemsSource = context.Numbers.Local.ToBindingList();
                SortButton.IsEnabled = true;
            }
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            context.Dispose();
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            using (context = new NumberContext())
            {
                context.SortNumbers.RemoveRange(context.SortNumbers);

                var sortNumbers = context.Numbers.OrderBy(el => el.Value).Select(el => el.Value).ToList();
                foreach(var el in sortNumbers)
                {
                    SortNumber element = new SortNumber();
                    element.Value = el;
                    context.SortNumbers.Add(element);
                }

                context.SaveChanges();

                context.SortNumbers.Load();
                sortNumbersGrid.ItemsSource = context.SortNumbers.Local.ToBindingList();
            }
        }
    }
}
