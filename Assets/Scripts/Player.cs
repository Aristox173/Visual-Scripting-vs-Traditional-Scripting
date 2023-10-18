using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    private Camera mainCamera;
    private float cameraWidth;

    void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        Vector3 position = transform.position + new Vector3(xInput * moveSpeed * Time.deltaTime, 0, 0);

        position.x = Mathf.Clamp(position.x, -cameraWidth, cameraWidth);

        transform.position = position;
    }
}