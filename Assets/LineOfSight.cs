using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Colisionnnn");
        // Debug.Log(other);
        if (other.gameObject.tag == "Player"){
            GetComponentInParent<EnemyScript>().player = other.gameObject;
        }
    }
}
