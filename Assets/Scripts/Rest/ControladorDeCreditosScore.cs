using System;
using System.Collections;
using Rest;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ControladorDeCreditosScore
{
    public IEnumerator GetRequest(string uri, RestGet.RestGetOk<InfoGame> ok, RestGet.RestGetBad bad)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                //All bad
                Debug.Log(webRequest.error);
                bad();
            }
            else
            {
                //All good
                //Convert this function in Template function or Template class
                InfoGame[] contevert = JsonHelper.FromJson<InfoGame>(webRequest.downloadHandler.text);
                ok(contevert[0]);
            }
        }
    }
}