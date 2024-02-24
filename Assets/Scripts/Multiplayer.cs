using System.Collections;
using UnityEngine;
using UnityEngine.Networking;



public class Multiplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        sendState();
    }

    void ConnectToServer()
    {
        // Подключаемся к серверу
        Debug.Log("Connecting to server...");

    }

    public PlayerState getLocalState()
    {
        PlayerState state = new(){
            name = "Player 1",
            currentChoose = GameChoice.Rock
        };
        string payload = JsonUtility.ToJson(state);
        Debug.Log(payload);
        return state;
    }

    void sendState()
    {
        PlayerState state = getLocalState();
        StartCoroutine(Upload(JsonUtility.ToJson(state)));
        // Отправляем состояние игрока на сервер
        Debug.Log("Sending state to server: " + state.name + " " + state.currentChoose);
    }

    IEnumerator Upload(string payload)
    {

        UnityWebRequest www = UnityWebRequest.Post("https://webhook.site/4ee6bf56-f680-4236-8171-ec9b992ff2ae", payload, "application/json");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
