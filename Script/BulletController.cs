using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private PlayerController _player;

    private void Awake() {
        _player = FindObjectOfType<PlayerController>();    
    }


    void OnTriggerEnter2D(Collider2D collision){
        GameObject otherGO = collision.gameObject;
        if(otherGO.tag == "Ground"|| otherGO.tag == "Top"){
            Destroy(gameObject);
        }
        if( otherGO.tag == "Enemy"){
            Destroy(gameObject);
            _player._score++;
        }
    }
}
