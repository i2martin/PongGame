using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxSpeed;
    int hitCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
    }
    
    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        if (isStartingPlayer1 )
        {
            this.gameObject.transform.position = new Vector3(-100,0,1);
        }
        else
        {
            this.gameObject.transform.position = new Vector3(100, 0, 1);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);
        this.hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (isStartingPlayer1)
            this.MoveBall(new Vector2(-1, 0));
        else
            this.MoveBall(new Vector2(1,0));
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float speed = this.movementSpeed + this.extraSpeedPerHit * this.hitCounter;
        Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction * speed;

    }

    public void IncreaseHitCounter()
    {
        if (this.hitCounter * this.extraSpeedPerHit <= this.hitCounter * this.maxSpeed)
        {
            this.hitCounter++;

        }
    }

}
