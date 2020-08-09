using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerDataManager : MonoBehaviour
{

    // Bu class Player'ın Statlarını tutacak ve güncelleyecek.
    // Health, Score, Highscore, Level, Name... 

    private string playerName = "NULL";

    private int score;
    private int hightScore;

    private int level;

    // TODO:
    // Health sistemi kurulacak.
    private int health;

    public virtual void SetDefaultData()
    {
        playerName = "NULL";
        score = 0;
        hightScore = 0;
        level = 0;
        health = 3; // Game-specific
    }

    #region Getter Funcs
    public string GetName() => playerName;
    public int GetScore() => score;
    public int GetHighScore() => hightScore;
    public int GetLevel() => level;
    public int GetHealth() => health;
    #endregion

    #region Setter Funcs
    public void SetName(string name) => playerName = name;

    public void SetScore(int num) => score = num;
    public void AddScore(int amount) => score += amount;
    public void LostScore(int amount) => score -= amount;

    public void SetLevel(int num) => level = num;

    public void AddHealth(int amount) => health += amount;
    public void ReduceHealth(int amount) => health -= amount;
    public void SetHealth(int num) => health = num;

    #endregion
}
