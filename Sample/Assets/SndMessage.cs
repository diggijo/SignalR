using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class SndMessage : MonoBehaviour
{
    public string userInput = "";
    private string receivedMessage;
    HubConnection hubConnection;

    // Start is called before the first frame update
    void Start()
    {
        var fireAndForgetTask = MyStartAsync();
    }

    private async Task MyStartAsync()
    {
        hubConnection = new HubConnectionBuilder()
            //.WithUrl("http://localhost:5081/SignalR")
            .WithUrl("https://signalrservertestjd.azurewebsites.net/SignalR")
            .Build();

        hubConnection.On<string>("SentMessage", (message) =>
        {
            receivedMessage = message;
        });

        await hubConnection.StartAsync();
    }

    private void OnGUI()
    {
        userInput = UnityEngine.GUI.TextField(new UnityEngine.Rect(10, 10, 200, 20), userInput);
        if (Input.GetKey(KeyCode.Return) && !String.IsNullOrWhiteSpace(userInput))
        {
            hubConnection.SendAsync("SendMessage", userInput);
            userInput = "";
        }

        UnityEngine.GUI.Label(new UnityEngine.Rect(10, UnityEngine.Screen.height - 30, 300, 20), "Message: " + receivedMessage);
    }
}
