using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [Range(0,50)]  [SerializeField] float attackRange= 5,sightRange = 20,timeBAttacks = 3;
    [Range(0,20)]  [SerializeField] int power;

private NavMeshAgent thisEnemy;
private Transform playerPose;
private bool isAttacking;
private void Start() 
{
   thisEnemy = GetComponent<NavMeshAgent>();
   playerPose = FindObjectOfType<PlayerHealth>().transform;
}

 private void Update() 
    {
        float distanceFromPlayer = Vector3.Distance(playerPose.position, this.transform.position);
    
            if (distanceFromPlayer <= sightRange && distanceFromPlayer > attackRange && !PlayerHealth.isDead)
                {
                    isAttacking=false;
                    thisEnemy.isStopped = false;
                    StopAllCoroutines();
                    ChasePlayer();
                }

                if (distanceFromPlayer<= attackRange && !isAttacking && PlayerHealth.isDead)
                {
                    thisEnemy.isStopped = true;
                    StartCoroutine(AttackPlayer());
                }

                if(PlayerHealth.isDead)
                {
                    thisEnemy.isStopped = true;
                }

    }

 private void ChasePlayer() 
    {
    thisEnemy.SetDestination(playerPose.position);
    }


private IEnumerator AttackPlayer()
{
  isAttacking = true;

  yield return new WaitForSeconds(timeBAttacks);

    FindObjectOfType<PlayerHealth>().TakeDamage(power);

    isAttacking = false;
}

private void OnDrawGizmosSelected() 
{
   Gizmos.color = Color.cyan;
   Gizmos.DrawWireSphere(this.transform.position,sightRange);

    Gizmos.color  = Color.red;
    Gizmos.DrawWireSphere(this.transform.position,attackRange);

}

}
