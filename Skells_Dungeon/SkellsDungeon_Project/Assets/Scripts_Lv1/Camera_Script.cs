//using System.Collections;
//using UnityEngine;

//public class Camera_Script : MonoBehaviour
//{
//    Transform _pivotTransform;
//    Camera _mainCamera;

//    [Header("Camera movement speed.")]
//    [SerializeField]
//    int _cameraSpeed = 70;
//    [Header("Camera movement speed whilst zoomed.")]
//    [SerializeField]
//    int _cameraSpeedZoomed = 60;
//    [Header("The speed of the interpolation between camera movements.")]
//    [SerializeField]
//    int _lerpSpeed = 10;
//    [Header("The max y value the main camera is allowed to go up/down to.")]
//    [SerializeField]
//    int _maxCameraY = 25;

//    bool _zoom;

//    float _zoomFOV;
//    Vector3 _zoomMainPos;

//    [SerializeField]
//    Transform _playerTransform = null;
//    Character_Ctrl _player = null;

//    Vector3 _initPositionMain;
//    int _initCameraSpeed;
//    float _initFOV;
//    Quaternion _initRotation;
//    bool _isRotating = false;
//    Quaternion _newRotation;
//    Quaternion _rotation;
//    Vector3 _initPositionPivot;
//    [SerializeField]
//    bool _usePlayerYPosition = false;
//    const int _degreesToRotateBy = 45;

//    [SerializeField]
//    Transform _teleportCameraLocation = null;

//    void Start()
//    {

//        // Get components
//        _mainCamera = Camera.main;
//        _pivotTransform = GetComponent<Transform>();
//        if (_playerTransform == null)
//        {
//            _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
//        }
//        _player = _playerTransform.gameObject.GetComponent<Character_Ctrl>();

//        // Initial values
//        _initCameraSpeed = _cameraSpeed;
//        _initFOV = _mainCamera.fieldOfView;
//        _initPositionMain = _mainCamera.transform.localPosition;
//        _initRotation = _pivotTransform.rotation;
//        _newRotation = _initRotation;
//        _initPositionPivot = _pivotTransform.position;

//        // Magic numbers, sue me
//        _zoomFOV = _initFOV / 3;
//        _zoomMainPos = _initPositionMain / 3;
//        _zoomMainPos.y -= 1.5f; // slightly offset y -> to center camera on the player

//        if (_teleportCameraLocation == null)
//        {
//            Transform[] transforms = GameObject.FindGameObjectWithTag("Teleport").GetComponentsInChildren<Transform>();
//            foreach (Transform transform in transforms)
//            {
//                if (transform.name.Contains("Camera"))
//                {
//                    _teleportCameraLocation = transform;
//                }
//            }
//            Debug.LogWarning("Camera controller had to do some nasty stuff to get the teleport door's camera location, drag the 'Camera Finish Location' into the Camera Pivot's CameraController component to prevent this.");
//        }
//    }

//    void Update()
//    {
//        //if (_player.IsAlive)
//        //{
//        //InputStateManager.InputState _inputState = InputStateManager.Instance().GetInputState();

//        // Reset camera on button press
//        if (Input.GetButtonDown("Camera Reset"))
//        {
//            Zoom = false;
//            _newRotation = _initRotation;
//        }
//        // Focus behind player on button press
//        if (Input.GetButtonDown("Camera Focus"))
//        {
//            //Zoom = true;
//            _newRotation = _playerTransform.localRotation;
//        }

//        // Rotate by a specific amount of degrees
//        float rotAxis = InputStateManager.Instance().InputAxisCameraRotation;

//        if (_isRotating && rotAxis != 0)
//        {
//            _isRotating = false;
//            if (rotAxis < 0)
//            {
//                _newRotation = Quaternion.AngleAxis(_degreesToRotateBy, Vector3.up) *
//                    _pivotTransform.localRotation;
//            }
//            else if (rotAxis > 0)
//            {
//                _newRotation = Quaternion.AngleAxis(-_degreesToRotateBy, Vector3.up) *
//                    _pivotTransform.localRotation;
//            }
//        }
//        if (rotAxis == 0)
//        {
//            _isRotating = true;
//        }

//        // Zoom
//        if (Input.GetButtonDown("Zoom"))
//        {
//            // Toggle zoom
//            Zoom = !Zoom;
//        }
//        if (Zoom)
//        {
//            // Set camera speed
//            _cameraSpeed = _cameraSpeedZoomed;
//            // Set zoom via FOV
//            _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, _zoomFOV, _lerpSpeed * Time.deltaTime);
//            // Set camera offset
//            _mainCamera.transform.localPosition = Vector3.Lerp(_mainCamera.transform.localPosition, _zoomMainPos, _lerpSpeed * Time.deltaTime);
//            // Set camera position to player
//            _pivotTransform.position = Vector3.Lerp(_pivotTransform.position, _playerTransform.position, _lerpSpeed * Time.deltaTime);
//        }
//        else
//        {
//            // Set camera speed
//            _cameraSpeed = _initCameraSpeed;
//            // Reset zoom via FOV
//            _mainCamera.fieldOfView = Mathf.Lerp(_mainCamera.fieldOfView, _initFOV, _lerpSpeed * Time.deltaTime);
//            // Set camera offset back to initial
//            _mainCamera.transform.localPosition = Vector3.Lerp(_mainCamera.transform.localPosition, _initPositionMain, _lerpSpeed * Time.deltaTime);
//            // Set camera position to zero
//            Vector3 newPivotPos = _initPositionPivot;
//            if (_usePlayerYPosition)
//            {
//                // Subtract player's y position if boolean is true
//                newPivotPos.x = _initPositionPivot.x + _playerTransform.position.x / 2;
//                newPivotPos.y = _initPositionPivot.y + _playerTransform.position.y / 2;
//                newPivotPos.z = _initPositionPivot.z + _playerTransform.position.z / 2;
//            }
//            _pivotTransform.position = Vector3.Lerp(_pivotTransform.position, newPivotPos, _lerpSpeed * Time.deltaTime);
//        }

//        // Get axis
//        Vector2 axis = InputStateManager.Instance().InputAxisCamera;

//        // Clamp y axis values
//        if (_mainCamera.transform.position.y < -_maxCameraY)
//        {
//            axis.y = Mathf.Clamp(axis.y, 0, 1);
//        }
//        else if (_mainCamera.transform.position.y > _maxCameraY)
//        {
//            axis.y = Mathf.Clamp(axis.y, -1, 0);
//        }

//        // Calculate stuff
//        Quaternion xRot = Quaternion.identity;
//        Quaternion yRot = Quaternion.identity;
//        if (TransitionManager.Instance().IsTransitionFinished())
//        {
//            xRot = Quaternion.AngleAxis(axis.x * _cameraSpeed * Time.deltaTime, Vector3.up);
//            yRot = Quaternion.AngleAxis(axis.y * _cameraSpeed * Time.deltaTime, Vector3.right);
//        }
//        // Set rotation
//        if (axis.x != 0 || axis.y != 0)
//        {
//            _pivotTransform.localRotation = xRot * _pivotTransform.localRotation * yRot;
//            _newRotation = _pivotTransform.localRotation;
//        }
//        else
//        {
//            // Lerp
//            _rotation = Quaternion.Lerp(_pivotTransform.localRotation, _newRotation, _lerpSpeed * Time.deltaTime);
//            _pivotTransform.localRotation = xRot * _rotation * yRot;
//        }
//    }
//        else
//        {
//            if (_player.ReachedTeleport)
//            {
//                Camera.main.transform.position = _teleportCameraLocation.position;
//                Vector3 lookPos = _playerTransform.position;
//                // Shift y slightly to center on the player
//                 lookPos.y = _playerTransform.position.y + 0.6f;
//                Camera.main.transform.LookAt(lookPos);
//                // Zoom
//                _mainCamera.fieldOfView = _initFOV;
//                // Player
//                _playerTransform.rotation = _teleportCameraLocation.rotation* Quaternion.Euler(0, 180, 0);
//            }
//        }
//    }

//    public bool Zoom
//    {
//        get
//        {
//            return _zoom;
//        }
//        set
//        {
//            _zoom = value;
//        }
//    }


//}
