using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PrototipeButtonFunction : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    [SerializeField] private Button button;
    // Start is called before the first frame update
    void Awake()
    {
        
        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(sceneIndex);
        });
        
    }

}
