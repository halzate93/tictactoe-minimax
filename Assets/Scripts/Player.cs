using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    [SerializeField]
    private Token token;

    [SerializeField]
    private Board board;

    public event Action OnTurn;
    public event Action OnFinished;

    public void Play(Position pos)
    {
        if (board.TryPut(token, pos))
        {
            GameManager.Instance.Played(token, pos);
            if (OnFinished != null)
                OnFinished();
        }
        else
            Debug.Log(string.Format("Couldn't put token in pos: {0}, {1}", pos.x, pos.y));
    }

    public void Turn()
    {
        if (OnTurn != null)
            OnTurn();
    }
}
