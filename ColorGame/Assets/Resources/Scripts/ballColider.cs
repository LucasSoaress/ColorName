using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ballColider : MonoBehaviour 
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "barra" || coll.gameObject.tag != this.gameObject.tag)
        {
            ballsSpawn.erros -= 1;
            ballsSpawn.pontos -= 5;
            Destroy(gameObject);
        }

        if (coll.gameObject.tag == this.gameObject.tag)
        {
            ballsSpawn.pontos += 10;
            Destroy(gameObject);
        }

        
    }
}
