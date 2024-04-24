using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0,50f)]int poolSize = 5;
    [SerializeField][Range(0.1f,30f)]float spawnTimer = 1f;
    GameObject[] pool;
    private void Awake()
    {
        PopularPool();
    }
    void Start()
    {

        StartCoroutine(SpawnEnemy());
    }

    void PopularPool()
    {
        pool = new GameObject[poolSize];
        for (int i=0;i<pool.Length;i++)
        {
            pool[i] = Instantiate(enemyPrefab,transform);
            pool[i].SetActive(false);
        }

    }

    void EnableObjectInPool(){
        for (int i=0;i<pool.Length;i++){
            if(pool[i].activeInHierarchy==false){
                pool[i].SetActive(true);
                return;
            }
        }
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool(); 
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
