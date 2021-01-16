using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : ASingleton<GameController>
{
    [SerializeField]
    private UIMainInterfaceView MainInterfaceView;

    private const string GAMEPLAY_SCENE_NAME = "Gameplay";

    private SceneLoader m_SceneLoader;

    private bool m_Paused = false;

    private ulong m_Points = 0;
    // private int m_Lives = 3;

    public void ResetCoins()
    {
        m_Points = 0;
    }

    public void HandleCoinPickedUp(Coin coin)
    {
        if (coin == null)
            return;

        m_Points += coin.Points;
        MainInterfaceView.Configure(m_Points);
    }

    protected override void Initialize()
    {
        MainInterfaceView.Initialize(Pause);    

        m_SceneLoader = new SceneLoader();
        m_SceneLoader.LoadScene(GAMEPLAY_SCENE_NAME, HandleSceneLoaded);
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

    // public void HandleLifePickedUp(Coin life)
    // {
    //     if (life == null) 
    //         return;
        
    //     m_Lives += 1;
    //     Debug.LogFormat("Total lifes: {0}", m_Lives);
    // }

}
