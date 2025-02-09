﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIMainInterfaceView : UIBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_CoinText;

    public void Configure(ulong coinNumber)
    {
        m_CoinText.text = ": " + coinNumber.ToString();
    }
}
