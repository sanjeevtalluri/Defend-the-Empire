using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private List<Waypoint> waypoints = new List<Waypoint>();
    [SerializeField]
    private float waitingTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveToWaypoints());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveToWaypoints()
    {
        foreach(Waypoint waypoint in waypoints){
            transform.position = (waypoint.transform.position);
            yield return new WaitForSeconds(waitingTime);
        }
    }
}
