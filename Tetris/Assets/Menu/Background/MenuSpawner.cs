using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpawner : MonoBehaviour
{
    private float time = 0.0f;
    public float WaitPeriod;
    public int DestroyPeriod;

    public GameObject parent;
    public GameObject[] objects;
    public Transform randomTransform;
    private GameObject todelete;
    int heightY = 7;
    int posX;
    public void SpawnNext()
    {
        posX = Random.Range(-9, 9);
        randomTransform.position = new Vector2(posX, heightY);
        int rand = Random.Range(0, objects.Length);

        todelete  = Instantiate(objects[rand], randomTransform.position, Quaternion.identity);
        todelete.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        todelete.GetComponent<PolygonCollider2D>().enabled = true;
        todelete.AddComponent<Rigidbody2D>();
        Destroy(todelete, DestroyPeriod);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= WaitPeriod)
        {
            time = time - WaitPeriod;

            SpawnNext();

        }
    }
}
