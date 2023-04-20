using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteors_Generator : MonoBehaviour
{

    public GameObject Meteor1;
    public float time_interval = 1;
    float height, width;
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
        width = screenWorld.x;
    }
    IEnumerator spawn(Sprite meteor, float minsec, float maxsec)
    {
        while (true)
        {
            GameObject m = GameObject.Instantiate(Meteor1);
            m.transform.position = new Vector3(Random.Range(-width, width), height, 0);
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
        StartCoroutine(spawn(Meteor1.GetComponent<SpriteRenderer>().sprite, time_interval, time_interval * 2));
        yield return new WaitForSeconds(1);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
