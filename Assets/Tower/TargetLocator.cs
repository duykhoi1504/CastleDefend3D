using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
      if (target == null)return;
        AimTower();
        
     
    }
    void AimTower()
    {
        Vector3 dir = target.transform.position - this.transform.position;
        // dir.Normalize();
        Debug.DrawRay(this.transform.position, dir, Color.red);
        float Distance = Vector3.Distance(this.transform.position, target.transform.position);
        transform.LookAt(target.position);

    }
  
}
