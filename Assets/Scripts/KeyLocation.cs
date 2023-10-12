using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyBoolPairs
{
    public int keyNumber;
    public bool found;
}


public class KeyLocation : MonoBehaviour
{
    public bool key1Found = false;
    public bool key2Found = false; 
    public bool key3Found = false;

    public Dictionary<int, Keys> keyDict = new Dictionary<int, Keys>(); 

    public GameObject keyObject;

    public int ID;

    public void Start()
    {
        RandomizeKeys();
    }

    internal static void KeyFound(int iD)
    {
        throw new System.NotImplementedException();
    }

    public void RandomizeKeys()
    {
        int keyRandomisedLocation = Random.Range(1, 4);

        //Instantiate(keyObject, transform.position, transform.rotation);

        if (keyRandomisedLocation == 1)
        {
        Vector3 mazeBuilding = new Vector3(-67.924f, 2.324f, -98.66f);
        Instantiate(keyObject, mazeBuilding, transform.rotation);

        }
        //
        
        if (keyRandomisedLocation == 2)
        {
            Vector3 mazeTent = new Vector3(-114.7f, 2.11f, -11.3f);
            Instantiate(keyObject, mazeTent, transform.rotation);
        }
        if (keyRandomisedLocation == 3)
        {
            Vector3 mazeGreenhouse = new Vector3(-125.4f, 2.11f, -113.6f);
            Instantiate(keyObject, mazeGreenhouse, transform.rotation);
        }  
    }

    public void KeyFound (Keys numberofKey)
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
}
