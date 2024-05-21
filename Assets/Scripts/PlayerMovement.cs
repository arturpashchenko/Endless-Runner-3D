using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
namespace PlayerMovement
{
    public enum CurrentSide { right, middle, left }
    public enum MoveSide {r,m,l}
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField] private Rigidbody _player;
        [SerializeField] private Animator _animator;
        [Space]
        [Header("Jump")]
        [SerializeField] private float _jumpPower;
        [SerializeField] private float _distanceForRaycast;
        [Space]
        [Header("Move")]
        [SerializeField] private float _durationForLeftOrRightDodge;
        [SerializeField] private float _leftPosition;
        [SerializeField] private float _midPosition;
        [SerializeField] private float _rightPosition;

        Vector3 _targetPosition;
        CurrentSide _currentSide = CurrentSide.middle;
        MoveSide _moveSide = MoveSide.m;
        private InputManager _inputManager;

       
        private void Awake()
        {
            _inputManager = new InputManager();
            _inputManager.MainMovement.Jump.performed += Jump;
            _inputManager.MainMovement.MoveRight.performed += MoveRight;
            _inputManager.MainMovement.MoveLeft.performed += MoveLeft;


        }
        private void MoveLeft(InputAction.CallbackContext context)
        {
           

            _moveSide = MoveSide.l;

            if (_currentSide == CurrentSide.middle)
            {
                StartCoroutine(MovePlayer());
                _currentSide = CurrentSide.left;

            } 
            else if (_currentSide == CurrentSide.right)
            {
                StartCoroutine(MovePlayer());
                _currentSide = CurrentSide.middle;
            }
       
        }
      
        private void MoveRight(InputAction.CallbackContext context)
        {
           
            _moveSide = MoveSide.r;

            if (_currentSide == CurrentSide.middle)
            {
                StartCoroutine(MovePlayer());
                _currentSide = CurrentSide.right;
            }
            else if (_currentSide == CurrentSide.left)
            {
                StartCoroutine(MovePlayer());
                _currentSide = CurrentSide.middle;
            }
        }

        private void Jump(InputAction.CallbackContext context)
        {
            if (Physics.Raycast(_player.transform.position, Vector3.down, _distanceForRaycast))
            {
                _player.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
                _animator.Play("Jump");
            }
            

        }
        IEnumerator MovePlayer()
        {
            float elapsedTime = 0;
            Vector3 startPosition = _player.transform.position;

            if (_currentSide == CurrentSide.left && _moveSide == MoveSide.r)
            {
                AnimForRightDodge();
                _targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, _midPosition);
            }

            if (_currentSide == CurrentSide.middle)
            {
                if (_moveSide == MoveSide.r)
                {
                    AnimForRightDodge();
                    _targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, _rightPosition);
                }
                else if (_moveSide == MoveSide.l)
                {
                    AnimForLeftDodge();
                    _targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, _leftPosition);
                }
            }


            if (_currentSide == CurrentSide.right && _moveSide == MoveSide.l)
            {
                AnimForLeftDodge();
                _targetPosition = new Vector3(_player.transform.position.x, _player.transform.position.y, _midPosition);
            }
            while (elapsedTime < _durationForLeftOrRightDodge)
            {
                _player.transform.position = Vector3.Lerp(startPosition, _targetPosition, (elapsedTime / _durationForLeftOrRightDodge));
                elapsedTime += Time.deltaTime;
                yield return null;
            }


            _player.position = _targetPosition;

        }
        private void AnimForLeftDodge()
        {
            if (Physics.Raycast(_player.transform.position, Vector3.down, _distanceForRaycast))
            {
                _animator.Play("Left Dodge");
            }
        } 
        private void AnimForRightDodge()
        {
            if (Physics.Raycast(_player.transform.position, Vector3.down, _distanceForRaycast))
            {
                _animator.Play("Right Dodge");
            }
        }
        private void OnEnable()
        {
            _inputManager.Enable();
        }
        private void OnDisable()
        {
            _inputManager.Disable();
        }
    }
} 