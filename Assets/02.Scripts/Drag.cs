using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private Transform tr;
    private Transform inventoryTr;

    void Start()
    {
        tr = GetComponent<Transform>();        
        inventoryTr = GameObject.Find("Inventory").GetComponent<Transform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        tr.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        tr.SetParent(inventoryTr);
    }

}
