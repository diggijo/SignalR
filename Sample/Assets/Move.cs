using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float timer;
    float second = 1f;
    int totalTime;

    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= second)
        {
            timer = 0;
            totalTime++;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * moveSpeed;

        rb.velocity = movement;
    }

    void OnGUI()
    {
        // Set the position and size of the GUI label
        Rect rect = new Rect(Screen.width - 150f, 10f, 140f, 30f);

        // Display the timer value using GUI.Label
        GUI.Label(rect, "Timer: " + totalTime);
    }
}
