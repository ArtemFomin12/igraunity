using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
	public Transform Player;
  public NavMeshAgent Enemy;
  static int score = 0;
  public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Enemy.SetDestination(Player.transform.position); 
    }

    void OnCollisionEnter(Collision collision) {
      if(collision.gameObject.tag == "Bullet"){
        score = score + 1;
        text.text = "SCORE:" + score.ToString();
      	Destroy(gameObject);
        
        if(score >= 6){
          score = 0;
          SceneManager.LoadScene(0);
        }
	}
	}
}
