using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DebugControls : MonoBehaviour
{

    private void Awake()
    {
        var playerInput = GetComponent<PlayerInput>();

        var restart = playerInput.actions["Restart"];
        restart.performed += ctx => Restart();
    }

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}