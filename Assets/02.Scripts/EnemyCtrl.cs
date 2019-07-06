using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    private Transform tr;
    private Transform playerTr;
    private NavMeshAgent nv;
    private Animator anim;

    public Transform[] points;
    public int nextIdx = 1;

    public float attackDist = 1.0f;
    public float traceDist  = 5.0f;

    void Start()
    {
        tr          = GetComponent<Transform>();
        playerTr    = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nv          = GetComponent<NavMeshAgent>();
        anim        = GetComponent<Animator>();

        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();

        nv.SetDestination(points[nextIdx].position);
        nv.isStopped = false;
    }

    void Update()
    {
        float dist = Vector3.Distance(tr.position, playerTr.position);
        
        if (dist <= attackDist)     //공격사정거리 이내의 경우
        {
            nv.isStopped = true;
            anim.SetTrigger("Attack");
            anim.SetBool("IsTrace", false);
        }
        else if (dist <= traceDist) //추적사정거리 이내의 경우
        {
            nv.SetDestination(playerTr.position);
            nv.isStopped = false;
            anim.SetBool("IsTrace", true);
        }
        //순찰 모드
        else if (nv.velocity.sqrMagnitude >= 0.2f * 0.2f //속도가 0.2 클때 --> 이동 중 일때
           && nv.remainingDistance <= 0.2f)         //목적지까지 남은 거리가 0.2(20cm) 이하일 경우
        {
            nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
            nv.SetDestination(points[nextIdx].position);
            nv.isStopped = false;
        }
    }
}
