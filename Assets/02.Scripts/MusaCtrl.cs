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

    //이동할 좌표를 저장 변수
    private Vector3 movePoint = Vector3.zero;
    private Animator anim;
    //해쉬값 미리 추출
    private int hashIsRun = Animator.StringToHash("IsRun");

    void Start()
    {
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
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
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, 20.0F, 1<<10))
        {
            movePoint = hit.point;
        }

        //(현재위치 - 목적지) => 길이 
        if ((tr.position - movePoint).sqrMagnitude >= 0.2f * 0.2f)
        {
            anim.SetBool(hashIsRun, true);
            //이동해야할 지점까지의 벡터를 계산
            Vector3 dir = movePoint - tr.position;
            //벡터의 각도(쿼터니언 타입으로 산출)
            Quaternion rot = Quaternion.LookRotation(dir);
            //주인공 캐릭터의 점진적으로 회전
            tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);
            //주인공 캐릭터의 전진
            tr.Translate(Vector3.forward * Time.deltaTime * speed);        
        }
        else
        {
            anim.SetBool(hashIsRun, false);
        }
    }
}
