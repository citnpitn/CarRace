using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    DrivingScript ds;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        ds = GetComponent<DrivingScript>();
    }

    float lastTimeOk;
    // Update is called once per frame
    void Update()
    {
        float accel = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        CheckpointController checkpointController = ds.rb.GetComponent<CheckpointController>();

        if (ds.rb.velocity.magnitude > 1 || RaceController.racePending == false)
        {
            lastTimeOk = Time.time;
        }

        if (lastTimeOk + 5 < Time.time)
        {
            ds.rb.transform.position = checkpointController.lastPoint.transform.position;
            ds.rb.transform.rotation = checkpointController.lastPoint.transform.rotation;

            //Warstwy
        }

        if (!RaceController.racePending)
            accel = 0;
        ds.Drive(accel, brake, steer);
    }
}
