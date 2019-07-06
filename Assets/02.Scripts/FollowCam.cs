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
        Vector3 pos = target.position                 //주인공 위치
                        + (Vector3.right * distance)  //카메라의 위치를 X축 이동
                        + (Vector3.up * height);      //카메라의 위치를 Y축 이동

        tr.position = Vector3.Lerp(tr.position, pos, Time.deltaTime * damping);
        //카메라를 주인공을 향해서 바라보도록 회전(Look At)
        //tr.LookAt(target.position);
    }
}
