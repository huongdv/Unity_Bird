using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{
    public float pipe_speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( BirdControl.instance != null && BirdControl.instance.endGameFlag == false){
            PipeMovement();
        } else {
            Destroy (GetComponent<PipeHolder> ());
        }
    }

    void PipeMovement(){
        Vector3 temp = transform.position;
        temp.x -= pipe_speed * Time.deltaTime;
        transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "removePipe"){
            Destroy(gameObject);
        }
    }
}
