using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdControl : MonoBehaviour
{
    [SerializeField]
    public Text scoreText;

    public static BirdControl instance;
    public float bounceFore;
    private Rigidbody2D myBody;
    private bool isActivateBird = false;
    private bool touchedBird = false;
    public bool endGameFlag = false;
    private GameObject createPipe;
    private int mScore = 0;

    // Start is called before the first frame update
    void Awake()
    {
        isActivateBird = true;
        myBody = GetComponent<Rigidbody2D>();
        MakeInstance();
        createPipe = GameObject.Find("CreatePipe");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(endGameFlag == false){
            BirdMovement();
        }
    }

    void MakeInstance(){
        if(instance == null){
            instance = this;
        }
    }

    void BirdMovement(){

        if(isActivateBird == true && touchedBird == true ){
            touchedBird = false;
            myBody.velocity = new Vector2(myBody.velocity.x, bounceFore);
        }

        if(myBody.velocity.y > 0){
            float angle = 0;
            angle = Mathf.Lerp(0, 90, myBody.velocity.y/8);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        } else if(myBody.velocity.y < 0){
            float angle = 0;
            angle = Mathf.Lerp(0, -90, -myBody.velocity.y/8);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        } else {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void ButtonBird(){
        touchedBird = true;
    }

     void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "pipeHolder"){
            mScore++;
            scoreText.text = "" + mScore;
        }
    }

    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag == "ground" || target.gameObject.tag == "pipe" ){
            // End Game
            endGameFlag = true;
            Destroy(createPipe);
        }
    }
}
