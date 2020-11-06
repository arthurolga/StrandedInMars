using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollider : MonoBehaviour
{
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with smth");
        Debug.Log(other.gameObject);
        if (other.gameObject.tag == "Enemy"){
            
            GetComponentInParent<PlayerController>().TakeDamage(25);
        } 
        else if (other.gameObject.tag == "MinigunPickup"){
            
            GetComponentInParent<PlayerController>().ActivateMinigun();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Portal"){
            gameManager.GetComponent<GameManagerScript>().SetTimeScore();
            // .GetComponent<EnemyScript>().TakeDamage(damage);
            SceneManager.LoadScene("WinGame");
        }
    }
}
