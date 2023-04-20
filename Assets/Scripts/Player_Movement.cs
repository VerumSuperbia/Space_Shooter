using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private Camera mainCamera;
    private float xMin, xMax, yMin, yMax;
    public Player_Life player_Life;
    private GameObject playerShot;
    private AudioSource playerShotAudio;
    private void Start()
    {
        playerShot = GameObject.FindWithTag("PlayerShot");
        playerShotAudio = playerShot.GetComponent<AudioSource>();
        mainCamera = Camera.main;
        CalculateScreenBounds();
    }

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
        //Vector3 movement_wasd = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        Vector3 movement_mouse = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f);

        if(movement_mouse.magnitude > 0)
        {
            transform.position += movement_mouse * movementSpeed * Time.deltaTime;
        }
        //else if(movement_wasd.magnitude > 0)
        //{
        //    transform.position += movement_wasd * movementSpeed * Time.deltaTime;
        //}

        // Clamp the object position to screen bounds
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, xMin, xMax);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, yMin, yMax);
        transform.position = clampedPosition;
    }

    private void CalculateScreenBounds()
    {
        float objectWidth = transform.GetComponent<Renderer>().bounds.size.x;
        float objectHeight = transform.GetComponent<Renderer>().bounds.size.y;

        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        xMin = bottomLeft.x + objectWidth / 2;
        xMax = topRight.x - objectWidth / 2;
        yMin = bottomLeft.y + objectHeight / 2;
        yMax = topRight.y - objectHeight / 2;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            // Add 25 from the current health and update the HP bar
            player_Life.UpdateHealth(player_Life.currentHealth + 25);
        }
        if (collision.gameObject.CompareTag("meteor1"))
        {
            // Deduct 5 from the current health and update the HP bar
            player_Life.UpdateHealth(player_Life.currentHealth - 5);
        }
        if (collision.gameObject.CompareTag("meteor2"))
        {
            // Deduct 10 from the current health and update the HP bar
            player_Life.UpdateHealth(player_Life.currentHealth - 10);
        }
        if (collision.gameObject.CompareTag("meteor3"))
        {
            // Deduct 15 from the current health and update the HP bar
            player_Life.UpdateHealth(player_Life.currentHealth - 15);
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLaser"))
        {
            playerShotAudio.Play();
            player_Life.UpdateHealth(player_Life.currentHealth - 10);
        }
        if (collision.gameObject.CompareTag("EnemyShip1"))
        {
            player_Life.UpdateHealth(player_Life.currentHealth - 30);
        }
        if (collision.gameObject.CompareTag("EnemyShip2"))
        {
            player_Life.UpdateHealth(player_Life.currentHealth - 50);
        }
        if (collision.gameObject.CompareTag("EnemyShip3"))
        {
            player_Life.UpdateHealth(player_Life.currentHealth - 70);
        }
    }
}
