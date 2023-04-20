using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ship_Generator : MonoBehaviour
{
    public GameObject EnemyShip;
    public float time_interval = 8f;
    float height; //width;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Play();
    }
    void Awake()
    {
        Vector3 screenWorld = new Vector3(Screen.width, Screen.height, 0);
        screenWorld = Camera.main.ScreenToWorldPoint(screenWorld);
        height = screenWorld.y * 2;
        //width = screenWorld.x;
    }
    IEnumerator spawn(Sprite meteor, float minsec, float maxsec)
    {
        while (true)
        {
            GameObject m = GameObject.Instantiate(EnemyShip);
            m.transform.position = new Vector3(Player.transform.position.x, height, 0);
            yield return new WaitForSeconds(Random.Range(minsec, maxsec));
        }
    }

    public void Pause()
    {
        StopAllCoroutines();

    }

    public void Play()
    {
        StartCoroutine(playAll());
    }
    private IEnumerator playAll()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(spawn(EnemyShip.GetComponent<SpriteRenderer>().sprite, time_interval, time_interval * 2));
        yield return new WaitForSeconds(1);
    }
    // Update is called once per frame
    void Update()
    {

    }

}
