using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHitPoints = 5;
    [SerializeField]
    private int difficultyIncrement = 1;

    private int currHitPoints=0;

    private Enemy enemy;
    // Start is called before the first frame update
    void OnEnable()
    {
        currHitPoints = maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        HitByBallista();
    }
    void HitByBallista()
    {
        currHitPoints--;
        if (currHitPoints <= 0)
        {        
            gameObject.SetActive(false);
            maxHitPoints += difficultyIncrement;
            enemy.RewardGold();
        }
    }
}
