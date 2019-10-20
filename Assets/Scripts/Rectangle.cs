using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rectangle : MonoBehaviour
{
    public int Place
    {
        set
        {
            if (value < 0) value = 0;
            placeComp.text = value.ToString();
            place = value;
        }
    }

    public string FirstName
    {
        set
        {
            if (value == "") value = "FirstName";
            firstNameComp.text = value;
            firstName = value;
        }
    }

    public string LastName
    {
        set
        {
            if (value == "") value = "LastName";
            lastNameComp.text = value;
            lastName = value;
        }
    }

    public int Score
    {
        set
        {
            if (value < 0) value = 0;
            scoreComp.text = value.ToString();
            score = value;
        }
    }

    [SerializeField] private TextMeshProUGUI placeComp;
    [SerializeField] private TextMeshProUGUI firstNameComp;
    [SerializeField] private TextMeshProUGUI lastNameComp;
    [SerializeField] private TextMeshProUGUI scoreComp;

    [field:Space]
    [SerializeField] private int place;
    [SerializeField] private string firstName;
    [SerializeField] private string lastName;
    [SerializeField] private int score;

    private void OnValidate()
    {
        Place = place;
        FirstName = firstName;
        LastName = lastName;
        Score = score;
    }

    public void RefreshInfo(Player player)
    {
        FirstName = player.FirstName;
        LastName = player.LastName;
        Score = player.Score;
    }
}
