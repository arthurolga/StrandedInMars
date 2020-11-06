using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed=5f;
    public GameObject bulletExplosion;
    public int damage=1;

    float lifeTime = 50f;
    Rigidbody rb;

    //Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        //m_Renderer = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }
        

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up*moveSpeed;

        lifeTime -= Time.deltaTime;

        if(lifeTime <= 0){
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Colisionnnn");
        // Debug.Log(other);
        if (other.gameObject.tag == "Enemy"){
            other.GetComponent<EnemyScript>().TakeDamage(damage);
            //Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "FakeDoor"){
            Destroy(other.gameObject);
        }

        if(!(other.gameObject.tag == "EnemyLineOfSight")){
            Destroy(gameObject);
            Instantiate(bulletExplosion,transform.position,transform.rotation);
        }


        
        
    }
}

