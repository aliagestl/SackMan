using UnityEngine;
using System.Collections;

public class FollowClick : MonoBehaviour {

    //set up variables
    int mass;
    //stop payer at a set distance to the target
    float minDistanceToTarget;
    float maxVel;
    float maxAcc;

    Vector2 position;
    Vector2 velocity;
    Vector2 accelaration;
    Vector2 target;

    // Use this for initialization
    void Start ()
    {
        //initialize variables
        mass = 10;
        minDistanceToTarget = 1;
        //set position to equal the position of the char
        position = new Vector2(this.transform.position.x, this.transform.position.y);
        //set target equal to position so that player does not initaly seek a point
        target = position;
        velocity = new Vector2(0, 0);
        //set max velocity
        maxVel = 10;
        //set max accelaration
        maxAcc = 10;
        accelaration = new Vector2(0, 0);
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //update position and clear acceleration
        position = new Vector2(this.transform.position.x, this.transform.position.y);
        accelaration = new Vector2(0,0);



        //if the mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            target = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }
        

        //if the player is close enough to the target stop
        if(Vector2.Distance(target, position) > minDistanceToTarget)
        {
            //calculate accelaration
            accelaration = (target - position);
            if (accelaration.magnitude > maxAcc)
            {
                accelaration = velocity.normalized * maxAcc;
            }


            //add the accelaration to the mass
            velocity = velocity + accelaration / mass;

            //if the velocity exceeds the limit set the velocity to the
            //max velocity
            if(velocity.magnitude > maxVel)
            {
                velocity = velocity.normalized * maxVel;
            }

            //add velocity
            position = position + velocity;
            this.transform.Translate(new Vector3(position.x,position.y,0));
        }
        else
        {
            //set velocity to zero if close enough
            velocity = new Vector2(0,0);
        }

    }
}

