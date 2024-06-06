


using Newtonsoft.Json;
using Polly;

var httpClient = new HttpClient();
var maxRetryAttempts = 3;
var pauseBetweenFailures = TimeSpan.FromSeconds(2);

var retryPolicy = Policy
    .Handle<HttpRequestException>()
    .WaitAndRetryAsync(maxRetryAttempts, i => pauseBetweenFailures);

await retryPolicy.ExecuteAsync(async () =>
{
    global::System.Console.WriteLine("test one");

    var response = httpClient
      .GetStringAsync("https://fakestoreapi.com").Result;
        var res = JsonConvert.SerializeObject(response);
});