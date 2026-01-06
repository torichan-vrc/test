using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.Udon;

public class GalleryManager : UdonSharpBehaviour
{
    [SerializeField] private PostFrame postFrame;
    [SerializeField] private InputField inputField;
    [SerializeField] private string defaultPostText = "Hello VRChat";

    public void SubmitPost()
    {
        if (postFrame == null)
        {
            Debug.LogWarning("PostFrame is not assigned.");
            return;
        }

        string textToPost = defaultPostText;
        if (inputField != null && !string.IsNullOrEmpty(inputField.text))
        {
            textToPost = inputField.text;
        }

        postFrame.SetPostText(textToPost);
    }
}
