using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinatesHandler : MonoBehaviour
{
     TextMeshPro textLabel;
     Vector2Int coordinates =new Vector2Int();
    private Waypoint waypoint;
    [SerializeField]
    private Color defaultColor =Color.white;
    [SerializeField]
    private Color fadedColor = Color.grey;
    // Start is called before the first frame update
    void Awake()
    {
        textLabel = GetComponent<TextMeshPro>();
        SetCoordinates();
        waypoint = GetComponentInParent<Waypoint>();
        textLabel.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            SetCoordinates();
            SetTileNames();
        }
        SetLabelColors();
        ToggleLabels();
        
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

    void SetLabelColors()
    {
        if (waypoint.IsPlaceable)
        {
            textLabel.color = defaultColor;
        }
        else
        {
            textLabel.color = fadedColor;
        }
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            textLabel.enabled = !textLabel.IsActive();
        }
    }
}
