using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public Transform[] Waypoints;
    public Transform SelfTransform;
    public CarMover Car;
    private int _currntPoint;

    void Update()
    {
        Transform current = Waypoints[_currntPoint];
        Vector3 direction = SelfTransform.position - current.position;

        float angel = Vector3.Dot(direction, -SelfTransform.right);
        
        if (angel > 0)
        {
            Car.RotateRight();
        }
        else if (angel == 0)
        {  
        }
        else {
            Car.RotateLeft();
        }
        Car.Acselerate();

        if (angel < 0.2f && angel > -0.2f) {
            Car.Acselerate();
        }

        if (Vector3.Distance(SelfTransform.position, current.position) < 1f) {
            _currntPoint++;
            if (_currntPoint > Waypoints.Length) {
                _currntPoint = 0;
            }
        }
    }
}
