using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fruit : MonoBehaviour
{
    public Sprite sprite;
    public GameObject fruit;
    public GameObject nextFruit;
    public Color fruitColor;
    public Vector3 fruitScale;
    public int points;

    public bool inPlay = false;
    public static bool canEvolve = true;
    public static int fruitLimit = 0;

    void OnCollisionEnter2D(Collision2D fruitTouched)
    {
        if(fruit.tag == fruitTouched.gameObject.tag)
        {
            
            Destroy(fruit);
            if(canEvolve == true)
            {
                Instantiate(nextFruit, new Vector3((fruit.transform.position.x + fruitTouched.transform.position.x)/2, (fruit.transform.position.y + fruitTouched.transform.position.y)/2, 0), Quaternion.identity, this.transform.parent);
                canEvolve = false;
                Score.instance.AddPoints(points);
            }
            else
            {
                canEvolve = true;
            }
        }
        if(!inPlay)
        {
            inPlay = true;
        }
        
    }
}
