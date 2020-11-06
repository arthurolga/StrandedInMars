using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed=2f;
    public int totalHealth=10;
    
    public GameObject player;
    public GameObject enemyExplosion;
    
    Rigidbody rb;
    private bool chasing;
    //public float distanceToChase= 10f, distanceToLose=15f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player){
            Vector3 direction = player.transform.position - transform.position;
            direction.Normalize();
            transform.LookAt(player.transform.position);
            transform.Rotate(-100.0f, 0.0f, 0.0f, Space.Self);
            rb.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }

    public void TakeDamage(int dmg){
        totalHealth -= dmg;
        if(totalHealth <= 0){
            SFXManagerScript.PlaySound("zombieDeath");
            Destroy(gameObject);
            Instantiate(enemyExplosion,transform.position,transform.rotation);
        }

    }
    
}
