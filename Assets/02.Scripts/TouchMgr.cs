using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMgr : MonoBehaviour
{
    private Camera cam;
    private Ray ray;
    private RaycastHit hit;

    void Start()
    {
        cam = Camera.main;        
    }

    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);

        if (Input.GetMouseButtonDown(0)
            && Physics.Raycast(ray, out hit, 100.0f, 1<<8))
        {
            Destroy(hit.collider.gameObject);
            Explosion(hit.point);
        }        
    }
    
    //폭발효과 발생
    void Explosion(Vector3 point)
    {
        //순간적으로 컬라이더를 오버랩해서 대상을 추출
        Collider[] colls = Physics.OverlapSphere(point, 10.0f, 1<<9);
        foreach(var coll in colls)
        {
            coll.GetComponent<Rigidbody>().AddExplosionForce(1500.0f, point, 10.0f, 1800.0f);
        }
    }

}
