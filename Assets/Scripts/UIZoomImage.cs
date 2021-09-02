using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIZoomImage : MonoBehaviour, IScrollHandler
{
    private Vector3 initialScale;

    [SerializeField]
    private float zoomSpeed = 0.1f;
    [SerializeField]
    private float maxZoom = 10f;

    [SerializeField] private Button up;
    [SerializeField] private Button down;
    Vector2 firstTouchPrevPos, secondTouchPrevPos;

    float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;

    [SerializeField] private TextMeshProUGUI debug;

    private void Awake()
    {
        initialScale = transform.localScale;
        up.onClick.AddListener(() =>
        {
            OnZoom(1);
        });
        down.onClick.AddListener(() =>
        {
            OnZoom(-1);
        });
    }

    public void OnScroll(PointerEventData eventData)
    {
        Debug.Log(eventData.scrollDelta.y);
        OnZoom(eventData.scrollDelta.y);
    }

    private void OnZoom(float scrollDeltaY)
    {
        var delta = Vector3.one * (scrollDeltaY * zoomSpeed);
        var desiredScale = transform.localScale + delta;
        desiredScale = ClampDesiredScale(desiredScale);
        transform.localScale = desiredScale;
    }

    private Vector3 ClampDesiredScale(Vector3 desiredScale)
    {
        desiredScale = Vector3.Max(initialScale, desiredScale);
        desiredScale = Vector3.Min(initialScale * maxZoom, desiredScale);
        return desiredScale;
    }
}
