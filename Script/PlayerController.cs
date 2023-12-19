using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public UIManager _uiManager;
    private Rigidbody2D _rb;
    public float _moveSpeed = 5;
    public GameObject _prefabs;
    public float _flingForce = 100;
    public int _score;
    private int _hp = 3;




  public  void Awake(){
      _rb = GetComponent<Rigidbody2D>();
      _uiManager = FindObjectOfType<UIManager>();

  }


   public  void Update() {
    if(Input.GetKeyDown(KeyCode.Space)){
      Shoot();
    }
    _uiManager.SetScore(_score);
  }    

  

  void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
         float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3 (horizontalInput,verticalInput,0);
        Vector3 playerMove = transform.position + moveInput * Time.deltaTime * _moveSpeed;

        _rb.MovePosition(playerMove);
    }

    public void Shoot(){
      //Spawn The Bullet
      Vector3 spwanBullet = transform.position + new Vector3(0, 0.9f,0);
      //Spwan Object
      GameObject prefabs = Instantiate(_prefabs, spwanBullet, Quaternion.identity);
      //get rigidBody of Object to spwan
      Rigidbody2D prefabsRb = prefabs.GetComponent<Rigidbody2D>();
      //add force the object spwan
      prefabsRb.AddForce(new Vector2 (0, _flingForce));
    }

    void OnTriggerEnter2D (Collider2D collision){
      GameObject Colide = collision.gameObject;
      if(Colide.tag =="Enemy" || Colide.tag == "EnemyBullet"){
        Destroy(Colide.gameObject);
        ReciveDmg();
      } 
    }
    private void ReciveDmg(){
      _hp --;
      _uiManager.SetHp(_hp);
      if(_hp <= 0){
        Destroy(gameObject);
        _uiManager.ShowLoseScreen(_score);
      }


    }

}
