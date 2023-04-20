using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Vector2 ori_size;
    private float scale;
    private float hp;
    private Score_Manager score_Manager;
    private GameObject score;
    private GameObject breakingSound;
    private AudioSource breakingSoundAudio;
    private GameObject meteorDestroyed;
    private AudioSource meteorDestroyedAudio;
    // Start is called before the first frame update
    void Start()
    {
        breakingSound = GameObject.FindWithTag("BreakingMeteor");
        breakingSoundAudio = breakingSound.GetComponent<AudioSource>();
        meteorDestroyed = GameObject.FindWithTag("ShatteredMeteor");
        meteorDestroyedAudio= meteorDestroyed.GetComponent<AudioSource>();
        score = GameObject.FindWithTag("Score");
        score_Manager = score.GetComponent<Score_Manager>();
        Destroy(gameObject, 2f);
        int choice = Random.Range(1, 4);
        hp = 2;
        ori_size = transform.localScale;
        if (choice == 1)
        {
            transform.localScale = ori_size * 0.5f ;
            gameObject.tag = "meteor1"; hp = 1;
        }
        else if(choice == 3)
        {
            transform.localScale = ori_size * 1.5f;
            gameObject.tag = "meteor3"; hp = 3;
        }
        else { gameObject.tag = "meteor2"; }
        scale = transform.localScale.x/ori_size.x ;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp == 0)
        {
            meteorDestroyedAudio.Play();
            if (gameObject.tag.Equals("meteor1"))
            {
                score_Manager.AddScore(100);
            }
            if (gameObject.tag.Equals("meteor2"))
            {
                score_Manager.AddScore(200);
            }
            if (gameObject.tag.Equals("meteor3"))
            {
                score_Manager.AddScore(500);
            }
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            breakingSoundAudio.Play();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            hp -= 1;
        }
        if (collision.gameObject.CompareTag("EnemyShip1"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyShip2"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyShip3"))
        {
            Destroy(gameObject);
        }
    }
    public float getScale()
    {
        return scale;
    }
}
