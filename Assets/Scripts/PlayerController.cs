using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;

    private Rigidbody playerBody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        playerBody = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void MovePlayer (Vector2 dir) 
    {
        //Debug.Log("Moving " + dir);
        Vector3 moveDir = new Vector3(dir.x, 0, dir.y);
        playerBody.AddForce(speed * moveDir);
    }
}
