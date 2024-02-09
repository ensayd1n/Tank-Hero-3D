using UnityEngine;

public class TankPositionController : MonoBehaviour
{
    private FixedJoystick _joystick;
    private Rigidbody _rigidbody;

    [Header("Input Values")] 
    public float MovementSpeed;
    public float MinimumX, MaximumX;

    private float currentPosition;
    private void Awake()
    {
        _joystick = GameObject.Find("FixedJoystick").GetComponent<FixedJoystick>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Position();
    }

    private void Position()
    {
        Vector3 currentPosition = transform.position;
        currentPosition += new Vector3(_joystick.Horizontal * MovementSpeed * Time.deltaTime, 0, MovementSpeed / 2 * Time.deltaTime);
        
        currentPosition.x = Mathf.Clamp(currentPosition.x, MinimumX, MaximumX);
        
        transform.position = currentPosition;
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * MovementSpeed * Time.deltaTime, 0, MovementSpeed * Time.deltaTime);
    }
}
