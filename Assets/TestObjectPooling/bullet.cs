using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    [SerializeField] float speed=300f;
    void Start()
    {
         target = FindObjectOfType<EnemyMover>().transform;
        Invoke("DestroyBullet",2.0f);
    }
    private void Update() {
        this.transform.LookAt(target.position);
        this.transform.position = Vector3.MoveTowards(this.transform.parent.position, target.transform.position, speed*Time.deltaTime);
    }

    // Update is called once per frame
    void DestroyBullet(){
        gameObject.SetActive(false);
        Debug.Log("huy bullet");
    }
}
