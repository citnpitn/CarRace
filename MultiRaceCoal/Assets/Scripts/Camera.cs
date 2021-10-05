using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform subject;
    Vector3 offset;



    void Start()
    {
        offset = transform.position - subject.position;
    }





    void Update()
    {
        transform.position = subject.position + offset;
        transform.LookAt(subject);
    }
}
