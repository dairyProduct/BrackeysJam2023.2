using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator : MonoBehaviour
{
    //static List<string> Titles = new List<string>();
    static List<string> FirstNames = new List<string>();
    //static List<string> LastNames = new List<string>();
    static List<string> Suffixes = new List<string>();
    static List<string> Preffixes = new List<string>();
    public static NameGenerator instance;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        SetupNames();
    }

    public static void SetupNames()
    {
        ConstructFirstNames();
        ConstructPrefixes();
        ConstructSuffixes();
    }

    public string BuildAName()
    {
        return Preffixes[Random.Range(0, Preffixes.Count)] + " " + FirstNames[Random.Range(0, FirstNames.Count)] + " " + Suffixes[Random.Range(0, Suffixes.Count)];
    }

    public static void ConstructPrefixes()
    {
        Preffixes.Add("Wealthy");
        Preffixes.Add("Rich");
        Preffixes.Add("Snobby");
        Preffixes.Add("Swanky");
        Preffixes.Add("Ballin'");
        Preffixes.Add("Blue Blooded");
    }

    public static void ConstructFirstNames()
    {
        FirstNames.Add("Alfred");
        FirstNames.Add("Willard");
        FirstNames.Add("Scotty");
        FirstNames.Add("Milford");
        FirstNames.Add("Hubert");
    }

    public static void ConstructSuffixes()
    {
        Suffixes.Add("The Torturuer");
        Suffixes.Add("The Feared");
        Suffixes.Add("The Vile");
        Suffixes.Add("The Terrible");
        Suffixes.Add("The Dubious");
    }

}
