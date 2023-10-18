using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Attributes
    [SerializeField]
    private float moveSpeed;

    #region Camera
    private Camera mainCamera;
    private float cameraWidth;
    #endregion

    private float initialXPosition;
    private int direction = 1;

    void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
        initialXPosition = transform.position.x;
    }

    void Update()
    {
        Vector3 newPosition = transform.position + new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

        if (Mathf.Abs(newPosition.x - initialXPosition) >= cameraWidth -1)
        {
            direction *= -1;
        }

        transform.position = newPosition;
    }
}
