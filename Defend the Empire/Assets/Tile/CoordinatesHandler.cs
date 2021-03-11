using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinatesHandler : MonoBehaviour
{
     TextMeshPro textLabel;
     Vector2Int coordinates =new Vector2Int();
    // Start is called before the first frame update
    void Awake()
    {
        textLabel = GetComponent<TextMeshPro>();
        SetCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            SetCoordinates();
            SetTileNames();
        }
        
    }
    void SetCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        textLabel.text = coordinates.x + "," + coordinates.y;
    }

    void SetTileNames()
    {
        transform.parent.name = coordinates.ToString();
    }
}
