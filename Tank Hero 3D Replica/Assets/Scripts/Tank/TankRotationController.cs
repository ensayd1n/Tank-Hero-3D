using UnityEngine;

public class TankRotationController : MonoBehaviour
{
    private FixedJoystick _joystick;
    
    [Header("Input Values")] 
    public float RotationSpeed;
    
    private float horizontalInput;
    
    private void Awake()
    {
        _joystick = GameObject.Find("FixedJoystick").GetComponent<FixedJoystick>();
    }
    
    private void FixedUpdate()
    {
        Rotation();
    }

    private void Rotation()
    {
        float horizontalInput = _joystick.Horizontal;

        if (horizontalInput != 0)
            horizontalInput += horizontalInput * Time.deltaTime * RotationSpeed;
        
        else
            horizontalInput -= horizontalInput * Time.deltaTime * RotationSpeed;
        
        horizontalInput = Mathf.Clamp(horizontalInput, -40, 40);
        transform.rotation = Quaternion.Euler(0, horizontalInput, 0);
        
    }
}
