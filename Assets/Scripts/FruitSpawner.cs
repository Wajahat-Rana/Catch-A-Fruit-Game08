using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{   
    [SerializeField]
    private GameObject [] fruits;
    private BoxCollider2D spawner;

    float leftCorner;
    float rightCorner;
    void Awake()
    {
        spawner = GetComponent<BoxCollider2D>();
        leftCorner = transform.position.x - spawner.bounds.size.x / 2f;
        rightCorner = transform.position.x + spawner.bounds.size.x / 2f;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits(1f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnFruits(float time){
        yield return new WaitForSecondsRealtime (time);

        Vector3 temp = transform.position;
        temp.x = Random.Range(leftCorner,rightCorner);

        Instantiate(fruits[Random.Range(0,fruits.Length)],temp,Quaternion.identity);
        StartCoroutine(SpawnFruits(Random.Range(1f, 2f)));
    }
}
