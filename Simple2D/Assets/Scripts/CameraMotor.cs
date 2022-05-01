using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform lookAt;
    public float boundX = 1f;
    public float boundY = .5f;
    
    private void LateUpdate(){
        Vector3 delta = Vector3.zero;

        //Check if we are in X axis bounds
        float deltaX = lookAt.position.x - transform.position.x;
        if (deltaX > boundX || deltaX < -boundX){
            if(transform.position.x < lookAt.position.x){
                delta.x = deltaX - boundX;
            } else{
                delta.x = deltaX + boundX;
            }
        }

        //Check if we are in Y axis bounds
        float deltaY = lookAt.position.y - transform.position.y;
        if (deltaY > boundY || deltaY < -boundY){
            if(transform.position.y < lookAt.position.y){
                delta.y = deltaY - boundY;
            } else{
                delta.y = deltaY + boundY;
            }
        }

        transform.position += new Vector3(delta.x, delta.y, 0);

    }
}
