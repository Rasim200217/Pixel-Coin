using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _speedMove = 50f;

    Vector3 _moveVector;
    Rigidbody _rigidbody;

    

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        CharecterMove();
    }

    void CharecterMove()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _moveVector.z = Input.GetAxis("Vertical");

        Vector3 move = transform.position;
        move += new Vector3(_speed * Time.deltaTime * _moveVector.x, 0, _speed * Time.deltaTime * _moveVector.z);

        _rigidbody.MovePosition(move);

        if (Vector3.Angle(Vector3.forward, _moveVector) > 1f || Vector3.Angle(Vector3.forward, _moveVector) == 0)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveVector, _speed * Time.deltaTime, 0.5f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
