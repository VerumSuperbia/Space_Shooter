using UnityEngine;
using UnityEngine.UIElements;

public class Enemy_Ship : MonoBehaviour
{
    private Vector2 ori_size;
    private float scale;
    public GameObject laserPrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    public float laserSpeed = 10f;
    private float hp = 4;
    private float timer = 0f;
    public float updateInterval = 0.2f;
    private Score_Manager score_Manager;
    private GameObject score;
    public AudioSource shootingSound;
    private GameObject destroyedShip;
    private AudioSource destroyedShipAudio;
    private void GenerateEnemyLaser()
    {
        // Direction of the laser.
        Vector2 direction = Vector2.down;
        
        // Instantiate a new laser at the spawn point position and rotation
        GameObject Laser1 = Instantiate(laserPrefab, firePoint1.position, Quaternion.identity);
        GameObject Laser2 = Instantiate(laserPrefab, firePoint2.position, Quaternion.identity);


        // Set the laser's initial velocity based on the direction and speed
        Laser1.GetComponent<Rigidbody2D>().velocity = direction * laserSpeed;
        Laser2.GetComponent<Rigidbody2D>().velocity = direction * laserSpeed;
        // yield return new WaitForSeconds(0.2f);
        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        destroyedShip = GameObject.FindWithTag("EnemyDestroyed");
        destroyedShipAudio = destroyedShip.GetComponent<AudioSource>();
        score = GameObject.FindWithTag("Score");
        score_Manager = score.GetComponent<Score_Manager>();
        Destroy(gameObject, 3f);
        int choice = Random.Range(1, 4);
        ori_size = transform.localScale;
        if (choice == 1)
        {
            transform.localScale = ori_size * 0.5f;
            gameObject.tag = "EnemyShip1"; hp = 2;
        }
        else if (choice == 3)
        {
            transform.localScale = ori_size * 1.5f;
            gameObject.tag = "EnemyShip3"; hp = 6;
        }
        else { gameObject.tag = "EnemyShip2"; }
        scale = transform.localScale.x / ori_size.x;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= updateInterval)
        {
            GenerateEnemyLaser();
            shootingSound.Play();
            timer = 0f;
        }
        if (hp == 0)
        {
            destroyedShipAudio.Play();
            score_Manager.AddScore(1000);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            hp -= 1;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
