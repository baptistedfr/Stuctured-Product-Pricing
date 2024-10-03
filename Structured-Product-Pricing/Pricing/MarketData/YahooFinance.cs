using Newtonsoft.Json;

namespace Pricing.MarketData
{
    internal class YahooFinance
    {
        public YahooChart chart { get; set; }

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
        public static YahooFinance Get(string code)
        {
            var response = YahooFinance.GetAsync(code).Result;
            return JsonConvert.DeserializeObject<YahooFinance>(response);
        }
        public static float GetLastSpot(string code)
        {
            var data = Get(code);
            return data.chart.result.First().indicators.adjclose.First().adjclose.Last();
        }

        public class YahooChart
        {
            public YahooResult[] result { get; set; }
            public object error { get; set; }
        }

        public class YahooResult
        {
            public YahooMeta meta { get; set; }
            public int[] timestamp { get; set; }
            public YahooIndicators indicators { get; set; }
        }

        public class YahooMeta
        {
            public string currency { get; set; }
            public string symbol { get; set; }
            public string exchangeName { get; set; }
            public string fullExchangeName { get; set; }
            public string instrumentType { get; set; }
            public int firstTradeDate { get; set; }
            public int regularMarketTime { get; set; }
            public bool hasPrePostMarketData { get; set; }
            public int gmtoffset { get; set; }
            public string timezone { get; set; }
            public string exchangeTimezoneName { get; set; }
            public float regularMarketPrice { get; set; }
            public float fiftyTwoWeekHigh { get; set; }
            public float fiftyTwoWeekLow { get; set; }
            public float regularMarketDayHigh { get; set; }
            public float regularMarketDayLow { get; set; }
            public int regularMarketVolume { get; set; }
            public string longName { get; set; }
            public string shortName { get; set; }
            public float chartPreviousClose { get; set; }
            public int priceHint { get; set; }
            public YahooCurrenttradingperiod currentTradingPeriod { get; set; }
            public string dataGranularity { get; set; }
            public string range { get; set; }
            public string[] validRanges { get; set; }
        }

        public class YahooCurrenttradingperiod
        {
            public YahooPre pre { get; set; }
            public YahooRegular regular { get; set; }
            public YahooPost post { get; set; }
        }

        public class YahooPre
        {
            public string timezone { get; set; }
            public int start { get; set; }
            public int end { get; set; }
            public int gmtoffset { get; set; }
        }

        public class YahooRegular
        {
            public string timezone { get; set; }
            public int start { get; set; }
            public int end { get; set; }
            public int gmtoffset { get; set; }
        }

        public class YahooPost
        {
            public string timezone { get; set; }
            public int start { get; set; }
            public int end { get; set; }
            public int gmtoffset { get; set; }
        }

        public class YahooIndicators
        {
            public YahooQuote[] quote { get; set; }
            public YahooAdjclose[] adjclose { get; set; }
        }

        public class YahooQuote
        {
            public float[] low { get; set; }
            public float[] open { get; set; }
            public float[] high { get; set; }
            public int[] volume { get; set; }
            public float[] close { get; set; }
        }

        public class YahooAdjclose
        {
            public float[] adjclose { get; set; }
        }
    }
}
