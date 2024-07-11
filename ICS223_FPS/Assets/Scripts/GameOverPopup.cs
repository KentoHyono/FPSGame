using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPopup : BasePopup
{
   public void OnStartAgainButton()
    {
        Close();
        Messenger.Broadcast(GameEvent.RESTART_GAME);
    }

    public void OnExitGameButton()
    {
        Debug.Log("Exiting Game");
        Application.Quit();
    }
}
