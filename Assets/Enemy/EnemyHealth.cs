using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int EnemyHP;
    [SerializeField] int cunrentHitHP;
    Enemy enemy;
    void OnEnable()
    {
        cunrentHitHP = EnemyHP;
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        cunrentHitHP--;
        if (cunrentHitHP <= 0)
        {
            
            // Destroy(this.gameObject);
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
