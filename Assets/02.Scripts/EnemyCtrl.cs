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

    void Start()
    {
        tr          = GetComponent<Transform>();
        playerTr    = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        nv          = GetComponent<NavMeshAgent>();
        anim        = GetComponent<Animator>();

        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
