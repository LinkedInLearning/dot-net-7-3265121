using Microsoft.Maui.Maps;

namespace EnrichMaui;

public partial class MainPage : ContentPage
{
	int count = 0;

    private readonly (string ville, Location lieu)[] Francophones = {
        ( "Kinshasa"      , new Location(-4.3317 , 15.3139)),
        ( "Paris"         , new Location(48.8569 ,  2.3508)),
        ( "Alger"         , new Location(36.7764 ,  3.0586)),
        ( "Abidjan"       , new Location(5.3364  ,- 4.0267)),
        ( "Casablanca"    , new Location(33.5992 ,- 7.62  )),
        ( "Montréal"      , new Location(45.5089 ,-73.5617)),
        ( "Dakar"         , new Location(14.7319 ,-17.4572)),
        ( "Bamako"        , new Location(12.6458 ,- 7.9922)),
        ( "Yaoundé"       , new Location(3.8578  , 11.5181)),
        ( "Douala"        , new Location(4.05    ,  9.7000)),
        ( "Ouagadougou"   , new Location(12.3686 ,- 1.5275)),
        ( "Port-au-Prince", new Location(18.5425 ,-72.3386)),
        ( "Tananarive"    , new Location(-18.9386, 47.5214)),
        ( "Lyon"          , new Location(45.76   ,  4.8400)),
        ( "Beyrouth"      , new Location(33.8869 , 35.5131)),
        ( "Tunis"         , new Location(36.8001 , 10.1871)),
        ( "Lomé"          , new Location( 6.1319 ,  1.2228)),
        ( "Rabat"         , new Location(34.0253 ,- 6.8361)),
        ( "Brazzaville"   , new Location(-4.2667 , 15.2833)),
        ( "Marseille"     , new Location(43.2964 ,  5.3700))
    };
    public MainPage()
	{
		InitializeComponent();
        UpdateMap();
	}

    private void UpdateMap()
    {
        lblTitre.Text = Francophones[count].ville;
        carte.MoveToRegion(new MapSpan(Francophones[count].lieu, 0.3, 0.3));
        count = (count + 1) % Francophones.Length;
        CounterBtn.Text = $"Aller à {Francophones[count].ville}";
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        UpdateMap();
        SemanticScreenReader.Announce(CounterBtn.Text);
    }

    private void OnLabelClicked(object sender, EventArgs e)
    {
		var colorName = ((MenuFlyoutItem)sender).CommandParameter.ToString();

		lblTitre.TextColor = typeof(Colors)			
			.GetField(colorName)
			.GetValue(null) as Color;
    }
}

