using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This is for Sard's AI - M3rt
/// </summary>
public class Sardonyx : EnemyStats
{

    [Header("Way Points")]
    [SerializeField] protected NavMeshAgent AI_Agent;
    [SerializeField] protected Transform[] WayPoints;
    [SerializeField] protected Transform CurrentWayPoint;
    [SerializeField] protected int WayPointNumber = 0;

    [Header("Ability")]
    [SerializeField] MeshRenderer CharacterRender;
    [SerializeField] float MaximumStandTime;
    [SerializeField] float TimeUntilMove;

    //[Header("Raycast")]
    //[SerializeField] CharacterSprite Character;
    //[SerializeField] float RayDistance;
    //RaycastHit RayHit;

    [Header("MovementSpeed")]
    [SerializeField] float Speed;
    [SerializeField] float Acceleration;

    void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        SetUpAgent();
        TimeUntilMove = (Random.Range(1, MaximumStandTime / AggressionLevel));
    }

    void Update()
    {
        AI_Agent.destination = CurrentWayPoint.position;
        if (TimeUntilMove > 0)
        {
            StandInPosition();
        }
        else
        {
            FollowWayPoints();
        }
        if(Manager.CurrentState == GameManager.GameState.IsBeaten || IsActive == false)
        {
            Destroy(this.gameObject);
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

    void SetUpAgent()
    {
        AI_Agent = GetComponent<NavMeshAgent>();
        CurrentWayPoint = WayPoints[WayPointNumber];
        AI_Agent.SetDestination(CurrentWayPoint.position);
    }

    void StandInPosition()
    {
        CharacterRender.material.color = Color.white;
        AI_Agent.isStopped = true;
        AI_Agent.speed = 0;
        AI_Agent.acceleration = 0;
        WayPointNumber = Random.Range(1, WayPoints.Length);
        TimeUntilMove -= 1 * Time.deltaTime;
    }

    void FollowWayPoints()
    {
        CharacterRender.material.color = new Vector4(1, 1, 1, 0.75f);
        AI_Agent.isStopped = false;
        AI_Agent.speed = Speed * AggressionLevel;
        AI_Agent.acceleration = Acceleration * AggressionLevel;
        CurrentWayPoint = WayPoints[WayPointNumber];
        if (AI_Agent.remainingDistance <= 1)
        {
            TimeUntilMove = (Random.Range(0, MaximumStandTime / AggressionLevel));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Respawn"))
        {
            WayPointNumber = Random.Range(0, WayPoints.Length);
        }
        if (collision.collider.CompareTag("Player"))
        {
            KillPlayer();
        }
    }
}
