using Microsoft.AspNetCore.SignalR.Client;

var hubConnection = new HubConnectionBuilder()
    //.WithUrl("http://localhost:5081/SignalR")
    .WithUrl("https://signalrservertestjd.azurewebsites.net/SignalR")
    .Build();

hubConnection.On<string>("SentMessage", (message) => {
    Console.WriteLine($"Message: {message}");
});

await hubConnection.StartAsync();

string? input = "Connected...";

Console.WriteLine(input);

while(!String.IsNullOrWhiteSpace(input))
{
    input = Console.ReadLine();
    await hubConnection.InvokeAsync<string>("SendMessage", input);
}

await hubConnection.StopAsync();
