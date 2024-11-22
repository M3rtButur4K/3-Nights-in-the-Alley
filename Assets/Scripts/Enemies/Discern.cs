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
    [SerializeField] protected bool IsChasingPlayer;

    [Header("Way Points")]
    [SerializeField] protected NavMeshAgent AI_Agent;
    [SerializeField] protected Transform[] WayPoints;
    [SerializeField] protected Transform CurrentWayPoint;
    [SerializeField] protected int WayPointNumber = 0;

    [SerializeField] float MaximumStandTime;
    [SerializeField] float TimeUntilMove;

    [Header("Raycast")]
    [SerializeField] CharacterSprite Character;
    [SerializeField] float RayDistance;
    RaycastHit RayHit;

    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        SetUpAgent();
    }

    void Update()
    {

        SwitchStates();
        if (Manager.CurrentState == GameManager.GameState.IsBeaten || IsActive == false)
        {
            Destroy(this.gameObject);
        }
    }
    void SetUpAgent()
    {
        AI_Agent = GetComponent<NavMeshAgent>();
        CurrentWayPoint = WayPoints[WayPointNumber];
        AI_Agent.SetDestination(CurrentWayPoint.position);
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

    void DoRayCast()
    {
        Physics.Raycast(Character.Looker.position, Character.Looker.forward, out RayHit, RayDistance);
        Debug.DrawRay(Character.Looker.position, Character.Looker.forward * RayDistance, Color.red);
        if (RayHit.collider.CompareTag("Respawn"))
        {
            WayPointNumber = Random.Range(0, WayPoints.Length);
            IsChasingPlayer = false;
            NoisePoints.Capacity = 0;
        }
    }

    void FollowWayPoints()
    {
        DoRayCast();
        CurrentWayPoint = WayPoints[WayPointNumber];
        if (AI_Agent.remainingDistance <= 1)
        {
            StandInPosition();
        }
        if (NoisePoints.Count > 0)
        {
            CurrentState = FollowState.NoiseRoute;
        }
        AI_Agent.destination = CurrentWayPoint.position;
    }

    void FollowNoisePoints()
    {
        DoRayCast();
        if (NoisePoints.Count >= 3)
        {
            AI_Agent.SetDestination(Manager.PlayerPosition.position);
            IsChasingPlayer = true;
        }
        if (AI_Agent.remainingDistance <= 3 && !AI_Agent.isPathStale && !IsChasingPlayer)
        {
            NoisePoints.RemoveAt(0);
        }
        if (NoisePoints.Count <= 0)
        {
            CurrentState = FollowState.NormalRoute;
        }
        if(!IsChasingPlayer)
        {
            AI_Agent.destination = NoisePoints[0];
        }

    }

    void StandInPosition()
    {
        AI_Agent.isStopped = true;
        AI_Agent.speed = 0;
        AI_Agent.acceleration = 0;
        WayPointNumber = Random.Range(1, WayPoints.Length);
        TimeUntilMove -= 1 * Time.deltaTime;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Respawn") && CurrentState == FollowState.NoiseRoute)
        {
            NoisePoints.RemoveRange(0, NoisePoints.Count);
            IsChasingPlayer = false;
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
