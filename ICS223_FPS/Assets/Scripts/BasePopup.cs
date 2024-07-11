using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    public void Open()
    {
        if (!IsActive())
        {
            gameObject.SetActive(true);
            Messenger.Broadcast(GameEvent.POPUP_OPENDED);
        }
    }
    public void Close()
    {
        if (IsActive())
        {
            gameObject.SetActive(false);
            Messenger.Broadcast(GameEvent.POPUP_CLOSED);
        }
    }
    public bool IsActive()
    {
        return gameObject.activeSelf;
    }
}
