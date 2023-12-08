using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    #region PUBLIC_VARS
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion
   
    #region PUBLIC_FUNCTIONS
    public void OnRestartBtn()
    {
        AudioManager.instance.PlayAudio(AudioName.ButtonClick);
        SceneManager.LoadScene("Scene");
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
