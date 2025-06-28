using UnityEngine;

public class MoveAircraft : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed = 5.0f; 
    public float RotationSpeed = 1.0f; 
    public float MaxSpeed = 5.0f;
    public float MaxAngularSpeed = 2.0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float sideForce = Input.GetAxisRaw("Horizontal") * RotationSpeed;
        float forwardForce = Input.GetAxisRaw("Vertical") * Speed;  

        rb.AddRelativeForce(0f, 0f, forwardForce);
        rb.AddRelativeTorque(0f, sideForce, 0f);
        
        // Ограничение линейной скорости
        Vector3 clampedVelocity = Vector3.ClampMagnitude(rb.linearVelocity, MaxSpeed);
        rb.linearVelocity = clampedVelocity;

        // Ограничение угловой скорости
        Vector3 clampedAngularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, MaxAngularSpeed);
        rb.angularVelocity = clampedAngularVelocity;
    }
}