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
    readonly int heightY = 7;
    int posX;

    int performanceOn;
    public void SpawnNext()
    {
        posX = Random.Range(-9, 9);
        randomTransform.position = new Vector2(posX, heightY);
        int rand = Random.Range(0, objects.Length);

        todelete  = Instantiate(objects[rand], randomTransform.position, Quaternion.identity);
        todelete.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        foreach (Transform child in todelete.transform)
        {
            child.GetComponent<SpriteRenderer>().color = ColorSystem.GetColor();
        }
        todelete.GetComponent<PolygonCollider2D>().enabled = true;
        todelete.AddComponent<Rigidbody2D>();
        todelete.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Destroy(todelete, DestroyPeriod);
    }

    void Update()
    {
        if(performanceOn != 1)
        {
            time += Time.deltaTime;

            if (time >= WaitPeriod)
            {
                time = time - WaitPeriod;

                SpawnNext();
            }
        }

    }
    private void Start()
    {
        performanceOn = PlayerPrefs.GetInt("PerformanceOn");
    }
}
