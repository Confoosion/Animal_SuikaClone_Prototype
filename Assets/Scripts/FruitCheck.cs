using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCheck : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D fruit)
    {
        Fruit fruitFalling = fruit.GetComponent<Fruit>();
        if(fruitFalling.inPlay)
        {
            Debug.Log("You Lost");
            Score.instance.EndingScore();
            Time.timeScale = 0;
        }
        else
            Debug.Log("Fruit falling");
    }
}
