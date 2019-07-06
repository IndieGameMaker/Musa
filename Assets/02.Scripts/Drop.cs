using UnityEngine;
using UnityEngine.EventSystems; //이벤트 관련 메소드 사용을 위해서 추가

public class Drop : MonoBehaviour
                    ,IDropHandler
{
    public void OnDrop(PointerEventData data)
    {
        if (transform.childCount == 0)
        {
            Drag.draggedItem.transform.SetParent(this.transform);
        }
    }
}
