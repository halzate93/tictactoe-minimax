using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Board : MonoBehaviour 
{
    [SerializeField]
    private Text[] labels;

    private Token[,] positions;
    private List<Position> available;

    private void Awake()
    { 
        positions = new Token[3, 3];
        available = new List<Position>();
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                positions[i, j] = Token.None;
                available.Add(new Position(i, j));
            }
        }
    }

	public List<Position> GetAvailable()
	{
		return available;
	}

	public bool TryPut (Token token, Position position)
    {
        if (positions[position.x, position.y] != Token.None)
			return false;
		
        positions[position.x, position.y] = token;
        labels[position.x * 3 + position.y].text = token.ToString();
		RemoveFromAvailable(position);
		return true;
    }

	public bool CheckForWin (Position position)
	{
		Token token = positions [position.x, position.y];
		for (int dx = -1; dx <= 1; dx++) 
		{
			for (int dy = -1; dy <= 1; dy++) 
			{
				if (dx == 0 && dy == 0)
					continue;
				int count = CountAdjacentPositions (position, token, dx, dy) 
					+ CountAdjacentPositions (position, token, -dx, -dy) + 1;
				if (count == 3)
					return true;
			}
		}
		return false;
	}

	private int CountAdjacentPositions(Position position, Token token, int dx, int dy)
	{
		int count = 0;
		int x = position.x + dx;
		int y = position.y + dy;
		while (x >= 0 && x < 3 && y >= 0 && y < 3 && positions[x, y] == token)
		{
			count++;
			x += dx;
			y += dy;
		}
		return count;
	}

    private void RemoveFromAvailable(Position position)
    {
        int index = -1;
        for (int i = 0; index == -1 && i < available.Count; i++)
        {
            if (available[i].x == position.x && available[i].y == position.y)
                index = i;
        }
        available.RemoveAt(index);
    }
}
