using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 20.0f;
    public float maxSpeed = 7.0f;
    public float rotationSpeed = 360f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Получаем ввод от клавиатуры
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // Получаем ввод от мыши
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(0, rotationX, 0);

        // Применяем силу для перемещения в горизонтальной и вертикальной плоскостях
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddRelativeForce(movement * speed);

        // Ограничение скорости чтобы игрок не разгонялся больше значения maxSpeed
        Vector3 clampedVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxSpeed);
        rb.linearVelocity = clampedVelocity;
    }
}