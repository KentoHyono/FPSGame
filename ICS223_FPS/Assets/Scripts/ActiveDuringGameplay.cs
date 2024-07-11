using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDuringGameplay : MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_ACTIVE, OnGameActivated);
        Messenger.AddListener(GameEvent.GAME_INACTIVE, OnGameInActivated);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_ACTIVE, OnGameActivated);
        Messenger.RemoveListener(GameEvent.GAME_INACTIVE, OnGameInActivated);
    }
    private void OnGameActivated()
    {
        this.enabled = true;
    }

    private void OnGameInActivated()
    {
        this.enabled = false;
    }
}
