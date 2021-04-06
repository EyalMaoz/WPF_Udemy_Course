using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string query;
        private CurrentConditions currentConditions;
        private City selectedCity;

        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
            }
        }

        public CurrentConditions CurrentConditions
        {
            get { return currentConditions; }
            set
            {
                currentConditions = value;
                OnPropertyChanged("CurrentConditions");
            }
        }

        public City SelectedCity
        {
            get { return selectedCity; }
            set
            {
                selectedCity = value;
                OnPropertyChanged("SelectedCity");
                GetCurrentCondition();
            }
        }

        public SearchCommand SearchCommand { get; set; }

        private ObservableCollection<City> m_obsCities;

        public ObservableCollection<City> Cities
        {
            get { return m_obsCities; }
            set { m_obsCities = value; }
        }


        public WeatherVM()
        {
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                CurrentConditions = new CurrentConditions()
                {
                    WeatherText = "Cold",
                    Temperature = new Temperature()
                    {
                        Metric = new Units()
                        {
                            Value = "54"
                        }
                    }
                };
                SelectedCity = new City()
                {
                    LocalizedName = "Hello World"
                };
            }

        }

        public async void MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);
            m_obsCities.Clear();
            foreach (var city in cities)
            {
                m_obsCities.Add(city);
            }
        }
        private async void GetCurrentCondition()
        {
            Query = string.Empty;
            m_obsCities.Clear();
            CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
