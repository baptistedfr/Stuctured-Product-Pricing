using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class YahooFinance
{
    public Chart chart { get; set; }

    // Méthode pour convertir une DateTime en timestamp Unix
    private static long ConvertToUnixTimestamp(DateTime date)
    {
        return ((DateTimeOffset)date).ToUnixTimeSeconds();
    }

    // Méthode asynchrone pour récupérer les données en fonction de la période
    public async static Task<string> GetAsync(string code)
    {
        var url = $"https://query2.finance.yahoo.com/v8/finance/chart/{code}?period1=1609459200&period2=1924905600&interval=1d&events=history&includeAdjustedClose=true";
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, url);


        request.Headers.Add("accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7");
        request.Headers.Add("accept-language", "fr-FR,fr;q=0.9,en-US;q=0.8,en;q=0.7");
        request.Headers.Add("cache-control", "max-age=0");
        request.Headers.Add("dnt", "1");
        request.Headers.Add("priority", "u=0, i");
        request.Headers.Add("sec-ch-ua", "\"Google Chrome\";v=\"129\", \"Not=A?Brand\";v=\"8\", \"Chromium\";v=\"129\"");
        request.Headers.Add("sec-ch-ua-mobile", "?0");
        request.Headers.Add("sec-ch-ua-platform", "\"Windows\"");
        request.Headers.Add("sec-fetch-dest", "document");
        request.Headers.Add("sec-fetch-mode", "navigate");
        request.Headers.Add("sec-fetch-site", "none");
        request.Headers.Add("sec-fetch-user", "?1");
        request.Headers.Add("upgrade-insecure-requests", "1");
        request.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36");
        request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/129.0.0.0 Safari/537.36");
        request.Headers.Add("DNT", "1");

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    // Méthode synchrone pour récupérer les données
    public static YahooFinance Get(string code)
    {
        var response = YahooFinance.GetAsync(code).Result;
        return JsonConvert.DeserializeObject<YahooFinance>(response);
    }
}

public class Chart
{
    public Result[] result { get; set; }
    public object error { get; set; }
}

public class Result
{
    public Meta meta { get; set; }
    public int[] timestamp { get; set; }
    public Indicators indicators { get; set; }
}

public class Meta
{
    public string currency { get; set; }
    public string symbol { get; set; }
}

public class Indicators
{
    public Adjclose[] adjclose { get; set; }  // Ne garder que les adjclose
}

public class Adjclose
{
    public float[] adjclose { get; set; }  // Les prix ajustés de clôture
}