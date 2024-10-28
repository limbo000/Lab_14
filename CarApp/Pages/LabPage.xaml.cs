using System;
using System.Collections.Generic;
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

namespace CarApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для LabPage.xaml
    /// </summary>
    public partial class LabPage : Page
    {
        private CarRepository carRepository;

        public LabPage()
        {
            InitializeComponent();
            carRepository = new CarRepository("cars.txt"); // Укажите путь к вашему файлу
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsListBox.ItemsSource = null; // Очищаем предыдущие результаты

            // Получаем данные из полей ввода
            var brand = BrandTextBox.Text.Trim();
            var color = ColorTextBox.Text.Trim();

            List<Car> results = new List<Car>();

            // Поиск по марке и цвету
            if (!string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(color))
            {
                results.AddRange(carRepository.GetCarsByBrandAndColor(brand, color));
            }

            // Устанавливаем источник данных для списка
            ResultsListBox.ItemsSource = results.Count > 0 ? results : null;
        }
    }
}
