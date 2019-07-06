using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusaCtrl : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    private Transform tr;
    
    public float speed = 5.0f;      //이동 속도
    public float damping = 3.0f;    //회전 속도

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
#if UNITY_EDITOR        
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 20.0f , Color.green);
#endif

#if UNITY_ANDROID
        //첫 번째 손가락으로 터치한 경우
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); //첫 번째 손가락의 좌표
        }
#endif
        //바닥만 검출하는 레이캐스트를 캐스팅
        if (Physics.Raycast(ray, out hit, 20.0F, 1<<10))
        {
            //이동해야할 지점까지의 벡터를 계산
            Vector3 dir = hit.point - tr.position;
            //벡터의 각도(쿼터니언 타입으로 산출)
            Quaternion rot = Quaternion.LookRotation(dir);
            //주인공 캐릭터의 점진적으로 회전
            tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
        }
    }
}
