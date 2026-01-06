using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class PostFrame : UdonSharpBehaviour
{
    [UdonSynced] public string postText;
    [UdonSynced] public int goodCount;

    [SerializeField] private Text postTextLabel;

    private void Start()
    {
        ApplyPostText();
    }

    public void SetPostText(string newText)
    {
        if (!Networking.IsOwner(gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
        }

        postText = newText;
        RequestSerialization();
        ApplyPostText();
    }

    public void IncrementGoodCount()
    {
        if (!Networking.IsOwner(gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer, gameObject);
        }

        goodCount += 1;
        RequestSerialization();
    }

    public override void OnDeserialization()
    {
        ApplyPostText();
    }

    private void ApplyPostText()
    {
        if (postTextLabel != null)
        {
            postTextLabel.text = postText;
        }
    }
}
