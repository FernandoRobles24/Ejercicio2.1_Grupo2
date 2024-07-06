namespace Ejercicio2._1_Grupo2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.MainPage());
        }
    }
}
