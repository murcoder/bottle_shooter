using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour {


    public BottleSpawner mySpawner;
    public GameObject bottleDestructedPrefab;
    private GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void GotShot(Vector3 exploPos)
    {
        //Initialize spawn process
        mySpawner.InitializeNewBottle();

        gameManager.IncreaseScore();

        if (!gameManager.gameStarted)
        {
            gameManager.gameStarted = true;
        }

        //Create destucted bottle
        GameObject destObj = Instantiate(bottleDestructedPrefab, transform.position, transform.rotation);
        destObj.transform.localScale = transform.localScale;

        //Add meshcollider for each piece of the destructed bottle
        foreach (MeshCollider meshColl in destObj.GetComponentsInChildren<MeshCollider>())
        {
            meshColl.convex = true;
            Rigidbody destRb = meshColl.gameObject.AddComponent<Rigidbody>();
            destRb.AddExplosionForce(800, exploPos, 5f);
        }

        //Remove hitted bottle and the destructed one
        //Destroy(destObj.gameObject, 3);
        Destroy(gameObject);
    }
}
