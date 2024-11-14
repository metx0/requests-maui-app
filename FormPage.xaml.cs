using System.Text;
using System.Text.Json;
using System.Diagnostics;
using CommunityToolkit.Maui.Alerts;

namespace RequestsApp;

public partial class FormPage : ContentPage
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string personaEndpoint = "https://fi.jcaguilar.dev/v1/escuela/persona";
    public FormPage()
	{
		InitializeComponent();
	}

    private async void btnGoHome_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

    private int mapRol(string rol)
    {
        var roles = new Dictionary<string, int>
        {
            {"Alumno", 1},
            {"Profesor", 2},
            {"Administrativo", 3},
            {"Otro", 4}
        };

        return roles[rol];
    }

    private string mapSex(string sexo)
    { 
        var sexos = new Dictionary<string, string>
        {
            {"Hombre", "h"},
            {"Mujer", "m"},
            {"Otro", "o"},
        };

        return sexos[sexo];
    }

    private async void showToast(string message)
    {
        var toast = Toast.Make(
                message,
                CommunityToolkit.Maui.Core.ToastDuration.Short, 5
            );

        await toast.Show();
    }

    private async void btnSubmit_Clicked(object sender, EventArgs e)
    {
        string nombre = txtNombre.Text;
        string apellido = txtApellido.Text;
        string sexSelection = pickSexo.SelectedItem.ToString();
        DateTime selectedDate = pickFhNac.Date;
        string rol = pickRol.SelectedItem.ToString();

        if (string.IsNullOrEmpty(nombre) ||
            string.IsNullOrEmpty(apellido) ||
            sexSelection == null ||
            pickRol.SelectedItem == null)
        {
            // Show a message error
            showToast("Por favor, completa todos los campos");
            return;
        }

        string sexo = mapSex(sexSelection);
        string fh_nac = selectedDate.ToString("yyyy-MM-dd");
        Debug.WriteLine("fh_nac: " + fh_nac);

        int id_rol = mapRol(rol);
        Debug.WriteLine("Id_rol: " + id_rol);

        // Create the PersonaModel object
        PersonaModel persona = new PersonaModel(nombre, apellido, sexo, fh_nac, id_rol);

        bool result = await sendData(persona);

        if (result)
        {
            showToast("Persona añadida exitosamente");
        }
        else 
        {
            showToast("Hubo un error al añadir a la persona");
        }

        Debug.WriteLine(result);
    }

    // Asynchronic function to send the data using a POST request 
    // Returns a bool wrapped in a Task (or something like that)
    private async Task<bool> sendData(PersonaModel persona)
    {
        // Test with a PersonaModel object (we have to delete the parameter)
        // PersonaModel persona = new PersonaModel("Miguel", "Alejandro", "h", "2024-11-13", 1);

        string jsonData = JsonSerializer.Serialize(persona);
        Debug.WriteLine(jsonData);
        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync(personaEndpoint, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
        }
        catch (System.Exception ex)
        {
            Debug.WriteLine(ex);
        }

        return false;
    }
}