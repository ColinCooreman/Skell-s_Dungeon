using UnityEngine;
using System.Collections;

public class CameraCTRL : MonoBehaviour
{
    //public var
    [SerializeField]
    private Transform _rotationCenter;

    private Transform _player;
    [SerializeField]
    private float _startAngle = 0.0f;
    [SerializeField]
    private float _rotationSpeed = 5;
    [SerializeField]
    private float _zoomSpeed = 5;
    [SerializeField]
    private float _maxDist = 15f;
    [SerializeField]
    private float _minDist= -5f;
    //private var
    Vector3 camoffset;
    Vector3 lerpVector;
    Vector3 initcamoffset;

	void Start()
	{
        _player = Game_Manager.Instance().getPlayer().transform;
		camoffset = _rotationCenter.position - transform.position;
        initcamoffset = camoffset;
        lerpVector = camoffset;

        _rotationCenter.Rotate (0, _startAngle, 0);
		float desiredYAngle = _rotationCenter.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler (0, desiredYAngle, 0);
		transform.position = _rotationCenter.position - (rotation * camoffset);
		transform.LookAt (_rotationCenter);
	}


    void LateUpdate()
    {
        Cam1();
        LerpOffset();
    }

	void Cam1()
	{
        float desiredYAngle = _rotationCenter.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredYAngle, 0);

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

        //Get axis
        Vector2 axis = new Vector2(Input.GetAxis("HorizontalRStick"), Input.GetAxis("VerticalRStick"));

        // Clamp y axis values
        if (this.transform.position.y < -25)
        {
            axis.y = Mathf.Clamp(axis.y, 0, 1);
        }
        else if (this.transform.position.y > 25)
        {
            axis.y = Mathf.Clamp(axis.y, -1, 0);
        }
        if (Input.GetAxis("HorizontalRStick") != 0)
        {
            transform.RotateAround(_rotationCenter.position, Vector3.up, axis.x * _rotationSpeed * Time.deltaTime * 10);
        }
        if (Input.GetAxis("VerticalRStick") != 0 && axis.y * _rotationSpeed * Time.deltaTime * 1 < 90)
        {
            float angle = transform.localEulerAngles.y;
            Vector3 rightAx = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0, -Mathf.Sin(Mathf.Deg2Rad * angle));
            transform.RotateAround(_rotationCenter.position, rightAx, axis.y *_rotationSpeed * Time.deltaTime * 10); //magic number because controlsticks were slower
        }

        float d = Input.GetAxis("Zoom");
        if (d > 0f)
        {
            Vector3 vecDiff = transform.position - _rotationCenter.position;
            float distance = vecDiff.magnitude;
            if (distance > _minDist)
            {
                transform.position = Vector3.MoveTowards(transform.position, _rotationCenter.position, _zoomSpeed * Time.deltaTime);
            }
        }
        if (d < 0f)
        {
            Vector3 vecDiff = transform.position - _rotationCenter.position;
            float distance = vecDiff.magnitude;
            if (distance < _maxDist)
            {
                transform.position = Vector3.MoveTowards(transform.position, _rotationCenter.position, -_zoomSpeed * Time.deltaTime);
            }
        }
    }

    public void SetCamOffset(Vector3 offset)
    {
        if(offset == Vector3.zero)
        {
            lerpVector = initcamoffset;
            return;
        }
        lerpVector = offset;
    }

    private void LerpOffset()
    {
        if(Vector3.Distance(camoffset, lerpVector) > 0.01f)
        {
            camoffset = Vector3.Lerp(camoffset, lerpVector, 0.1f);
        }
    }


   private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
