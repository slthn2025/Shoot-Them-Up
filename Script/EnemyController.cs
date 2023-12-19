using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float _filingCooldown = 2;
    public float _bulletForce = -500;
    private float _flingTimer; 
    public GameObject _prefabs;
    public float rotation = 179;

    public void Awake() {
        _flingTimer = _filingCooldown;
    }


     public void Update() {
        _flingTimer += Time.deltaTime;

        if(_flingTimer > _filingCooldown){
            shoot();
        }
        
    }
    public void shoot(){
        _flingTimer = 0;

        Vector3 spwanBullet = transform.position +  new Vector3(0, -0.9f,0);

        GameObject prefab = Instantiate(_prefabs, spwanBullet, Quaternion.identity);

        Rigidbody2D prefabRb = prefab.GetComponent<Rigidbody2D>();

        prefabRb.AddForce(new Vector2(0,-_bulletForce));

        prefab.transform.Rotate(Vector3.forward * rotation);
    }



    void OnTriggerEnter2D(Collider2D collision){
        GameObject otherGO = collision.gameObject;
        if(otherGO.tag == "Ground" || otherGO.tag == "Bullet"){
            Destroy(gameObject);
        }
    }
}
