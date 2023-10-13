
using Newtonsoft.Json;
using System.Runtime.Serialization;

HttpClient httpClient = new HttpClient();
string stringAPI = "https://api.wallex.ir/v1/currencies/stats";
HttpResponseMessage response = await httpClient.GetAsync(stringAPI);
if (response.IsSuccessStatusCode)
{
    string apiresponse = await response.Content.ReadAsStringAsync();

    ApiResponseWrapper apiWrapper = JsonConvert.DeserializeObject<ApiResponseWrapper>(apiresponse);
    List<DataItem> dataItems = apiWrapper.result;
    int i = 0;
    foreach (var item in dataItems)
    {
        if (i > 10)
        {
            break;
        }
        Console.WriteLine($"Key: {item.key}");
        Console.WriteLine($"Name: {item.name_en}");
        Console.WriteLine($"rank: {item.rank}");
        Console.WriteLine($"price: {item.price}");
        Console.WriteLine($"Daily high price: {item.daily_high_price}");
        Console.WriteLine($"Daily low price: {item.daily_low_price}");
        Console.WriteLine($"Weekly high price: {item.weekly_high_price}");
        Console.WriteLine($"Weekly low price: {item.weekly_low_price}");
        Console.WriteLine($"price change 24h: {item.price_change_24h}");
        Console.WriteLine($"price_change_7d: {item.price_change_7d}");
        Console.WriteLine($"Updated at: {item.updated_at}");
        Console.WriteLine("Pishbini");
        Pishbini(item.daily_high_price, item.daily_low_price , item.price_change_24h, item.price_change_7d , item.key);
        Console.WriteLine("*********************************************************************");
        i++;
    }
}
 void Pishbini(string DH , string DL , string PCH , string PCD , string KEY)
{
    decimal dh = decimal.Parse(DH);
    decimal dl = decimal.Parse(DL);
    decimal pch = decimal.Parse(PCH);
    decimal pcd = decimal.Parse(PCD);
    decimal P1 = pcd + pch;
    decimal P2;
    if (P1 < 0)
    { 
    P2 = P1 * -1;
    }
    else   
    {
    P2 = P1;
    }
    decimal P3 = P2 + dh;
    decimal P4 = P2 + dl;
    Console.WriteLine($"Daily high price: {P3}");
    Console.WriteLine($"Daily Low price: {P4}");
    }
public class ApiResponseWrapper
{
    public List<DataItem> result { get; set; }

}
public class DataItem
{
    public string key { get; set; }
    public string name_en { get; set; }
    public string rank { get; set; }
    public string price { get; set; }
    public string daily_high_price { get; set; }
    public string daily_low_price { get; set; }
    public string weekly_high_price { get; set; }
    public string weekly_low_price { get; set; }
    public string price_change_24h { get; set; }
    public string price_change_7d { get; set; }
    public DateTime updated_at { get; set; }
}