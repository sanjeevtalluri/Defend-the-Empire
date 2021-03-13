using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private float waitTime=1f;

    [SerializeField]
    private int poolSize = 10;

    private GameObject[] pool;

    private void Awake()
    {
        CreateAndPopulatePool();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            GetNextPooledObject();
            yield return new WaitForSeconds(waitTime);
        }
    }
    void CreateAndPopulatePool()
    {
        pool = new GameObject[poolSize];
        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void GetNextPooledObject()
    {
        foreach(GameObject pooledObject in pool)
        {
            if (!pooledObject.activeInHierarchy)
            {
                pooledObject.SetActive(true);
                return;
            }
        }
    }
}
