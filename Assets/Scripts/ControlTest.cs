using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ControlTest : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject aimIcon;
    Rigidbody2D aimIcon_rigidBody2D;
    int playerID = 0;
    float i_x;
    float angle;
    bool canRotation;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        aimIcon_rigidBody2D = GetComponent<Rigidbody2D>();
        angle = 0.0f;
        i_x = -0.05f;
        canRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float AimX = player.GetAxis("AimHorizontal");
        float AimY = player.GetAxis("AimVertical");

        // Debug.Log("X=");
        // Debug.Log(AimX);
        // Debug.Log("Y=");
        // Debug.Log(AimY);

        if (AimX == 0 && AimY == 0)
        {
            aimIcon.GetComponent<BoxCollider2D>().enabled = false;
            aimIcon.GetComponent<SpriteRenderer>().enabled = false;
            aimIcon.SendMessage("reduceScale", i_x);
            Debug.Log(AimX);
        }
        else if (((AimX == 0 && AimY > 0) || (AimX > 0 && AimY > 0) || (AimY == 0 && AimX > 0)) && canRotation)
        {
            aimIcon.GetComponent<BoxCollider2D>().enabled = true;
            aimIcon.GetComponent<SpriteRenderer>().enabled = true;
            //aimIcon.transform.position = new Vector3(AimX, AimY, 0.0f);
            angle = Mathf.Atan2(AimY, AimX) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);



            Debug.Log("X=");
            Debug.Log(AimX);
            Debug.Log("Y=");
            Debug.Log(AimY);
            Debug.Log("angle=");
            Debug.Log(angle);

        }
        else
        {
            aimIcon.GetComponent<BoxCollider2D>().enabled = false;
            aimIcon.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (player.GetButton("Shoot"))
        {
            aimIcon.SendMessage("aimRayManager", angle);
            canRotation = false;
        }
        else
        {
            aimIcon.SendMessage("reduceScale", i_x);
            canRotation = true;
        }


    }
}
