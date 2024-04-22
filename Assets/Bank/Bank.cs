using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bank : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int startingBalance=150;
    [SerializeField] int currentBalance;
    public int CunrentBalance{get{return currentBalance;}}
     void Awake() {
        currentBalance=startingBalance;    
    }
    public void Deposit(int amount){
        currentBalance+=Mathf.Abs(amount);
    }
    public void WithDraw(int amount){
        currentBalance-=Mathf.Abs(amount);
        if(currentBalance < 0){
                ReloadScene();
        }
    }

    void ReloadScene(){
        Scene currentScene= SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
