using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int EnemyHP;
    int cunrentHitHP;

    [Tooltip("Adds amount to EnemyHP when thay dies.")]
    [SerializeField] int difficultyRamp = 1;
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
            EnemyHP += difficultyRamp;
            // Destroy(this.gameObject);
            gameObject.SetActive(false);
            enemy.RewardGold();
        }
    }
}
