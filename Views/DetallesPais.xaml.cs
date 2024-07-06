using Ejercicio2._1_Grupo2.Models;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
namespace Ejercicio2._1_Grupo2.Views;

public partial class DetallesPais : ContentPage
{
    Countries PaisSeleccionado;
    public DetallesPais(Countries country)
	{
        PaisSeleccionado = country;
        InitializeComponent();
        loadConfiguration();

    }
    private void loadConfiguration()
    {
        // Limpiar marcadores existentes
        mapa.Pins.Clear();

        if (PaisSeleccionado != null && PaisSeleccionado.latlng != null && PaisSeleccionado.latlng.Count >= 2)
        {
            var currency = PaisSeleccionado.currencies != null && PaisSeleccionado.currencies.Count > 0
                ? PaisSeleccionado.currencies[0].name
                : "Desconocida";

            var languages = PaisSeleccionado.languages != null && PaisSeleccionado.languages.Count > 0
                ? string.Join(", ", PaisSeleccionado.languages)
                : "Desconocido";

            var pin = new Pin()
            {
                Type = PinType.SavedPin,
                Location = new Location(PaisSeleccionado.latlng[0], PaisSeleccionado.latlng[1]),
                Label = PaisSeleccionado.NameCountry.official,
                Address = $"Capital: {PaisSeleccionado.capital}"
            };

            mapa.Pins.Add(pin);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Location(PaisSeleccionado.latlng[0], PaisSeleccionado.latlng[1]), Distance.FromKilometers(41)));
        }
        else
        {
            Console.WriteLine("Datos de ubicación no válidos.");
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        loadConfiguration();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        mapa.Pins.Clear();
    }
}


