using ADO.NET_HW6.Model;
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

namespace ADO.NET_HW6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CountriesDataContext dataContext;
        
        public MainWindow()
        {
            InitializeComponent();
            dataContext = new CountriesDataContext();
            LoadCountries();
        }

        public void LoadCountries()
        {
            try
            {
                var allCountries = dataContext.Countries
                    .Select(c => c).ToList();
                dataGridView.ItemsSource = allCountries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadCountries();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var countryNames = dataContext.Countries
                    .Select(c => new { Names = c.Name }).ToList();
                dataGridView.ItemsSource = countryNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                var capitalNames = dataContext.Countries
                    .Select(c => new { Capitals = c.Capital }).ToList();
                dataGridView.ItemsSource = capitalNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                var europeanCountries = dataContext.Countries
                    .Where(c => c.Continent == "Europe")
                    .Select(c => new { Names = c.Name }).ToList();
                dataGridView.ItemsSource = europeanCountries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.TryParse(areaTxtBox.Text, out double area))
                {
                    var countryAreaLargerThan = dataContext.Countries
                        .Where(c => c.Area > area)
                        .Select(c => new { Names = c.Name }).ToList();
                    dataGridView.ItemsSource = countryAreaLargerThan;
                }
                else
                {
                    MessageBox.Show("Уведіть число, будь ласка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                var countiesWithAAndU = dataContext.Countries
                    .Where(c => c.Name.ToLower().Contains("a")
                    && c.Name.ToLower().Contains("u"))
                    .Select(c => new { Names = c.Name }).ToList();
                dataGridView.ItemsSource = countiesWithAAndU;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            try
            {
                var countiesWithFirstA = dataContext.Countries
                    .Where(c => c.Name.StartsWith("A"))
                    .Select(c => new { Names = c.Name }).ToList();
                dataGridView.ItemsSource = countiesWithFirstA;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            try
            {
                if (double.TryParse(minAreaTxtBox.Text, out double minArea) && double.TryParse(maxAreaTxtBox.Text, out double maxArea))
                {
                    if (minArea > maxArea)
                    {
                        MessageBox.Show("Найменше значення діапазону більше за найбільше. Спробуйте задати діапазон ще раз");
                        return;
                    }
                    var countryAreaByRange = dataContext.Countries
                        .Where(c => c.Area >= minArea 
                        && c.Area <= maxArea)
                        .Select(c => new { Names = c.Name }).ToList();
                    dataGridView.ItemsSource = countryAreaByRange;
                }
                else
                {
                    MessageBox.Show("Уведіть число, будь ласка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                if (long.TryParse(populationTxtBox.Text, out long population))
                {
                    var countryPopulationLargerThan = dataContext.Countries
                        .Where(c => c.Population > population)
                        .Select(c => new { Names = c.Name }).ToList();
                    dataGridView.ItemsSource = countryPopulationLargerThan;
                }
                else
                {
                    MessageBox.Show("Уведіть число, будь ласка");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            try
            {
                var top5CountriesByArea = dataContext.Countries
                    .OrderByDescending(c => c.Area)
                    .Take(5).ToList();
                dataGridView.ItemsSource = top5CountriesByArea;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            try
            {
                var top5CountriesByPopulation = dataContext.Countries
                    .OrderByDescending(c => c.Population)
                    .Take(5).ToList();
                dataGridView.ItemsSource = top5CountriesByPopulation;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            try
            {
                var largestAreaCountry = dataContext.Countries
                    .OrderByDescending(c => c.Area)
                    .Select(c => c.Name)
                    .First();
                MessageBox.Show($"Країна з найбільшою площею: {largestAreaCountry}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            try
            {
                var largestPopulationCountry = dataContext.Countries
                    .OrderByDescending(c => c.Population)
                    .Select(c => c.Name)
                    .First();
                MessageBox.Show($"Країна з найбільшим населенням: {largestPopulationCountry}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            try
            {
                var smallestAreaCountryOfAfrica = dataContext.Countries
                    .Where(c => c.Continent == "Africa")
                    .OrderBy(c => c.Area)
                    .Select(c => c.Name)
                    .First();
                MessageBox.Show($"Країна з найменшою площею в Африці: {smallestAreaCountryOfAfrica}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            try
            {
                var averageAreaOfAsianCountries = (from c in dataContext.Countries
                                                   where c.Continent == "Asia"
                                                   select c.Area)
                                                   .Average();
                //dataGridView.ItemsSource = new List<double> { averageAreaOfAsianCountries };
                MessageBox.Show($"Середня площа країн Азії: {averageAreaOfAsianCountries}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }

        private void Button_Click_15(object sender, RoutedEventArgs e) //Оновлення даних
        {
            try
            {
                DataHandling window = new DataHandling();
                window.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }
    }
}