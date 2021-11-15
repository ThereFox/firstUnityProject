using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CarMover : MonoBehaviour
{
    public Transform SelfTransform;
    private Vector3 _acseleration;
    private bool _isAcselerated;
    public Tilemap Map;
    public TileBase GroundTile;
    public float Speed;

    public float GetForce()
    {
        return _acseleration.magnitude;
    }


    public void Acselerate() {
        _acseleration += (SelfTransform.up * Time.deltaTime) * 0.1f;
        _isAcselerated = true;
    }
    public void RotateRight() {
        SelfTransform.Rotate(0, 0, -1);
    }
    public void RotateLeft()
    {
        SelfTransform.Rotate(0, 0, 1);
    }
    void LateUpdate()
    {
        if (!_isAcselerated)
        {
            _acseleration = Vector3.Lerp(_acseleration, Vector3.zero, Time.deltaTime);
        }

        if (GroundTile == Map.GetTile(new Vector3Int((int)SelfTransform.position.x,
            (int)SelfTransform.position.y,
            (int)SelfTransform.position.z))){
            _acseleration *= 0.1f;
        }
        SelfTransform.position += _acseleration * Speed * Time.deltaTime;
        

        _isAcselerated = false;
    }
}
