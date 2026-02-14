using System;
using UnityEngine;
using UnityEngine.InputSystem;

//a
[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveForce = 5;
    [SerializeField] private float _jumpForce = 5;

    private Rigidbody _rigidbody;
    private InputSystem_Actions _gameInputs;
    private Vector2 _moveInputValue;
    private bool _isGrounded = false;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // Actionスクリプトのインスタンス生成
        _gameInputs = new InputSystem_Actions();

        // Actionイベント登録
        _gameInputs.Player.Move.started += OnMove;
        _gameInputs.Player.Move.performed += OnMove;
        _gameInputs.Player.Move.canceled += OnMove;
        _gameInputs.Player.Jump.performed += OnJump;

        // Input Actionを機能させるためには、
        // 有効化する必要がある
        _gameInputs.Enable();
    }

    private void OnDestroy()
    {
        // 自身でインスタンス化したActionクラスはIDisposableを実装しているので、
        // 必ずDisposeする必要がある
        _gameInputs?.Dispose();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        // Moveアクションの入力取得
        _moveInputValue = context.ReadValue<Vector2>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 地面に触れたら接地
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // 地面から離れたら空中
        _isGrounded = false;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGrounded = false; // ジャンプ直後は空中扱い
        }
    }

    private void FixedUpdate()
    {
      //移動方向の力を与える
      _rigidbody.AddForce(new Vector3(
        _moveInputValue.x,
        0,
        _moveInputValue.y
      ) * _moveForce);
    }
    
    
}
