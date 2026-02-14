using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    [SerializeField] private InputActionReference resetKey; // リセットの入力アクション参照

    void Start()
    {
        resetKey.action.Enable(); // アクションを有効化
       
    }

    void Update()
    {
        if (resetKey.action.triggered) // リセットキーが押されたかをチェック
        {
            RestartScene(); // シーンをリスタート
        }
    }


    public void RestartScene()
    {
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
