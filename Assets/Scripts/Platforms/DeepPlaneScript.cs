using System;
using UnityEngine;

public class DeepPlaneScript : MonoBehaviour
{
    public static event EventHandler PlayerRespawned;

    [SerializeField]
    private GameObject playerObj;
    private Player player;

	private void Start()
	{
        player = playerObj.GetComponent<Player>();
	}

	void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            // Notify all subscribers about player respawn
            PlayerRespawned?.Invoke(this, EventArgs.Empty);

            var gameObject = collision.gameObject;
            gameObject.transform.position = player.SpawnPosition;
        }        
    }
}
