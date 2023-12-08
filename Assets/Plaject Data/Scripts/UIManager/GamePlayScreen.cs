using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayScreen : MonoBehaviour
{
    #region PUBLIC_VARS
    public TMP_Text HighScore;
    public TMP_Text Score;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void PauseScreenClick()
    {
        ScreenManager.instance.SwitchScreen(Screentype.PauseScreen);
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
