using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;   //타겟과의 거리
    public float height   = 5.0f;   //타겟과의 높이
    public float damping  = 3.0f;   //추적할때의 민감도

    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();        
    }

    void LateUpdate()
    {
        Vector3 movePoint = target.position - tr.position;
        Vector3 move = Vector3.Lerp(tr.position, movePoint, Time.deltaTime * damping);

        tr.position = move + Vector3.right * distance + Vector3.up * height;        
    }
}
