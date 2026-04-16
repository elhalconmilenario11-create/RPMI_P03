using System.Collections;
using UnityEngine;

public class CombatSistem : MonoBehaviour
{
    public CardStats playerCard;
    public CardStats enemyCard;

    public Transform playerPos;
    public Transform enemyPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CardLocate();

        if (playerCard.GetAttack() >= enemyCard.GetAttack())
        {
            StartCoroutine (AttackPlayer());
        }
        else
        {
            StartCoroutine (AttackEnemy());
        }
    }

    private void CardLocate()
    {
        // JUGADOR
        playerCard.transform.parent = playerPos;
        playerCard.transform.localPosition = Vector3.zero;
        playerCard.GetComponent<SpriteRenderer>().flipX = true;

        // ENEMIGO
        enemyCard.transform.parent = enemyPos;
        enemyCard.transform.localPosition = Vector3.zero;
    }

    // private void AttackPlayer()
    private IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(1);
        Destroy(enemyCard.gameObject);
    }

    // private void AttackEnemy()
    private IEnumerator AttackEnemy()
    {
        yield return new WaitForSeconds(1);
        Destroy(playerCard.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.gameObject.GetComponent<EnemyCard>().inCombat)
            { 
            
            }
    }
}
