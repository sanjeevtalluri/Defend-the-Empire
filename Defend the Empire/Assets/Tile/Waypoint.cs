using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    bool isPlaceable;
    [SerializeField]
    private GameObject tankPrefab;
    // Start is called before the first frame update

    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Instantiate(tankPrefab, transform.position, Quaternion.identity);
            Debug.Log(transform.name);
            isPlaceable = false;
        }
        
    }
}
