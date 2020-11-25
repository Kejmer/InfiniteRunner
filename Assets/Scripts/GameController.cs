using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : ASingleton<GameController>
{
    private ulong m_Points = 0;
    private int m_Lives = 3;

    public void HandleCoinPickedUp(Coin coin)
    {
        if (coin == null)
            return;

        m_Points += coin.Points;
        Debug.LogFormat("Total points: {0}", m_Points);
    }

    public void HandleLifePickedUp(Coin life)
    {
        if (life == null) 
            return;
        
        m_Lives += 1;
        Debug.LogFormat("Total points: {0}", m_Lives);
    }
}
