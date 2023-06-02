using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Unity EventSystem helps us to implement different interfaces, you can see them next to the MonoBehaviour
using UnityEngine.EventSystems;

// Interfaces are used in this class to handle Drop and Drag mechanics - to detect what is mouse doing on screen -
public class Drag_Drop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler {

    /*
     Where Transform represents a single point, 
    Rect Transform represent a rectangle that a UI
    element can be placed inside. 
     */
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    //Detect current clicks on the GameObject
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointDown");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBegin");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        // transform.position = Input.mousePosition; logic is working here to move objects in an Inventory
        // Item position copied by hte mouse position
        rectTransform.anchoredPosition += eventData.delta;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
    }

}
