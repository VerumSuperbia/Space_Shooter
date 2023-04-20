using UnityEngine;

public class Cannons : MonoBehaviour
{
    public float rotationSpeed = 5.0f;
    public float minAngle = -45.0f;
    public float maxAngle = 45.0f;
    public GameObject laserPrefab;
    public Transform firePoint;
    public float laserSpeed = 10f;
    private void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.back * horizontalInput * rotationSpeed);

        float currentAngle = transform.localEulerAngles.z;
        if (currentAngle > 180.0f)
        {
            currentAngle -= 360.0f;
        }

        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, currentAngle);

        if (Input.GetMouseButtonDown(0))
        {
            // Calculate the initial direction of the laser based on the cannon's rotation
            Quaternion rotation = Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward);
            Vector2 direction = rotation * Vector2.up;

            // Instantiate a new laser at the spawn point position and rotation
            GameObject newLaser = Instantiate(laserPrefab, firePoint.position, Quaternion.identity);

            //Instantiate the laser in the same rotation as the canon.
            newLaser.transform.rotation = rotation;

            // Set the laser's initial velocity based on the direction and speed
            newLaser.GetComponent<Rigidbody2D>().velocity = direction * laserSpeed;
        }  
    }
}
