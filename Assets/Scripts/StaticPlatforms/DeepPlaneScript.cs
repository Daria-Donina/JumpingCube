using System;
using UnityEngine;

public class DeepPlaneScript : MonoBehaviour
{
	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            Player player = collision.gameObject.GetComponent<Player>();

            player.Respawn();
        }        
    }
}
