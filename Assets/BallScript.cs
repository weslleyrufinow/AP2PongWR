using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float speed = 10;
    private Rigidbody rb;
    private Vector3 right = Vector3.right;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.OnReset += ResetHandle;
        gameManager.OnPlay += PlayHandler;
    }


    void PlayHandler()
    {
        var angle = Random.Range(-45.0f, 45.0f);
        var dir = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)) * right;

        rb = GetComponent<Rigidbody>();
        rb.AddForce(dir * speed, ForceMode.VelocityChange);
    }


    void ResetHandle()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
