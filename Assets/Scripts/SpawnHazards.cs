using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHazards : MonoBehaviour {

#region Variables
    //Public
    //Private
    [SerializeField]
    private float minX = 0.0f;
    [SerializeField]
    private float maxX = 0.0f;
    [SerializeField]
    private int minHazardsToSpawn = 1;
    [SerializeField]
    private int maxHazardsToSpawn = 6;
    [SerializeField]
    private GameObject[] hazards; // array of hazards
    [SerializeField]
    private float timeBetweenSpawns = 0.0f;

    private bool canSpawn = false;
    private int amountOfHazardsToSpawn = 0;
    private int hazardToSpawn = 0;
    private int hazardSpawnCap = 7;
    private UIFunctions uiFunctions;
#endregion

 
    // Use this for initialization
    void Start () {
        uiFunctions = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIFunctions>();
        canSpawn = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(canSpawn == true && uiFunctions.gameStarted == true)
        {
            StartCoroutine("GenerateHazard");
        }
	}

    private IEnumerator GenerateHazard()
    {
        canSpawn = false;
        timeBetweenSpawns = Random.Range(0.5f, 2.0f); // Testing Values
        amountOfHazardsToSpawn = Random.Range(minHazardsToSpawn, maxHazardsToSpawn); //Testing Values

        for (int i=0; i<amountOfHazardsToSpawn; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), 8.0f, 0.0f); // Spawn Position for hazard
            Instantiate(hazards[hazardToSpawn], spawnPos, Quaternion.identity); // Spawn the hazard
        }
       
        yield return new WaitForSeconds(timeBetweenSpawns);
        canSpawn = true;
    }
}
