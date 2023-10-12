using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class KeyBoolPairs
{
    public int keyNumber;
    public bool found;
}

public class KeyLocation : MonoBehaviour
{
    public Dictionary<int, Keys> keyDict = new Dictionary<int, Keys>();

    public GameObject[] keyObject;
    public bool[] keyFound;
    public CanvasVisibilityController[] canvasController; // Reference to the CanvasVisibilityController script attached to this GameObject

    public int ID;
    public Vector3 randomFirePosition;
    public Vector3 randomWaterPosition;
    public Vector3 randomSunPosition;

    public void Start()
    {
        RandomizeFireKeyPosition();
        Vector3 randomWaterPosition = new Vector3(Random.Range(67.924f, 125.4f), 2.11f, Random.Range(11.3f, 113.6f));
        Vector3 randomSunPosition = new Vector3(Random.Range(-30.924f, -70.4f), 2.11f, Random.Range(30.3f, 40f));
        RandomizeKey(0, randomFirePosition, keyObject[0]);
        RandomizeKey(1, randomWaterPosition, keyObject[1]);
        RandomizeKey(2, randomSunPosition, keyObject[2]);

    }

    public Vector3 RandomizeFireKeyPosition()
    {
        int keyRandomisedLocation = Random.Range(1, 4);
        Vector3 mazeTent = new Vector3(-114.7f, 2.11f, -11.3f);
        Vector3 mazeBuilding = new Vector3(-67.924f, 2.324f, -98.66f);
        Vector3 mazeGreenhouse = new Vector3(-125.4f, 2.11f, -113.6f);

        if (keyRandomisedLocation == 1)
        {
            randomFirePosition = mazeTent;
        }
        else if (keyRandomisedLocation == 2)
        {
            randomFirePosition = mazeBuilding;
        }
        else if (keyRandomisedLocation == 3)
        {
            randomFirePosition = mazeGreenhouse;
        }
        return randomFirePosition;
        
    }
    public Vector3 RandomizeWaterKeyPosition()
    {
        int keyRandomisedLocation = Random.Range(1, 6);
        Vector3 water1 = new Vector3(46f, 8f, 58f);
        Vector3 water2 = new Vector3(80f, 2.324f, 123);
        Vector3 water3 = new Vector3(16f, 2.11f, 118f);
        Vector3 water4 = new Vector3(-14, 2.11f, 104f);
        Vector3 water5 = new Vector3(-7.9f, 2.11f, 129f);

        if (keyRandomisedLocation == 1)
        {
            randomWaterPosition = water1;
        }
        else if (keyRandomisedLocation == 2)
        {
            randomWaterPosition = water2;
        }
        else if (keyRandomisedLocation == 3)
        {
            randomWaterPosition = water3;
        }
        else if (keyRandomisedLocation == 4)
        {
            randomWaterPosition = water4;
        }
        else if (keyRandomisedLocation == 5)
        {
            randomWaterPosition = water5;
        }
        return randomWaterPosition;
    }

    public Vector3 RandomizeSunKeyPosition()
    {
        int keyRandomisedLocation = Random.Range(1, 5);
        Vector3 sun1 = new Vector3(-69.5f, 2.11f, 80f);
        Vector3 sun2 = new Vector3(-31f, 2.324f, 54f);
        Vector3 sun3 = new Vector3(-29f, 2.11f, 22);
        Vector3 sun4 = new Vector3(34.4f, 2.11f, 11.9f);

        if (keyRandomisedLocation == 1)
        {
            randomSunPosition = sun1;
        }
        else if (keyRandomisedLocation == 2)
        {
            randomSunPosition = sun2;
        }
        else if (keyRandomisedLocation == 3)
        {
            randomSunPosition = sun3;
        }
        else if (keyRandomisedLocation == 4)
        {
            randomSunPosition = sun4;
        }
        return randomSunPosition;

    }

    /*public void KeyFound (Keys numberofKey)
 {

     if(keyDict.ContainsKey(numberofKey.ID))
     {
         keyDict[numberofKey.ID].found = true;
     }
     else
     {
         keyDict.Add(numberofKey.ID, numberofKey);
     }
 }
    */


    public void KeyFound(Keys numberofKey)
    {
        if (keyDict.ContainsKey(numberofKey.ID))
        {
            keyDict[numberofKey.ID].found = true;
            Debug.Log("Key " + numberofKey.ID + " found!");
            keyFound[ID] = true;
            // Set the canvas image to visible when a key is found
            canvasController[ID].ToggleImageVisibility();
        }
    }

    public void RandomizeKey(int id, Vector3 position, GameObject key)
    {
        GameObject keyInstance = Instantiate(keyObject[id], position, transform.rotation);
        Keys keyScript = keyInstance.GetComponent<Keys>();
        keyScript.ID = id;
        keyDict.Add(keyScript.ID, keyScript);
    }
}
 /*public void RandomizeKeys()
 {
     int keyRandomisedLocation = Random.Range(1, 4);

     //Instantiate(keyObject, transform.position, transform.rotation);

     if (keyRandomisedLocation == 1)
     {
         Vector3 mazeBuilding = new Vector3(-67.924f, 2.324f, -98.66f);
         Instantiate(keyObject[0], mazeBuilding, transform.rotation);
         Keys keyNumbering = GetComponent<Keys>();
         keyNumbering.ID = 1;
     }
     //

     if (keyRandomisedLocation == 2)
     {
         Vector3 mazeTent = new Vector3(-114.7f, 2.11f, -11.3f);
         Instantiate(keyObject[0], mazeTent, transform.rotation);
         Keys keyNumbering = GetComponent<Keys>();
         keyNumbering.ID = 1;
     }
     if (keyRandomisedLocation == 3)
     {
         Vector3 mazeGreenhouse = new Vector3(-125.4f, 2.11f, -113.6f);
         Instantiate(keyObject[0], mazeGreenhouse, transform.rotation);
         Keys keyNumbering = GetComponent<Keys>();
         keyNumbering.ID = 1;
     }  
 }
 */


