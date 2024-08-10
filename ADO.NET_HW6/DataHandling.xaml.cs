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
using System.Windows.Shapes;

namespace ADO.NET_HW6
{
    /// <summary>
    /// Interaction logic for DataHandling.xaml
    /// </summary>
    public partial class DataHandling : Window
    {
        private readonly CountriesDataContext dataContext;
        
        public DataHandling()
        {
            InitializeComponent();
            dataContext = new CountriesDataContext();
        }

        private void Clear()
        {
            idTxtBox.Text = string.Empty;
            nameTxtBox.Text = string.Empty;
            capitalTxtBox.Text = string.Empty;
            populationTxtBox.Text = string.Empty;
            areaTxtBox.Text = string.Empty;
            continentTxtBox.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = nameTxtBox.Text;
                string capital = capitalTxtBox.Text;
                long population = long.Parse(populationTxtBox.Text);
                double area = double.Parse(areaTxtBox.Text);
                string continent = continentTxtBox.Text;

                Country newCountry = new Country
                {
                    Name = name,
                    Capital = capital,
                    Population = population,
                    Area = area,
                    Continent = continent
                };

                dataContext.Countries.InsertOnSubmit(newCountry);
                dataContext.SubmitChanges();
                Clear();
                MessageBox.Show("Дані вставлено успішно");
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Невідповідний тип даних: {ex.Message}");
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
                int id = int.Parse(idTxtBox.Text);
                string name = nameTxtBox.Text;
                string capital = capitalTxtBox.Text;
                long population = long.Parse(populationTxtBox.Text);
                double area = double.Parse(areaTxtBox.Text);
                string continent = continentTxtBox.Text;

                Country countryToUpdate = dataContext.Countries.SingleOrDefault(c => c.Id == id);
                if (countryToUpdate != null)
                {
                    countryToUpdate.Name = name;
                    countryToUpdate.Capital = capital;
                    countryToUpdate.Population = population;
                    countryToUpdate.Area = area;
                    countryToUpdate.Continent = continent;

                    dataContext.SubmitChanges();
                    Clear();
                    MessageBox.Show("Дані оновлено успішно");
                }
                else
                {
                    MessageBox.Show("Країну з таким Id не знайдено");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Невідповідний тип даних: {ex.Message}");
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
                int id = int.Parse(idTxtBox.Text);

                Country countryToDelete = dataContext.Countries.SingleOrDefault(c => c.Id == id);
                if (countryToDelete != null)
                {
                    dataContext.Countries.DeleteOnSubmit(countryToDelete);
                    dataContext.SubmitChanges();
                    Clear();
                    MessageBox.Show("Дані видалено успішно");
                }
                else
                {
                    MessageBox.Show("Країну з таким Id не знайдено");
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show($"Невідповідний тип даних: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }
    }
}