using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
                    , IDragHandler
                    , IBeginDragHandler
                    , IEndDragHandler
{
    public static GameObject draggedItem = null;
    private Transform tr;
    private Transform inventoryTr;
    private Transform itemTr;

    void Start()
    {
        tr = GetComponent<Transform>();        
        inventoryTr = GameObject.Find("Inventory").GetComponent<Transform>();
        itemTr      = GameObject.Find("ItemList").GetComponent<Transform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        tr.position = Input.mousePosition;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        tr.SetParent(inventoryTr);
        //자신을 드래드아이템으로 설정
        draggedItem = this.gameObject;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData data)
    {
        //드래그 되는 아이템이 없음
        draggedItem = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //
        if (tr.parent == inventoryTr)
        {
            tr.SetParent(itemTr);
        }
    }
}
