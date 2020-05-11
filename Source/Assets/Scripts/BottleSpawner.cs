using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{

    public GameObject bottlePrefab;
    bool bottleOnTheWay;

    void Start()
    {
        SpawnNewBottle();
    }

    public void InitializeNewBottle()
    {
        //Check if spawn is already initialized
        if (bottleOnTheWay)
            return;

        //Spawn bottle in 4 seconds
        bottleOnTheWay = true;
        Invoke("SpawnNewBottle", 4);
    }
    
    private void SpawnNewBottle()
    {
        GameObject myBottle = Instantiate(bottlePrefab, transform.position, Quaternion.identity);
        bottleOnTheWay = false;

        myBottle.GetComponent<Bottle>().mySpawner = this;
    }

}
