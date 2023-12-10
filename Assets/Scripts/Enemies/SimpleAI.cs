using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This is Just for Testing around with an AI opponent - M3rt
/// </summary>
public class SimpleAI : MonoBehaviour
{
    public NavMeshAgent AI_Agent;

    [Header("Way Points")]
    [SerializeField] protected Transform[] WayPoints;
    [SerializeField] protected Transform CurrentWayPoint;
    [SerializeField] protected int WayPointNumber = 0;

    [Header("Raycast")]
    [SerializeField] CharacterSprite Character;
    [SerializeField] float RayDistance;
    RaycastHit RayHit;

    void Start()
    {
        AI_Agent = GetComponent<NavMeshAgent>();
        CurrentWayPoint = WayPoints[WayPointNumber];
        AI_Agent.SetDestination(CurrentWayPoint.position);
    }

    void Update()
    {
        DoWayPoints();
        //DoRayCast();
    }

    void DoWayPoints()
    {
        CurrentWayPoint = WayPoints[WayPointNumber];
        if (AI_Agent.remainingDistance <= 1)
        {
            WayPointNumber = Random.Range(0, WayPoints.Length);
        }
        AI_Agent.destination = CurrentWayPoint.position;
    }

    //void DoRayCast()
    //{
    //    Physics.Raycast(Character.Looker.position, Character.Looker.forward, out RayHit, RayDistance);
    //    if(RayHit.collider.CompareTag("Respawn"))
    //    {
    //        WayPointNumber = Random.Range(0, WayPoints.Length);
    //    }
    //    if (RayHit.collider.CompareTag("Player"))
    //    {
    //        GameManager manager = FindObjectOfType<GameManager>();
    //        manager.CurrentState = GameManager.GameState.IsDead;
    //        this.gameObject.SetActive(false);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Respawn"))
        {
            WayPointNumber = Random.Range(0, WayPoints.Length);
        }
        if (collision.collider.CompareTag("Player"))
        {
            GameManager manager = FindObjectOfType<GameManager>();
            manager.CurrentState = GameManager.GameState.IsDead;
            this.gameObject.SetActive(false);
        }
    }
}
