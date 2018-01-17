using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Final_camera : MonoBehaviour {

    // Use this for initialization
    Transform _pivotTransform;
    Camera _mainCamera;
    [Header("Camera movement speed.")]
    [SerializeField]
    private int _cameraSpeed = 70;
    [Header("Camera movement speed whilst zoomed.")]
    [SerializeField]
    private int _cameraSpeedZoomed = 60;
    [Header("The speed of the interpolation between camera movements.")]
    [SerializeField]
    private int _lerpSpeed = 10;
    [Header("The max y value the main camera is allowed to go up/down to.")]
    [SerializeField]
    private int _maxCameraY = 25;
    bool _zoom;

    float _zoomFOV;
    Vector3 _zoomMainPos;

    [SerializeField]
    private Transform _playerTransform = null;
    private Character_Ctrl _player = null; //for checking of dead

    Vector3 _initPositionMain;
    int _initCameraSpeed;
    float _initFOV;
    Quaternion _initRotation;
    bool _isRotating = false;
    Quaternion _newRotation;
    Quaternion _rotation;
    Vector3 _initPositionPivot;

    [SerializeField]
    private bool _usePlayerYPosition = false;
    const int _degreesToRotateBy = 45;
    void Start ()
    {
        _mainCamera = Camera.main;
        _pivotTransform = GetComponent<Transform>();
        if (_playerTransform == null)
        {
            _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        //_player = _playerTransform.gameObject.GetComponent<Character_Ctrl>();

        // Initial val
        _initPositionMain = _mainCamera.transform.localPosition;
        _initCameraSpeed = _cameraSpeed;
        _initFOV = _mainCamera.fieldOfView;
      
        _initRotation = _pivotTransform.rotation;
        _newRotation = _initRotation;
        _initPositionPivot = _pivotTransform.position;

        // zoom
        _zoomFOV = _initFOV / 3;
        _zoomMainPos = _initPositionMain / 3;
        _zoomMainPos.y -= 1.5f; // slightly offset y -> to center camera on the player
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Zoom = false;
            _newRotation = _initRotation;
        }
        // Focus behind player on button press
        if (Input.GetButtonDown("Fire2"))
        {
            Zoom = true;
            _newRotation = _playerTransform.localRotation;
        }
        float rotAxis = Input.GetAxis("HorizontalCam");
        if (_isRotating && rotAxis != 0)
        {
            _isRotating = false;
            if (rotAxis < 0)
            {
                _newRotation = Quaternion.AngleAxis(_degreesToRotateBy, Vector3.up) *
                    _pivotTransform.localRotation;
            }
            else if (rotAxis > 0)
            {
                _newRotation = Quaternion.AngleAxis(-_degreesToRotateBy, Vector3.up) *
                    _pivotTransform.localRotation;
            }
        }
        if (rotAxis == 0)
        {
            _isRotating = true;
        }

        // Zoom
        if (Input.GetButtonDown("Fire3"))
        {
            // Toggle zoom
            Zoom = !Zoom;
        }
        if (Zoom)
        {
            // Set camera speed
            _cameraSpeed = _cameraSpeedZoomed;
            // Set zoom via FOV
            _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, _zoomFOV, _lerpSpeed * Time.deltaTime);
            // Set camera offset
            _mainCamera.transform.localPosition = Vector3.Lerp(_mainCamera.transform.localPosition, _zoomMainPos, _lerpSpeed * Time.deltaTime);
            // Set camera position to player
            _pivotTransform.position = Vector3.Lerp(_pivotTransform.position, _playerTransform.position, _lerpSpeed * Time.deltaTime);
        }
        else
        {
            // Set camera speed
            _cameraSpeed = _initCameraSpeed;
            // Reset zoom via FOV
            _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, _initFOV, _lerpSpeed * Time.deltaTime);
            // Set camera offset back to initial
            _mainCamera.transform.localPosition = Vector3.Lerp(_mainCamera.transform.localPosition, _initPositionMain, _lerpSpeed * Time.deltaTime);
            // Set camera position to zero
            Vector3 newPivotPos = _initPositionPivot;
            if (_usePlayerYPosition)
            {
                // Subtract player's y position if boolean is true
                newPivotPos.x = _initPositionPivot.x + _playerTransform.position.x / 2;
                newPivotPos.y = _initPositionPivot.y + _playerTransform.position.y / 2;
                newPivotPos.z = _initPositionPivot.z + _playerTransform.position.z / 2;
            }
            _pivotTransform.position = Vector3.Lerp(_pivotTransform.position, newPivotPos, _lerpSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("HorizontalCam") > 0)
        {
            transform.RotateAround(_pivotTransform.position, Vector3.up, _cameraSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("HorizontalCam") < 0)
        {
            transform.RotateAround(_pivotTransform.position, Vector3.up, -_cameraSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("VerticalCam") < 0)
        {
            float angle = transform.localEulerAngles.y;
            Vector3 rightAx = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0, -Mathf.Sin(Mathf.Deg2Rad * angle));
            transform.RotateAround(_pivotTransform.position, rightAx, -_cameraSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("VerticalCam") > 0)
        {
            float angle = transform.localEulerAngles.y;
            Vector3 rightAx = new Vector3(Mathf.Cos(Mathf.Deg2Rad * angle), 0, -Mathf.Sin(Mathf.Deg2Rad * angle));
           transform.RotateAround(_pivotTransform.position, rightAx, _cameraSpeed * Time.deltaTime);
        }
        //Get axis
        Vector2 axis = new Vector2(Input.GetAxis("HorizontalCam"), Input.GetAxis("VerticalCam"));

        // Clamp y axis values
        if (_mainCamera.transform.position.y < -_maxCameraY)
        {
            axis.y = Mathf.Clamp(axis.y, 0, 1);
        }
        else if (_mainCamera.transform.position.y > _maxCameraY)
        {
            axis.y = Mathf.Clamp(axis.y, -1, 0);
        }

        // Calculate stuff
        Quaternion xRot = Quaternion.identity;
        Quaternion yRot = Quaternion.identity;
        xRot = Quaternion.AngleAxis(axis.x * _cameraSpeed * Time.deltaTime, Vector3.up);
        yRot = Quaternion.AngleAxis(axis.y * _cameraSpeed * Time.deltaTime, Vector3.right);
        // Set rotation
        if (axis.x != 0 || axis.y != 0)
        {
            _pivotTransform.localRotation = xRot * _pivotTransform.localRotation * yRot;
            _newRotation = _pivotTransform.localRotation;
        }
        else
        {
            // Lerp
            _rotation = Quaternion.Lerp(_pivotTransform.localRotation, _newRotation, _lerpSpeed * Time.deltaTime);
            _pivotTransform.localRotation = xRot * _rotation * yRot;
        }
    }

    public bool Zoom
    {
        get
        {
            return _zoom;
        }
        set
        {
            _zoom = value;
        }
    }

}
