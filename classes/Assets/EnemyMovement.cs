using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent _navmeshagent;

    GameObject _playergameobject;

    void Awake()
    {
        _navmeshagent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _playergameobject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        _navmeshagent.SetDestination(_playergameobject.transform.position);
    }
}

