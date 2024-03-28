using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolHit : MonoBehaviour
{
    public GameObject tower;
    int hitValue = 50;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject != null && this.gameObject.tag == "bullet" && other.gameObject.tag == "Player2Monster")
        {
            other.gameObject.GetComponent<Monster>().setLife(other.gameObject.GetComponent<Monster>().getLife() - hitValue);
        }
    }
}
