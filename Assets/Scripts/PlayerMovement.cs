using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

#region Variables
    //Public
    //Private
    [SerializeField]
    private float movementSpeed = 0.0f;
    private Rigidbody myRB;

#endregion
    // Use this for initialization
    void Start () {
        myRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            float hAxis = Input.GetAxis("Horizontal");
            Vector3 moveDir = new Vector3(hAxis, 0, 0);
            myRB.velocity = moveDir * movementSpeed * Time.fixedDeltaTime;
        }
    }
}
