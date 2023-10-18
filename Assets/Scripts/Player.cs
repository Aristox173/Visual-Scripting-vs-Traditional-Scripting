using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Attributes
    [SerializeField]
    private float moveSpeed = 5f;

    #region Camera
    private Camera mainCamera;
    private float cameraWidth;
    #endregion

    #region Bullet
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}