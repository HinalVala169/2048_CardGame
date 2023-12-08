using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    #region PUBLIC_VARS
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    public void Start()
    {
        AudioManager.instance.PlayAudioBG(AudioName.GameBG);
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void GameStart()
    {
        AudioManager.instance.PlayAudio(AudioName.ButtonClick);
        ScreenManager.instance.SwitchScreen(Screentype.GamePlay);
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion

    #region CO-ROUTINES

    #endregion

    #region EVENT_HANDLERS
    #endregion

    #region UI_CALLBACKS
    #endregion


}
