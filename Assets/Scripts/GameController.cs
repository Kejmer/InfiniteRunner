using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : ASingleton<GameController>
{
    [SerializeField]
    private UIMainInterfaceView MainInterfaceView;

    [SerializeField]
    private UIStartInterfaceView StartInterfaceView;

    [SerializeField]
    private UIEndInterfaceView EndInterfaceView;

    private const string GAMEPLAY_SCENE_NAME = "Gameplay";

    private SceneLoader m_SceneLoader;

    private bool m_Paused = false;

    private ulong m_Points = 0;

    private const int TICKET_PRICE = 215;

    public void ResetCoins()
    {
        m_Points = 0;
        MainInterfaceView.Configure(m_Points);
    }

    public void HandleCoinPickedUp(Coin coin)
    {
        if (coin == null)
            return;

        m_Points += coin.Points;
        MainInterfaceView.Configure(m_Points);

        // Check win condition
        if (m_Points >= TICKET_PRICE) {
            EndInterfaceView.gameObject.SetActive(true);
            MainInterfaceView.gameObject.SetActive(false);
        }
    }
    protected override void Initialize()
    {
        // MainInterfaceView.Initialize(Pause);    
        m_SceneLoader = new SceneLoader();

        MainInterfaceView.gameObject.SetActive(false);
        StartInterfaceView.gameObject.SetActive(true);
        EndInterfaceView.gameObject.SetActive(false);

        StartInterfaceView.Initialize(LoadGame);
        EndInterfaceView.Initialize(RestartGame);
    }

    private void HandleSceneLoaded(Scene loadedScene) {
        Debug.LogFormat("Loaded scene {0}", loadedScene.name);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }

    private void Pause()
    {
        m_Paused = !m_Paused;
        Time.timeScale = m_Paused ? 0f : 1f;
    }

    private void LoadGame()
    {
        m_SceneLoader.LoadScene(GAMEPLAY_SCENE_NAME, HandleSceneLoaded);

        MainInterfaceView.gameObject.SetActive(true);
        StartInterfaceView.gameObject.SetActive(false);
        EndInterfaceView.gameObject.SetActive(false);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Main");
    }

}
