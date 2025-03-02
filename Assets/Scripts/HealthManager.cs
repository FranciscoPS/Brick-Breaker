using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    [SerializeField] UIManager uiManager;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void gameOver()
    {
        uiManager.enableGameOver(true);
        InputManager.Instance.gameObject.SetActive(false);
    }
}
