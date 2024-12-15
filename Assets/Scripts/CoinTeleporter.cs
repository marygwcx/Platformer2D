using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinTeleporter : MonoBehaviour
{
    public GameObject player;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
