using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.75f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("meteor1"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("meteor2"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("meteor3"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyShip"))
        {
            Destroy(gameObject);
        }
    }

}
