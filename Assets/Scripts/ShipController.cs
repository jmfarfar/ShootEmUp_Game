using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float forwardSpeed = 25f, strafeSpeed = 10f, hoverSpeed = 8f;
    private float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed;
    public float forwardAcceleration = 2.5f, strafeAcceleration = 4f, hoverAcceleration = 4f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    CharacterController characterController;

 //**************************************
    private Ship ship;   
    [Header("PwrUp Velocity Settings")]
    [SerializeField] private float boostedSpeedMultiply = 1.2f;
    [SerializeField] private float timeSpeedBoost = 5f;    
    private float speedCoolDown = 0f;
    private float currentForwardSpeed, currentStrafeSpeed;         
 //**************************************

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        ship = GetComponent<Ship>();        
    }

    // Start is called before the first frame update
    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        
    }

    void Movement()
    {
        // position of the mouse on the screen as a Vector2
        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        // Calculate how far as a vector2 is the mouse pointer from the center of the screen.
        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        // Set a limit on the force of rotation when the mouse pointer is out of boundaries of the screen.
        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        // Get the Input values and rotate the ship in its local pivot.
        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);
        transform.Rotate(-mouseDistance.y * lookRateSpeed * Time.deltaTime, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);

        // Set speed values
        activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAcceleration * Time.deltaTime);
        activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAcceleration * Time.deltaTime);
        activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAcceleration * Time.deltaTime);

        // Moving the ship
        //transform.position += transform.forward * activeForwardSpeed * Time.deltaTime;
        //transform.position += (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

        characterController.Move(((transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime)) + transform.forward * activeForwardSpeed * Time.deltaTime);
    }


    public void SpeedBoostActive()
    {
        if (speedCoolDown == 0)
        {
            currentForwardSpeed = forwardSpeed;
            currentStrafeSpeed = strafeSpeed;
            forwardSpeed *= boostedSpeedMultiply;
            strafeSpeed *= boostedSpeedMultiply;            
            StartCoroutine(SpeedBoostPowerDown());
            

        }
        else
        {
            speedCoolDown += timeSpeedBoost;
        }
    }

    IEnumerator SpeedBoostPowerDown()
    {
        speedCoolDown += timeSpeedBoost;
        while(speedCoolDown > 0)
        {
            yield return new WaitForSeconds(1.0f);
            speedCoolDown--;
        }

        forwardSpeed = currentForwardSpeed;
        strafeSpeed = currentStrafeSpeed;        
    }


}