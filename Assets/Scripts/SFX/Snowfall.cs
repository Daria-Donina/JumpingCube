using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowfall : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private float _height;

    private void FixedUpdate() {
        Vector3 newPosition = _player.transform.position;
        newPosition.y = _height;
        transform.position = newPosition;
    }
}   
