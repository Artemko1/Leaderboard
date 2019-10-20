using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class NameGenerator
{
    private readonly string[] maleNames = File.ReadAllLines(Path.Combine(Application.dataPath, "Editor Default Resources/МужИмена.txt"));
    private readonly string[] femaleNames = File.ReadAllLines(Path.Combine(Application.dataPath, "Editor Default Resources/ЖенИмена.txt"));
    private readonly string[] maleLastNames = File.ReadAllLines(Path.Combine(Application.dataPath, "Editor Default Resources/МужФамилии.txt"));
    private readonly string[] femaleLastNames = File.ReadAllLines(Path.Combine(Application.dataPath, "Editor Default Resources/ЖенФамилии.txt"));

    public void GenerateName(out string name, out string surname)
    {
        if (Random.Range(0,2) == 0)
        {
            name = maleNames[Random.Range(0,maleNames.Length)]; 
            surname = maleLastNames[Random.Range(0, maleLastNames.Length)];
        }
        else
        {
            name = femaleNames[Random.Range(0,femaleNames.Length)];
            surname = femaleLastNames[Random.Range(0, femaleLastNames.Length)];
        }
        
    }
}
