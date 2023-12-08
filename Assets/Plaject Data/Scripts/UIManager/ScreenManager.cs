using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Screentype
{
    Start,
    GamePlay,
    GameOver,
    PauseScreen,
}


public class ScreenManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public static ScreenManager instance;
    public BaseScreen[] Screens;
    public BaseScreen currentScreen;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        //SwitchScreen(Screentype.Start);
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void SwitchScreen(Screentype screentype)
    {
        if (currentScreen != null)
        {
            currentScreen.hide();
        }

        foreach (BaseScreen baseScreen in Screens)
        {
            if (baseScreen.Screen == screentype)
            {
                baseScreen.show();
                currentScreen = baseScreen;
                break;
            }
        }
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
