
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemt : MonoBehaviour
{
    [Header("Movimiento")]
    public float moveSpeed = 3f;
   // public float jumpForce = 7f;

    [Header("Cámara")]
    public Transform cameraTransform;
    public float mouseSensitivity = 60;
    public float cameraPitchLimit = 80f;

    private Rigidbody rb;
    private bool isGrounded;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Evita que el Rigidbody se caiga al rotar
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        MoverJugador();
        RotarCamara();
      //  Saltar();
      Cursor.lockState = CursorLockMode.Locked;
    }

    void MoverJugador()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * moveSpeed;
        Vector3 vel = new Vector3(move.x, rb.velocity.y, move.z);
        rb.velocity = vel;
    }

    void RotarCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -cameraPitchLimit, cameraPitchLimit);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    //void Saltar()
    //{
    //    if (Input.GetButtonDown("Jump") && isGrounded)
    //    {
    //        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    //    }
    //}

    //void OnCollisionStay(Collision collision)
    //{
    //    isGrounded = true;
    //}

    //void OnCollisionExit(Collision collision)
    //{
    //    isGrounded = false;
    //}
}