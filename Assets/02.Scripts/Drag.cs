using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler
{
    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();        
    }

    public void OnDrag(PointerEventData eventData)
    {
        tr.position = Input.mousePosition;
    }

}
