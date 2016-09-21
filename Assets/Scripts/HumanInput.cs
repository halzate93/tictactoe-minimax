using UnityEngine;
using System.Collections;

public class HumanInput : MonoBehaviour 
{
    [SerializeField]
    private Player controlled;

    private bool canPlay;

    private void Awake ()
    {
        controlled.OnTurn += ToggleCanPlay;
        controlled.OnFinished += ToggleCanPlay;
    }

    private void Update()
    {
        if (!canPlay) return;

        if (Input.GetKeyDown(KeyCode.Q))
            controlled.Play(new Position (0, 0));
        if (Input.GetKeyDown(KeyCode.W))
            controlled.Play(new Position (0, 1));
        if (Input.GetKeyDown(KeyCode.E))
            controlled.Play(new Position (0, 2));
        if (Input.GetKeyDown(KeyCode.A))
            controlled.Play(new Position (1, 0));
        if (Input.GetKeyDown(KeyCode.S))
            controlled.Play(new Position (1, 1));
        if (Input.GetKeyDown(KeyCode.D))
            controlled.Play(new Position (1, 2));
        if (Input.GetKeyDown(KeyCode.Z))
            controlled.Play(new Position (2, 0));
        if (Input.GetKeyDown(KeyCode.X))
            controlled.Play(new Position (2, 1));
        if (Input.GetKeyDown(KeyCode.C))
            controlled.Play(new Position (2, 2));
    }

    private void ToggleCanPlay()
    {
        canPlay = !canPlay;
    }
}
