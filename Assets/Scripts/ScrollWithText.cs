using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollWithText : MonoBehaviour
{
    [SerializeField] private string textDescription;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private RectTransform panel;
    [SerializeField] private int multiplicator;

    void Start()
    {
        var listOfWords = textDescription.Split(' ');
        var lines = listOfWords.Length / 5;
        if (lines <= 7) return;
        var bottomSize = multiplicator * (lines - 7);
        var offsetMin = panel.offsetMin;
        var offsetMax = panel.offsetMax;
        offsetMin = new Vector2(offsetMin.x, offsetMin.y - bottomSize);
        panel.offsetMin = offsetMin;
        panel.offsetMax = new Vector2(offsetMax.x, 0);
    }
}
