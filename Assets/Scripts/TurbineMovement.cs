using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineMovement : MonoBehaviour
{
    private Vector3 lastPosition = Vector3.zero;
    private Vector3 currentPosition = Vector3.zero;
    private Vector3 movementVector = Vector3.zero;
    [SerializeField] private float rotationFactor;
    [SerializeField] private float interpolationTime;
    [SerializeField] private GameObject[] turbines;

    IEnumerator Start()
    {
        while (true)
        {
            lastPosition = transform.position;
            yield return new WaitForSeconds(Time.deltaTime);
            currentPosition = transform.position;
            yield return new WaitForSeconds(Time.deltaTime);
            movementVector = (currentPosition - lastPosition).normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float movementDirection = Vector3.Dot(movementVector, transform.forward);
        //Debug.Log(movementDirection);
        movementDirection = Mathf.Round(movementDirection);
        
        foreach (GameObject turbine in turbines)
        {
            Quaternion targetRotation = Quaternion.Euler((rotationFactor * movementDirection) - 90f,
                0f,
                0f);
            Debug.Log("target: " +targetRotation.eulerAngles);
            Debug.Log("movement: " + movementDirection);

            turbine.transform.localRotation = Quaternion.Lerp(turbine.transform.localRotation, targetRotation, interpolationTime);
            //turbine.transform.localRotation = targetRotation;
        }
    }
}
