using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource wallSound;
    public AudioSource racketSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            racketSound.Play();
        }
        else if (collision.gameObject.name == "WallLeft" || collision.gameObject.name == "WallRight" || collision.gameObject.name == "WallTop" || collision.gameObject.name == "WallBottom")
        {
            wallSound.Play();
        }
    }
}
