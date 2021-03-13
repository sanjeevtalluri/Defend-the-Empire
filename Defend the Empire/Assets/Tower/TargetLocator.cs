using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField]
    private Transform weapon;
    private Transform target;

    private Enemy[] possibleTargets;

    [SerializeField]
    private ParticleSystem ballista;

    private float range = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {    
        FindCloserTarget();
        if (target)
        {
            AimWeapon();
        }
       
    }
    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
        weapon.LookAt(target);
    }
    void FindCloserTarget()
    {
        possibleTargets = FindObjectsOfType<Enemy>();
        float minDistance = Mathf.Infinity;
        Transform currTarget = null;
        foreach(Enemy enemy in possibleTargets)
        {
            float currDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (currDistance < minDistance)
            {
                minDistance = currDistance;
                currTarget = enemy.transform;
            }
        }
        target = currTarget;
    }
    void Attack(bool isWithinRange)
    {
        var emissionModule = ballista.emission;
        emissionModule.enabled = isWithinRange;
    }

}
