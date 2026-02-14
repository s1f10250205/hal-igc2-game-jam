using UnityEngine;
using UnityEngine.InputSystem;

public class SelfDestructTrigger : MonoBehaviour
{

    [SerializeField] private InputActionReference selfDeathReference; // 自滅の入力アクション参照
    [SerializeField] private Health health; // Healthコンポーネントへの参照

    private void OnEnable()
    {
        //アクションを有効化
        selfDeathReference.action.Enable();
        //イベントを登録
        selfDeathReference.action.performed += OnSelfDestruct;
    }

    private void OnDisable()
    {
        //イベントを解除
        selfDeathReference.action.performed -= OnSelfDestruct;
        //アクションを無効化
        selfDeathReference.action.Disable();
    }

    private void OnSelfDestruct(InputAction.CallbackContext context)
    {
        Debug.Log("自滅処理呼び出し");
        //自滅処理を呼び出す
        health.Die();
    }


}
