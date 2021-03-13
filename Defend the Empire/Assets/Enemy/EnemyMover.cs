using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField]
    private List<Waypoint> waypoints = new List<Waypoint>();
    [SerializeField]
    private float speed = 1f;

    private Enemy enemy;
    // Start is called before the first frame update

      void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        FindPaths();
        EnemyStartPosition();
        StartCoroutine(MoveToWaypoints());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveToWaypoints()
    {
        foreach(Waypoint waypoint in waypoints)
        {
            Vector3 startPosition = transform.position;
            Vector3 destination = waypoint.transform.position;

            float pathPercentage = 0f;
            transform.LookAt(destination);
            while (pathPercentage < 1f)
            {
                pathPercentage += Time.deltaTime*speed;
                transform.position = Vector3.Lerp(startPosition, destination, pathPercentage);
                //transform.LookAt(waypoint);
                yield return new WaitForEndOfFrame();
            }
            
        }
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    void FindPaths()
    {
        waypoints.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach(Transform child in parent.transform)
        {
            waypoints.Add(child.GetComponent<Waypoint>());
        }
    }

    void EnemyStartPosition()
    {
        transform.position = waypoints[0].transform.position;
    }
}
