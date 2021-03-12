using UnityEngine;

public class DeepPlaneScript : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        var gameObject = collision.gameObject;

        gameObject.transform.position = Player.SpawnPosition;
    }
}
