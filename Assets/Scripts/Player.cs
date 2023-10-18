using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributes
    [SerializeField]
    private float moveSpeed;

    #region Camera
    private Camera mainCamera;
    private float cameraWidth;
    #endregion

    void Start()
    {
        mainCamera = Camera.main;
        cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");

        Vector3 position = transform.position + new Vector3(xInput * moveSpeed * Time.deltaTime, 0, 0);

        position.x = Mathf.Clamp(position.x, -cameraWidth + 1, cameraWidth - 1);

        transform.position = position;
    }
}