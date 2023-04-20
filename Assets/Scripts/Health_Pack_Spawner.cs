using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Pack_Spawner : MonoBehaviour
{
    public GameObject Health_Pack;

    float height, width;


    private void Start()
    {
        Play();
    }
    void Awake()
    {
        Vector3 screenWorld = new Vector3(Screen.width, Screen.height, 0);
        screenWorld = Camera.main.ScreenToWorldPoint(screenWorld);
        height = screenWorld.y * 2;
        width = screenWorld.x;
    }
    IEnumerator spawn(Sprite health, float minsec, float maxsec)
    {
        while (true)
        {
            GameObject h = GameObject.Instantiate(Health_Pack);
            h.transform.position = new Vector3(Random.Range(-width, width), height, 0);
            h.GetComponent<SpriteRenderer>().sprite = health;
            h.tag = health.name;
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
        float time_interval = 5;
        yield return new WaitForSeconds(1);
            StartCoroutine(spawn(Health_Pack.GetComponent<SpriteRenderer>().sprite, time_interval , time_interval * 2));
            yield return new WaitForSeconds(1);
    }

}
