using System.Collections;
using System.Collections.Generic;
using Rest;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InitializeMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name, version, lastExpansion, lastExpansionVersion;

    [SerializeField] private Image image;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RestGet.GetRequest("https://raw.githubusercontent.com/luisplata/LostPlayerWoW_Resource/main/InformationGame.json", (InfoGame infoGame) =>
        {
            name.text = $"App: {infoGame.name}";
            version.text = $"Version {infoGame.Version}";
            lastExpansion.text = $"Expansion: {infoGame.nameLastExpansion}";
            lastExpansionVersion.text = $"Version: {infoGame.versionLastExpansion}";
        }, () =>
        {
            name.text = "Error:";
            version.text = "No have connection internet";
        }));
        StartCoroutine(RestGet.GetImageRequest("https://raw.githubusercontent.com/luisplata/LostPlayerWoW_Resource/main/BurningCrusade/WoWlogo.png", result =>
        {
            
        }, () =>
        {
            Debug.Log("Error");
        }));
    }
}
