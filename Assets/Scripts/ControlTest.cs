using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ControlTest : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject aimIcon;
    Rigidbody2D aimIcon_rigidBody2D;
    public int playerID;
    float i_x;
    float angle, canShoot;
    bool canRotation, bool_canShoot;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
        aimIcon_rigidBody2D = GetComponent<Rigidbody2D>();
        angle = 0.0f;
        i_x = -0.23f;
        canShoot = 0.0f;
        canRotation = true;
        bool_canShoot = true;
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

            aimIcon.SendMessage("reduceScale", i_x);
            // Debug.Log(AimX);
        }
        else if (((AimX == 0 && AimY > 0) || (AimX > 0 && AimY > 0) || (AimY == 0 && AimX > 0)) && canRotation && bool_canShoot && playerID == 0)
        {

            //aimIcon.transform.position = new Vector3(AimX, AimY, 0.0f);
            angle = Mathf.Atan2(AimY, AimX) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);

        }
        else if(((AimX == 0 && AimY > 0) || (AimX < 0 && AimY > 0) || (AimY == 0 && AimX < 0)) && canRotation && bool_canShoot && playerID == 1){
            angle = Mathf.Atan2(AimY, AimX) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        }

        if (player.GetButton("Shoot") && bool_canShoot)
        {

            canShoot = aimIcon.GetComponent<_aimRayManager>().aimRayManager(angle);
            canRotation = false;
        }
        else
        {
            if (canShoot > 0) bool_canShoot = false;
            // aimIcon.SendMessage("reduceScale", i_x);
            canShoot = aimIcon.GetComponent<_aimRayManager>().reduceScale(i_x);
            canRotation = true;
            if (canShoot == 0) bool_canShoot = true;
        }


    }
}
