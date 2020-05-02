using UnityEngine;


public sealed class UnitMotor : IMotor
{
    #region Fields

    private Transform _instance;
    private Transform _head;
    private CharacterController _characterController;

    private Vector2 _input;
    private Vector3 _moveVector;
    private Quaternion _characterTargetRot;
    private Quaternion _cameraTargetRot;

    private float _speedMove = 10.0f;
    private float _jumpPower = 10.0f;
    private float _gravityForce;
    // public
    private float _xSensitivity = 2.0f;
    private float _ySensitivity = 2.0f;
    private float _minimumX = -90.0f;
    private float _maximumX = 90.0f;
    private float _smoothTime = 5.0f;
    // public bool _smoot;
    private bool _smooth = false;
    private bool _clampVerticalRotation = true;

    #endregion


    #region ClassLifeCycles

    public UnitMotor(CharacterController instance)
    {
        _instance = instance.transform;
        _characterController = instance;
        _head = Camera.main.transform;

        _characterTargetRot = _instance.localRotation;
        _cameraTargetRot = _head.localRotation;
    }

    #endregion


    #region Methods

    public void Move()
    {
        CharacterMove();
        GamingGravity();

        LookRotation(_instance, _head);
    }

    private void CharacterMove()
    {
        if (_characterController.isGrounded)
        {
            _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 desiredMove = _instance.forward * _input.y + _instance.right * _input.x;
            _moveVector.x = desiredMove.x * _speedMove;
            _moveVector.z = desiredMove.z * _speedMove;
        }

        _moveVector.y = _gravityForce;
        _characterController.Move(_moveVector * Time.deltaTime);
    }

    private void GamingGravity()
    {
        if (!_characterController.isGrounded)
        {
            _gravityForce -= 30 * Time.deltaTime;
        }
        else
        {
            _gravityForce = -1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _gravityForce = _jumpPower;
        }
    }

    private void LookRotation(Transform character, Transform camera)
    {
        float yRot = Input.GetAxis("Mouse X") * _xSensitivity;
        float xRot = Input.GetAxis("Mouse Y") * _ySensitivity;

        _characterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
        _cameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);

        if (_clampVerticalRotation)
        {
            _cameraTargetRot = ClampRotationAroundXAxis(_cameraTargetRot);
        }

        if (_smooth)
        {
            character.localRotation = Quaternion.Slerp(character.localRotation, _characterTargetRot, _smoothTime * Time.deltaTime);
            camera.localRotation = Quaternion.Slerp(camera.localRotation, _cameraTargetRot, _smoothTime * Time.deltaTime);
        }
        else
        {
            character.localRotation = _characterTargetRot;
            camera.localRotation = _cameraTargetRot;
        }
    }

    private Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
        angleX = Mathf.Clamp(angleX, _minimumX, _maximumX);
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

    #endregion
}