using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    [SerializeField] UIManager uiManager;
    [SerializeField] List<GameObject> bricks = new List<GameObject>();
    [SerializeField] int nextLevelIndex;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public void CheckVictory() {
        foreach (GameObject brick in bricks)
        {
            if (brick.activeSelf) return;
        }

        SceneManager.LoadScene(nextLevelIndex);
    }

    public void gameOver()
    {
        uiManager.enableGameOver(true);
        InputManager.Instance.gameObject.SetActive(false);
    }
}
