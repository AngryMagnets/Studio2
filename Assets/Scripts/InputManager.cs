using System;
using UnityEngine.Events;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public UnityEvent OnSpacePressed = new UnityEvent();
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { OnSpacePressed?.Invoke(); }

        Vector2 ballPos = Vector2.zero;
        if (Input.GetKey(KeyCode.A)) { ballPos += Vector2.left; }
        if (Input.GetKey(KeyCode.D)) { ballPos += Vector2.right; }
        OnMove?.Invoke(ballPos);
    }
 }