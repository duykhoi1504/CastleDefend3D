using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int EnemyHP;
    [SerializeField] int cunrentHitHP;
    void OnEnable()
    {
        cunrentHitHP=EnemyHP;
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }
    void ProcessHit(){
        cunrentHitHP--;
        if(cunrentHitHP <= 0){
            // Destroy(this.gameObject);
            gameObject.SetActive(false);
        }
    }
}
