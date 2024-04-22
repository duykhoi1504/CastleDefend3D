using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    // Start is called before the first frame update
    // [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projecttileParticles;
    [SerializeField] float range= 15f;
    Transform target;

    // Update is called once per frame
    void Update()
    {
        FindClosetTarget();
    //   if (target == null) return;
        AimTower();
        
     
    }
    void FindClosetTarget(){
        Enemy[] enemys=FindObjectsOfType<Enemy>();
        Transform closetTarget=null;
        float maxDistance=Mathf.Infinity;
        foreach(Enemy enemy in enemys)
        {
            float targetDisatance=Vector3.Distance(transform.position,enemy.transform.position);
            if(targetDisatance < maxDistance){
                closetTarget=enemy.transform;
                maxDistance=targetDisatance;
            }
            target=closetTarget;
        }
        
    }
    void AimTower()
    {
        // Debug.DrawRay(this.transform.position, dir, Color.red);
        float targetDistance = Vector3.Distance(this.transform.position, target.position);
        transform.LookAt(target.position);
        if(targetDistance<range){
            Attack(true);
        }else{
            Attack(false);
        }
    }

    void Attack(bool isActive){
        var emissionModule= projecttileParticles.emission;
        emissionModule.enabled=isActive;
    }
  
}
