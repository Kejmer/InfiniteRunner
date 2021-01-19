using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIStartInterfaceView : UIBehaviour
{
    [SerializeField]
    private Button m_StartButton;

    public void Initialize(UnityAction onStart)
    {
        m_StartButton.onClick.AddListener(onStart);        
    }
}
