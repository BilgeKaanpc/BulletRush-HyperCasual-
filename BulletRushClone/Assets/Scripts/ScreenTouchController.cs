using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenTouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("dokundu");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("kaldırdı");
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Debug.Log("sürükledi");
    }
}
