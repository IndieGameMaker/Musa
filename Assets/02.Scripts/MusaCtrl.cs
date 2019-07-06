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

    }
}
