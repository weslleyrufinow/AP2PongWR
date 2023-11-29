using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10;
    private GameManager gameManager;

    public bool isRight;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnReset += ResetHandler;
    }

    void ResetHandler(){
        if(isRight){
            transform.position = new Vector3(8.5f, 0f, 0f);
        }else{
            transform.position = new Vector3(-8.5f, 0f, 0f);
        }
        //transform.position = new Vector3(8.5f, 0.0f, 0.0f);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameManager.State == GameState.playing){
            var f = 0.0f;
            if(isRight){
                f = Input.GetAxisRaw("Vertical");
            }else{
                f = Input.GetAxisRaw("Vertical2");
            }
            //System.Single f = Input.GetAxisRaw("Vertical");

            if((f > 0 && transform.position.y + 1.5f < 4.75)||
            (f < 0 && transform.position.y - 1.5f > -4.75)){
                transform.Translate(0, f * speed * 0.001f, 0);
            }
        }


        
    }
}
