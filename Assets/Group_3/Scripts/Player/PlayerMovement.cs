using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] InputReader inputReader = default;
    [SerializeField] private StatsSO stats;
    private Vector3 position = new Vector3();
    private new Rigidbody rigidbody;
    private Transform cam;

    private void OnEnable()
    {
        inputReader.movementEvent += OnMove;
    }
    private void OnDisable()
    {
        inputReader.movementEvent -= OnMove;
    }

    private void Start()
    {
        cam = Camera.main.transform;
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * position.z + cam.right * position.x;
        rigidbody.MovePosition(transform.position + dir * stats.MovementSpeed * Time.deltaTime);
    }
    private void Rotate()
    {
        transform.rotation = Quaternion.AngleAxis(cam.eulerAngles.y, Vector3.up);
    }

    //Event System
    private void OnMove(Vector3 value)
    {
        position = value;
    }
}
