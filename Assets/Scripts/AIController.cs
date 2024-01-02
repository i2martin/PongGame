using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public enum AIDifficulty
    {
        Easy,
        Normal,
        Hard
    }
    public GameObject ball;
    public bool isAIEnabled;
    public AIDifficulty difficulty;
    private int movementSpeed = 200;

    // Start is called before the first frame update
    void Start()
    {
        //adjust movement speed if Player2 is played by computer
        if (isAIEnabled)
        {
            switch (difficulty)
            {
                case AIDifficulty.Easy:
                    movementSpeed = 100;
                    break;
                case AIDifficulty.Normal:
                    movementSpeed = 200;
                    break;
                case AIDifficulty.Hard:
                    movementSpeed = 300;
                    break;
            }
        }
    }

    void FixedUpdate()
    {
        if (isAIEnabled)
        {
            if (Mathf.Abs(this.transform.position.y - this.ball.transform.position.y) > 50)
            {
                if (this.transform.position.y < this.ball.transform.position.y)
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * movementSpeed;
                else
                    this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * movementSpeed;
            }
            else
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);         
        }
        else //if not played by computer, use vertical axis (player controlled - up and down arrows)
        {
            float v = Input.GetAxisRaw("Vertical2");

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * movementSpeed;
        }
    }
}
