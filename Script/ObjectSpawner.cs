using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject _prefabObjectSpawn;
    public float _spawnInterval;
    private float _timer;
    public  float MinX, MaxX, MinY, MaxY;
    public Vector3 rotation = new Vector3(0,179,0);


     private void Start() {
        // transform.Rotate(rotation);    
    }



    private void Update(){
        _timer += Time.deltaTime;

        if(_timer > _spawnInterval){
            
            float randomX = Random.Range(MinX, MaxX);
            float randomY = Random.Range(MinY, MaxY);

             Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);


            GameObject prefabObject = Instantiate(_prefabObjectSpawn, spawnPosition ,Quaternion.identity);

            prefabObject.transform.Rotate(rotation);

            _timer = 0;
        }


    }
}
