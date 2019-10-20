using System;

[Serializable]
public class Player
{
    public int Id;
    public string FirstName;
    public string LastName;
    public int Score;

    public Player(int id, string firstName, string lastName, int score)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Score = score;
    }
}
