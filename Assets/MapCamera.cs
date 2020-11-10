using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public float focusSpeed;
    private Vector3 currentTargetPosition;
    private Vector3 defaultPosition;

    private void Awake()
    {
        defaultPosition = transform.position;
    }

    public void Update()
    {
        if (transform.position != currentTargetPosition)
        {
            transform.position = Vector3.Lerp(transform.position, currentTargetPosition, focusSpeed * Time.deltaTime);
        }

        if (currentTargetPosition != defaultPosition)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                currentTargetPosition = defaultPosition;
            }
        }
    }

    public void RefocusCamera(Vector3 targetPosition)
    {
        currentTargetPosition = targetPosition;
    }
}
