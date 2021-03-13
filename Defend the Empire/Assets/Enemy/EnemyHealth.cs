using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHitPoints = 5;
    private int currHitPoints=0;
    // Start is called before the first frame update
    void OnEnable()
    {
        currHitPoints = maxHitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
