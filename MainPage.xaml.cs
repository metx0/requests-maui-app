using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;

namespace RequestsApp
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private ObservableCollection<PersonaModel> _people;

        // Property for the field above
        public ObservableCollection<PersonaModel> People
        {
            get => _people;
            set
            {
                _people = value;
                OnPropertyChanged();
            }
        }

        public async void GetData()
        {
            var response = await _httpClient
                .GetStringAsync("https://fi.jcaguilar.dev/v1/escuela/persona");
            // Populate the collection with PersonaModel objects
            var people = JsonSerializer
                .Deserialize<ObservableCollection<PersonaModel>>(response);

            if (people != null)
                People = people;
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            GetData();
        }
        private async void btnGoForm_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FormPage());
        }
    }
}
