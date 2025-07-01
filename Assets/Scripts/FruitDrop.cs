using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDrop : MonoBehaviour
{
    public GameObject dropper;
    public GameObject fakeFruit;
    public GameObject parentObject;
    public GameObject nextFruitParentObject;

    public List<GameObject> fruits = new List<GameObject>();
    public List<Sprite> fruitPNGs = new List<Sprite>();

    private GameObject fruit;
    private GameObject nextFruit;
    private GameObject fruitSpawned;
    private GameObject nextFruitSpawned;
    private Fruit fruitDetails;
    private Fruit fruitDropped;

    public bool holdingFruit;

    void Start()
    {
        nextFruit = NextFruit();
        SwapFruits();
        holdingFruit = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(!holdingFruit)
        {
            SwapFruits();
            holdingFruit = true;
            Debug.Log("Fruit spawned");
        }
        else
        {       
            if(Input.GetKeyDown(KeyCode.Space) && fakeFruit.GetComponent<Renderer>().enabled == true)
            {
                fruitSpawned = Instantiate(fruit, new Vector2(dropper.transform.position.x, dropper.transform.position.y-0.25f), Quaternion.identity, parentObject.transform);
                fruitDropped = fruitSpawned.GetComponent<Fruit>();
                fakeFruit.GetComponent<Renderer>().enabled = false;
            }
            if(fruitDropped.inPlay)
            {
                holdingFruit = false;
            }
        }
    }

    GameObject NextFruit()
    {
        return(fruits[Random.Range(0, fruits.Count)]);
    }

    void SwapFruits()
    {
        if(nextFruitSpawned != null)
        {
            Destroy(nextFruitSpawned);
        }
        fruit = nextFruit;
        HoldFruit(fruit);
        nextFruit = NextFruit();
        nextFruitSpawned = Instantiate(nextFruit, new Vector2(nextFruitParentObject.transform.position.x, nextFruitParentObject.transform.position.y), Quaternion.identity, nextFruitParentObject.transform);

        nextFruitSpawned.GetComponent<Rigidbody2D>().gravityScale = 0;
    }

    void HoldFruit(GameObject heldFruit)
    {
        fruitDetails = heldFruit.GetComponent<Fruit>();
        fruitDropped = fruitDetails;
        fakeFruit.GetComponent<SpriteRenderer>().sprite = fruitDetails.sprite;
        fakeFruit.GetComponent<Renderer>().enabled = true;
    }
}
