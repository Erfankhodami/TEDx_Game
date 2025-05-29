using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DataSender : MonoBehaviour
{
    // Example: set this in the inspector or replace with your friend's API base URL
    public string apiBaseUrl = "https://tedxui.ir";

    // Example GET: Read data from the API
    public void GetData(string endpoint)
    {
        StartCoroutine(GetRequest(apiBaseUrl + endpoint));
    }

    // Example POST: Send data to the API
    public void PostData(string endpoint, string jsonData)
    {
        StartCoroutine(PostRequest(apiBaseUrl + endpoint, jsonData));
    }

    // Handles the GET request
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("GET Error: " + request.error);
            }
            else
            {
                Debug.Log("GET Success: " + request.downloadHandler.text);
                // Use request.downloadHandler.text to get the response as a string
            }
        }
    }

    // Handles the POST request
    IEnumerator PostRequest(string uri, string jsonData)
    {
        UnityWebRequest request = new UnityWebRequest(uri, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("POST Error: " + request.error);
        }
        else
        {
            Debug.Log("POST Success: " + request.downloadHandler.text);
            // Use request.downloadHandler.text to get the response as a string
        }
    }
}