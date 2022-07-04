using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{

    private Vector2 _touchPosition;
    public Vector2 Direction { get; private set; }

    [SerializeField] private Image pivotImage;

    public void OnPointerDown(PointerEventData eventData)
    {
        _touchPosition = eventData.position;
        pivotImage.enabled = true;
        pivotImage.transform.position = _touchPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Direction = Vector2.zero;
        pivotImage.enabled = false;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {

       var delta= eventData.position - _touchPosition;
        Direction = delta.normalized;

    }
}
