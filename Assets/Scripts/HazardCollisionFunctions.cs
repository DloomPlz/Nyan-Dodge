using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HazardCollisionFunctions : MonoBehaviour {

    #region Variables
    //Public
    public GameObject restartButton;
    public GameObject homeButton;
    public GameObject scoreText;

    //private
    [SerializeField]
    ParticleSystem hazardDustParticles;
    private UIFunctions uiFunctions;
#endregion


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            Destroy(Instantiate(hazardDustParticles.gameObject, transform.position, Quaternion.identity), hazardDustParticles.startLifetime);
            this.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Player")
        {
            
            uiFunctions.gameStarted = false; // Stop the game
            uiFunctions.GameEnded();
            Destroy(Instantiate(hazardDustParticles.gameObject, transform.position, Quaternion.identity), hazardDustParticles.startLifetime);
            this.gameObject.SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
        uiFunctions = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIFunctions>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
