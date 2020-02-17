using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour{

    public Transform target;
    public Vector2 maxLimit;
    public Vector2 minLimit;



    void Start(){
        
    }


    void Update(){
        if(target != null){
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minLimit.x, maxLimit.x),
                Mathf.Clamp(transform.position.y, minLimit.y, maxLimit.y),
                transform.position.z
            );

        }
        
    }
}
