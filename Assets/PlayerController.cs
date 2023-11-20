using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            gameManager.SetCommand(CommandType.reset);
        } else if (Input.GetKey(KeyCode.Space))
        {
            gameManager.SetCommand(CommandType.play);
        }
    }
}
