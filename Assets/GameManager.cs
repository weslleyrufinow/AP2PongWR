using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    playing,
    stopped
}

public enum CommandType
{
    reset,
    play,
    noop
}


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public delegate void GameDelegate();
    public event GameDelegate OnReset;
    public event GameDelegate OnPlay;

    private GameState currentState;
    private CommandType command;

    void Start()
    {
        command = CommandType.play;
        currentState = GameState.stopped;
    }

    public void SetCommand(CommandType cmd)
    {
        this.command = cmd;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case GameState.playing:
                if (command == CommandType.reset)
                {
                    if (OnReset != null)
                    {
                        this.currentState = GameState.stopped;
                        OnReset();
                    }
                }
                //TODO
                break;
            case GameState.stopped:
                if (command == CommandType.play)
                {
                    currentState = GameState.playing;
                    if (OnPlay != null)
                    {
                        OnPlay();
                    }
                }
                //TODO
                break;
        }
    }
}
