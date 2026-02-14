using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController2D : MonoBehaviour
{
    [Header("設定")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;

    [Header("Input Action参照")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        // アクションを有効化
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    void Update()
    {
        // 1. 移動入力の読み取り (Vector2を取得)
        moveInput = moveAction.action.ReadValue<Vector2>();

        // 2. ジャンプ入力の検知 (トリガーされたか)
        if (jumpAction.action.triggered && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // 3. 物理移動の適用 (横移動のみ速度を上書き)
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        // 上方向へ力を加える
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false; // 空中状態へ
    }

    // 地面に触れているかどうかの簡易判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 今回はシンプルに「何かに触れていれば地面」とみなします
        isGrounded = true;
    }
}