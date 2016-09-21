using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    [SerializeField]
    private Board board;

    [SerializeField]
    private Player[] players;

    private int currentPlayer;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        currentPlayer = 1;
		StartCoroutine(NextTurn());
    }

	public void Played(Token token, Position position)
    {
		if (board.CheckForWin(position))
            Debug.Log(string.Format("Game Finished, {0} won", token));
        else
			StartCoroutine (NextTurn());
    }

	private IEnumerator NextTurn()
    {
		yield return new WaitForEndOfFrame ();
        currentPlayer = (currentPlayer + 1) % players.Length;
        players[currentPlayer].Turn();
    }
}
