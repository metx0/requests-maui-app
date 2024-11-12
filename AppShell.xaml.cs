namespace RequestsApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Register navigation routes
            Routing.RegisterRoute(nameof(FormPage), typeof(FormPage));
        }
    }
}
