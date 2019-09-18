using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Began");
        if (other.tag == "Player")
        {
            //other.GetComponent<Player>().Eat();
            Debug.Log(other);
            other.gameObject.GetComponent<Player>().Eat();
        }
    }
}
