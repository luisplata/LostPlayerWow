using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIZoomImage : MonoBehaviour, IScrollHandler
{
    private Vector3 initialScale;

    [SerializeField]
    private float zoomSpeed = 0.1f;
    [SerializeField]
    private float maxZoom = 10f;
    Vector2 firstTouchPrevPos, secondTouchPrevPos;

    float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;
    [SerializeField]
    float zoomModifierSpeed = 0.1f;

    [SerializeField] private TextMeshProUGUI debug;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    private float zoomBefore;
    private void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch firstTouch = Input.GetTouch (0);
            Touch secondTouch = Input.GetTouch (1);

            touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;
            
            zoomModifier = touchesCurPosDifference;
            if (zoomBefore > zoomModifier)
            {
                OnZoom(-1);
            }
            else
            {
                OnZoom(1);
            }
            zoomBefore = zoomModifier;
        }
    }

    public void OnScroll(PointerEventData eventData)
    {
        Debug.Log(eventData.scrollDelta.y);
        OnZoom(eventData.scrollDelta.y);
    }

    private void OnZoom(float scrollDeltaY)
    {
        debug.text = $"scrollDeltaY {scrollDeltaY}";
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
