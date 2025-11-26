using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float speedMult = 1.5f;
    public float jumpForce = 7f;
    public int maxJumps = 2;
    private int jumpCont = 0;

    private bool isGrounded = false;
    private Rigidbody rb;

    public Animator animator;

    private Transform cam;   // cámara del juego

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal"); // A/D
        float y = Input.GetAxis("Vertical");   // W/S

        // dirección según la cámara (solo en plano XZ)
        Vector3 forward = cam.forward;
        forward.y = 0;       
        forward.Normalize();

        Vector3 right = cam.right;
        right.y = 0;
        right.Normalize();

        // vector de movimiento 2.5D
        Vector3 move = (forward * y + right * x).normalized;

        // Animaciones
        animator.SetFloat("VelX", x);
        animator.SetFloat("VelY", y);

        // Correr con Shift
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * speedMult : moveSpeed;

        // Aplicar velocidad
        rb.linearVelocity = new Vector3(move.x * currentSpeed, rb.linearVelocity.y, move.z * currentSpeed);

        // ⚠ Rotación del personaje según movimiento
        if (move.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 10f);
        }

        // Saltar
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCont < maxJumps))
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            jumpCont++;
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCont = 0;
        }
    }
}
