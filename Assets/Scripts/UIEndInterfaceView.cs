using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIEndInterfaceView : UIBehaviour
{
    [SerializeField]
    private Button m_EndButton;

    public void Initialize(UnityAction onEnd)
    {
        m_EndButton.onClick.AddListener(onEnd);        
    }
}
