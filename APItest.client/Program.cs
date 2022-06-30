// See https://aka.ms/new-console-template for more information
using APItest.client;
using System.Net.Http.Headers;
using System.Net.Http.Json;


// 1. in .Net we use the HttpClient class to make the HTTP request
HttpClient client = new();

// 2. set the BaseAddress property to the URL of the API
client.BaseAddress = new Uri("https://localhost:7188");

// 3. we also tell the server that we want the result in json format
client.DefaultRequestHeaders.Accept.Clear(); //  (clears the default headers that are sent with every request. These headers are things that are common to all your requests, e.g. Content-Type, Authorization, etc.)
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

// 4. Then we are going to retrieve all the issues.
// An instance of HttpClient has methodes like GetAsync(), PostAsync() etc
HttpResponseMessage response = await client.GetAsync("api/issue"); // <- making a Get request to the API. The methode takes the URL path of the endpoint, and returns an HttpResponseMessage object
response.EnsureSuccessStatusCode(); // <- we can involve the EnsureSuccessStatusCode() to make sure the request succeeds


// If it is successful, we use the Content property and invoke the methode ReadFromJsonAsync to
// deserialize the content of the response into IEnumerable of IssueDto
if(response.IsSuccessStatusCode)
{
    var issues = await response.Content.ReadFromJsonAsync<IEnumerable<IssueDto>>();
    // now we can iterate over the results to display the title for each issue
    foreach (var issue in issues)
    {
        Console.WriteLine(issue.Title);
    } 
}
else //if there is no Issue to display
{
    Console.WriteLine("No results");
}

Console.ReadLine();