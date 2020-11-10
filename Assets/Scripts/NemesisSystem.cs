using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NemesisSystem
{
    public List<NemesisData> captains;
    public List<NemesisData> warchiefs;
    public List<NemesisData> overlords;

    public NemesisSystem()
    {
        captains = new List<NemesisData>();
        warchiefs = new List<NemesisData>();
        overlords = new List<NemesisData>();
    }

    public void Purge()
    {
        captains = new List<NemesisData>();
        warchiefs = new List<NemesisData>();
        overlords = new List<NemesisData>();
    }
}

public enum NemesisType
{
    Captain,
    Warchief,
    Overlord
}