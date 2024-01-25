using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static GameManager;

public class Discern : EnemyStats
{
    
    [SerializeField] protected enum FollowState
    {
        NormalRoute,
        NoiseRoute,
    }
    [Header("Ability")]
    [SerializeField] protected FollowState CurrentState;
    [SerializeField] protected List<Vector3> NoisePoints;

    [Header("Way Points")]
    [SerializeField] protected NavMeshAgent AI_Agent;
    [SerializeField] protected Transform[] WayPoints;
    [SerializeField] protected Transform CurrentWayPoint;
    [SerializeField] protected int WayPointNumber = 0;

    //[Header("Raycast")]
    //[SerializeField] CharacterSprite Character;
    //[SerializeField] float RayDistance;
    //RaycastHit RayHit;

    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        AI_Agent = GetComponent<NavMeshAgent>();
        CurrentWayPoint = WayPoints[WayPointNumber];
        AI_Agent.SetDestination(CurrentWayPoint.position);
    }

    void Update()
    {
        SwitchStates();
        if (Manager.CurrentState == GameManager.GameState.IsBeaten || IsActive == false)
        {
            Destroy(this.gameObject);
        }
    }

    void SwitchStates()
    {
        switch (CurrentState)
        {
            case FollowState.NormalRoute:
                FollowWayPoints();
                break;
            case FollowState.NoiseRoute:
                FollowNoisePoints();
                break;
            default:
                break;
        }
    }

    //void DoRayCast()
    //{
    //    Physics.Raycast(Character.Looker.position, Character.Looker.forward, out RayHit, RayDistance);
    //    if(RayHit.collider.CompareTag("Respawn"))
    //    {
    //        WayPointNumber = Random.Range(0, WayPoints.Length);
    //    }
    //}

    void FollowWayPoints()
    {
        CurrentWayPoint = WayPoints[WayPointNumber];
        if (AI_Agent.remainingDistance <= 1)
        {
            WayPointNumber = Random.Range(0, WayPoints.Length);
        }
        if (NoisePoints.Count > 0)
        {
            CurrentState = FollowState.NoiseRoute;
        }
        AI_Agent.destination = CurrentWayPoint.position;
    }

    void FollowNoisePoints()
    {
        if (NoisePoints.Count > 3)
        {
            AI_Agent.destination = Manager.PlayerPosition.position;
        }
        if (AI_Agent.remainingDistance <= 1 && NoisePoints.Count <= 3)
        {
            NoisePoints.RemoveAt(0);
        }
        AI_Agent.destination = NoisePoints[0];

        if(NoisePoints.Count <= 0)
        {
            CurrentState = FollowState.NormalRoute;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Respawn"))
        {
            NoisePoints.RemoveAll(x => x != null);
            WayPointNumber = Random.Range(0, WayPoints.Length);
        }
        if (collision.collider.CompareTag("Player"))
        {
            KillPlayer();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sounds"))
        {
            NoisePoints.Add(other.transform.position);
            CurrentState = FollowState.NoiseRoute;
        }
    }
}
