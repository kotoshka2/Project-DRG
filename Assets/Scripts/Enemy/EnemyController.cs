using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType
    {
        Range,
        Melee
    }
    private Camera mainCam;
    private NavMeshAgent agent;
    private Vector3 target;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private EnemyType type;
    void Start()
    {
        mainCam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        switch (type)
        {
            case EnemyType.Melee:
                target = new Vector3(player.transform.position.x,1,player.transform.position.z);
                
                break;
            case EnemyType.Range:
                target = Vector3.Lerp(this.transform.position, player.transform.position,0.5f);
                
                break;
        }
        agent.SetDestination(target);
    }
}
