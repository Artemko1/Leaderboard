using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private PlayerDbLoader DbLoader;
    [SerializeField] private Rectangle[] rectangles;
    [Space] [SerializeField] private Rectangle currentPlayerRectangle;
    [Space] [SerializeField] private int currentPlayerId;

    public void OpenBoard()
    {
        gameObject.SetActive(true);
        UpdateBoard();
    }

    public void CloseBoard()
    {
        gameObject.SetActive(false);
    }
    
    private void UpdateBoard()
    {
        var players = DbLoader.LoadPlayerDb().Players;
        var currentPlayer = players[currentPlayerId];
        var topScorePlayers = new Player[rectangles.Length];
        var playersWithHigherScore = 0;

        // Проход по базе.
        for (var i = 0; i < players.Length; i++)
        {
            var player = players[i];

            // Поиск X наибольших игроков.
            if (i < rectangles.Length)
            {
                topScorePlayers[i] = player;
                if (i == rectangles.Length - 1)
                {
                    topScorePlayers = topScorePlayers.OrderByDescending(player1 => player1.Score).ToArray();
                }
            }
            else if (player.Score > topScorePlayers[rectangles.Length - 1].Score)
            {
                topScorePlayers[rectangles.Length - 1] = player;
                topScorePlayers = topScorePlayers.OrderByDescending(player1 => player1.Score).ToArray();
            }
            
            // Подсчет места текущего игрока.
            if (player.Score > currentPlayer.Score)
            {
                playersWithHigherScore++;
            }
        }
        
        UpdateCurrentPlayerInfo(currentPlayer, playersWithHigherScore);
        UpdateTopPlayersInfo(topScorePlayers);
    }

    private void UpdateCurrentPlayerInfo(Player currentPlayer, int playersWithHigherScore)
    {
        currentPlayerRectangle.RefreshInfo(currentPlayer);
        currentPlayerRectangle.Place = playersWithHigherScore + 1;
    }
    private void UpdateTopPlayersInfo(IReadOnlyList<Player> topScorePlayers)
    {
        for (var i = 0; i < rectangles.Length; i++)
        {
            rectangles[i].RefreshInfo(topScorePlayers[i]);
        }
    }
}
