using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    [SerializeField]
    private Transform _targetA;
    [SerializeField]
    private Transform _targetB;
    [SerializeField]
    private float _speed = 3.0f;
    private bool _movingToB = false;

    void FixedUpdate()
    {
        if (_movingToB == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetA.position, _speed * Time.deltaTime);
        }
        else if (_movingToB == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetB.position, _speed * Time.deltaTime);
        }
        if (transform.position == _targetB.position)
        {
            _movingToB = false;
        }
        else if (transform.position == _targetA.position)
        {
            _movingToB = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}

