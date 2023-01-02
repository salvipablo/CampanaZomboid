using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    [SerializeField]
    private float movSpeed;
    
    [SerializeField]
    private float turnSensitivity;

    [SerializeField]
    private GameObject cam;

    private new Transform camera;

    void Start()
    {
        camera = transform.Find("Camera");
    }

    void Update()
    {
        movements(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    private void movements(float horizontalTwistMouse, float verticalTwistMouse)
    {
        if (Input.GetButton("WalkForward")) transform.Translate(0, 0, movSpeed * Time.deltaTime);
        if (Input.GetButton("WalkBackwards")) transform.Translate(0, 0, -movSpeed * Time.deltaTime);
        if (Input.GetButton("WalkRight")) transform.Translate(movSpeed * Time.deltaTime, 0, 0);
        if (Input.GetButton("WalkLeft")) transform.Translate(-movSpeed * Time.deltaTime, 0, 0);

        Debug.Log(horizontalTwistMouse);
        Debug.Log(verticalTwistMouse);

        if (horizontalTwistMouse > 0 && verticalTwistMouse > 0)
        {
            cam.transform.SetParent(null);
            transform.Rotate(new Vector3(0, horizontalTwistMouse + turnSensitivity, 0));
            cam.transform.SetParent(transform);
        }
        if (horizontalTwistMouse < 0 && verticalTwistMouse > 0)
        {
            cam.transform.SetParent(null);
            transform.Rotate(new Vector3(0, (horizontalTwistMouse + turnSensitivity) * -1, 0));
            cam.transform.SetParent(transform);
        }
        //if (verticalTwistMouse != 0)
        //{
        //    float angle = (camera.localEulerAngles.x - verticalTwistMouse * turnSensitivity.y + 360) % 360;
        //    if (angle > 180) angle -= 360;
        //    angle = Mathf.Clamp(angle, -80, 80);
        //    camera.localEulerAngles = Vector3.right * angle;
        //}
    }
}
