using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScreen : MonoBehaviour
{
    #region PUBLIC_VARS
    public Screentype Screen;
    [HideInInspector]
    public Canvas canvas;
    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        canvas = GetComponent<Canvas>();
    }
    #endregion

    #region PUBLIC_FUNCTIONS
    public void show()
    {
        canvas.enabled = true;
    }

    public void hide()
    {
        canvas.enabled = false;
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
