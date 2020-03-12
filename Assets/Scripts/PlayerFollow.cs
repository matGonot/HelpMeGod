using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerFollow : MonoBehaviour
{
    public GameObject player;
    private void Update()
    {
        GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
    }
}
