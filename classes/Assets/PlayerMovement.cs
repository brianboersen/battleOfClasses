using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    public Rigidbody _rigidbody;
    private Vector3 _direction;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        _direction = new Vector3(x, 0f, z);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            Vector3 point = ray.GetPoint(distance);
            Vector3 adjustedheighpoint = new Vector3(point.x, transform.position.y, point.z);
            transform.LookAt(adjustedheighpoint);
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = _direction * speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + velocity);
    }   
}
