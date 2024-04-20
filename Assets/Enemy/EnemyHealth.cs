using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int EnemyHP;
    [SerializeField] int cunrentHP;
    void Start()
    {
        cunrentHP=EnemyHP;
    }

    private void OnParticleCollision(GameObject other) {
        ProcessHit();
    }
    void ProcessHit(){
        cunrentHP--;
        if(cunrentHP <= 0){
            Destroy(this.gameObject);
        }
    }
}
