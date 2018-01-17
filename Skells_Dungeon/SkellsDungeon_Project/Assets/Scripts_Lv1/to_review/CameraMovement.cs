using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    private float _rotationSpeed = 100.0f;
    private float _zoomSpeed = 16f;
    [SerializeField]
    private float _maxDistance = 15f;
    [SerializeField]
    private float _minDistance = -5f;
    [SerializeField]
    private Transform _rotationCenter;
    [SerializeField]
    private Transform _Player;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Rotate left right up and down
        if (Input.GetAxis("HorizontalCam") > 0)
        {
            transform.RotateAround(_rotationCenter.position, Vector3.up, _rotationSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("HorizontalCam") < 0)
        {
            transform.RotateAround(_rotationCenter.position, Vector3.up, -_rotationSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("VerticalCam") < 0)
        {
            float angle = transform.localEulerAngles.y;
            Vector3 rightAx = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0, -Mathf.Sin(Mathf.Deg2Rad * angle));
            transform.RotateAround(_rotationCenter.position, rightAx, -_rotationSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("VerticalCam") > 0)
        {
            float angle = transform.localEulerAngles.y;
            Vector3 rightAx = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0, -Mathf.Sin(Mathf.Deg2Rad * angle));
            transform.RotateAround(_rotationCenter.position, rightAx, _rotationSpeed * Time.deltaTime);
        }

        //Zoom in out
        float d = Input.GetAxis("Zoom");
        if (d > 0f)
        {
            Vector3 vecDiff = transform.position - _rotationCenter.position;
            float distance = vecDiff.magnitude;
            if (distance > _minDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, _Player.position, _zoomSpeed * Time.deltaTime);
            } 
        }
        if (d < 0f)
        {
            Vector3 vecDiff = transform.position - _rotationCenter.position;
            float distance = vecDiff.magnitude;
            if (distance < _maxDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, _Player.position, -_zoomSpeed * Time.deltaTime);
            }
        }


        ////Rotate cam up
        //if (Input.GetKey(KeyCode.C))
        //{
        //    Vector3 vecDiff = (transform.position - _rotationCenter.position).normalized;

        //    Vector3 vecUp = this.transform.up;
        //    //Vector3 vecUp = Vector3.Cross(vecDiff, Vector3.up).normalized;
        //    //vecUp = Vector3.Cross(vecDiff, vecUp).normalized;
        //    transform.RotateAround(_rotationCenter.position, Vector3.left , _rotationSpeed * Time.deltaTime);

        //    Debug.Log("Current vecUp pos:" + vecUp);
        //    Debug.Log("Current transform pos:" + transform.position);

        //}


    }
}
