using TMPro;
using UnityEngine;

public class UserInputController : MonoBehaviour
{
    public TMP_InputField inputField;

    public void OnSendButtonClicked()
    {
        string userText = inputField.text;
        Debug.Log("Texto digitado: " + userText);

        // Aqui você vai chamar o método que envia para o backend
        SendToBackend(userText);
    }

    void SendToBackend(string text)
    {
        // Vamos implementar depois
    }
}