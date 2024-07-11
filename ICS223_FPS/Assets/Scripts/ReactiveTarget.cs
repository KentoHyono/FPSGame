using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Only attached to enemies
public class ReactiveTarget : MonoBehaviour
{
    private bool isAlive = true;
    public void ReactToHit()
    {
        WanderingAI enemyAI = GetComponent<WanderingAI>();
        if (enemyAI != null)
        {
            enemyAI.ChangeState(EnemyStates.dead);
        }

        Animator enemyAnimator = GetComponent<Animator>();
        if (enemyAnimator != null)
        {
            enemyAnimator.SetTrigger("Die");
        }

        if (isAlive)
        {
            Messenger.Broadcast(GameEvent.ENEMY_DEAD);
            isAlive = false;
        }
        // StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        // Emnemy falls over and disappears after two seconds
        // iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);

        yield return new WaitForSeconds(2);

        Destroy(this.gameObject);
        
    }

    private void DeadEvent()
    {
        Destroy(this.gameObject);
    }
}
