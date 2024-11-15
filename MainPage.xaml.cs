namespace CatFacts;
using System;
using System.Text.Json;
using System.Threading.Tasks;

public partial class MainPage : ContentPage
{
	static readonly string BaseAddress = "https://catfact.ninja/";
    static readonly string Url = $"{BaseAddress}/";
    // private static string authorizationKey;

    static HttpClient client;

	public MainPage()
	{
		InitializeComponent();
	}

    private static async Task<HttpClient> GetClient()
    {
        if (client != null)
            return client;

        client = new HttpClient();
        client.DefaultRequestHeaders.Add("Accept", "application/json");

        return client;
    }



	private async Task<CatFact>? GetACatFact(){
		
		if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet){
			CatFactBox.Text = $"Obtaining cat fact...";
			HttpClient client = await GetClient();
			// string result = await client.GetStringAsync($"{Url}/fact");
			string result = await client.GetStringAsync($"https://catfact.ninja/fact");
			CatFactBox.Text = $"{result}";

            // Deserialize the JSON response to a CatFact object
			return JsonSerializer.Deserialize<CatFact>(result);
		}else{
			return null;
		}
	}

	public async void OnCounterClicked(object sender, EventArgs e)
	{
		CatFactBox.Text = $"{"AAAAA"}";

		Console.WriteLine("Hello World!");
		var catFact = await GetACatFact();

		if(catFact == null){
			CatFactBox.Text = "Sorry but I don't have an internet connection right now";
		}else{
			CatFactBox.Text = $"{catFact.fact}";
		}


		// count++;

		// if (count == 1)
		// 	CatFactBox.Text = $"Clicked {count} time";
		// else
		// 	CatFactBox.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CatFactBox.Text);
	}
}

