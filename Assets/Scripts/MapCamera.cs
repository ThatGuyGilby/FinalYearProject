using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapCamera : MonoBehaviour
{
    public Text nemesisName;
    public float focusSpeed;
    private Vector3 currentTargetPosition;
    private Vector3 defaultPosition;
    public NemesisData focus;

    private void Awake()
    {
        defaultPosition = transform.position;
        currentTargetPosition = defaultPosition;
    }

    public void Update()
    {
        if (transform.position != currentTargetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, currentTargetPosition, focusSpeed * Time.deltaTime);
        }

        if (currentTargetPosition != defaultPosition)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                focus = null;
                currentTargetPosition = defaultPosition;
            }
        }

        if (focus == null)
        {
            nemesisName.text = "";
        }
        else
        {
            nemesisName.text = focus.name + " " + focus.title;
        }
    }

    public void RefocusCamera(Vector3 targetPosition)
    {
        currentTargetPosition = targetPosition;
    }
}
