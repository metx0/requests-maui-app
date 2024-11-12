namespace RequestsApp;

public partial class FormPage : ContentPage
{
	public FormPage()
	{
		InitializeComponent();
	}

    private async void btnGoHome_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}