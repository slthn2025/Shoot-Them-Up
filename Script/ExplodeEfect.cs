using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeEfect : MonoBehaviour
{
    public GameObject _prefabObjectSpawn;
   
    private void Update(){
            GameObject prefabObject = Instantiate(_prefabObjectSpawn, transform.position,Quaternion.identity);
   
        }
    }
