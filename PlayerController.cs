using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	Rigidbody rb;
	Rigidbody rbClone;
  public GameObject bullet;
  GameObject bulletClone;
  public int hp = 100;
  public Text text;

    // Start is called before the first frame update
    void Start()
    {	
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      float moveVertical = Input.GetAxis("Vertical");
      rb.AddForce(transform.forward * moveVertical * 100f);

      float moveHorizontal = Input.GetAxis("Horizontal");
      transform.Rotate(0, moveHorizontal * 10f, 0);

      if(Input.GetKeyDown("space")) {
        bulletClone = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Quaternion.identity);
        rbClone = bulletClone.GetComponent<Rigidbody>();
        rbClone.AddForce(transform.forward * 400f);
      }
    }

    void OnCollisionEnter(Collision collision) {
      if(collision.gameObject.tag == "Enemy"){
        hp = hp - 1;
        text.text = "HP:" + hp.ToString();

        if(hp <= 0){
          SceneManager.LoadScene(1);
          hp = 100;
        }
   		}
	  }
}
