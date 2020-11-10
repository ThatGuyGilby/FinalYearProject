using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] maleHeads;
    public GameObject[] maleHairs;
    public GameObject[] maleLegs;
    public GameObject[] maleTorsos;

    public GameObject[] femaleHeads;
    public GameObject[] femaleHairs;
    public GameObject[] femaleLegs;
    public GameObject[] femaleTorsos;

    public GameObject[] weapons;

    public GameObject maleNemesisPrefab;
    public GameObject femaleNemesisPrefab;
    private GameObject spawnedNemesis;

    public NemesisSystem system;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);

        //Random.InitState(0);
        Random.InitState(Mathf.RoundToInt(Time.time));

        system = new NemesisSystem();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveSystem();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadSystem();
            FindObjectOfType<NemesisMap>().GenerateMapFromSystem();
        }
    }

    private void AddPart(ref NemesisRenderer nemesis, GameObject[] parts)
    {
        GameObject newPart = parts[Random.Range(0, parts.Length)];
        nemesis.AddItem(newPart);
        Debug.Log("Added part");
    }

    private void AddWeapon(ref NemesisRenderer nemesis, GameObject[] parts)
    {
        GameObject newPart = parts[Random.Range(0, parts.Length)];
        nemesis.AddWeapon(newPart);
        Debug.Log("Added weapon");
    }

    public GameObject GenerateNemesis(NemesisType type)
    {
        GameObject nemesis = null;
        NemesisRenderer nr = null;

        NemesisData nemesisData = new NemesisData();
        Random.State prevState = Random.state;
        Random.InitState(nemesisData.PID);

        switch (nemesisData.gender)
        {
            case 0:
                nemesis = Instantiate(maleNemesisPrefab);
                nr = nemesis.GetComponent<NemesisRenderer>();
                AddPart(ref nr, maleHeads);
                AddPart(ref nr, maleTorsos);
                AddWeapon(ref nr, weapons);
                AddPart(ref nr, maleHairs);
                AddPart(ref nr, maleLegs);
                break;
            case 1:
                nemesis = Instantiate(femaleNemesisPrefab);
                nr = nemesis.GetComponent<NemesisRenderer>();
                AddPart(ref nr, femaleHeads);
                AddPart(ref nr, femaleTorsos);
                AddWeapon(ref nr, weapons);
                AddPart(ref nr, femaleHairs);
                AddPart(ref nr, femaleLegs);
                break;
        }

        switch (type)
        {
            case NemesisType.Captain:
                system.captains.Add(nemesisData);
                break;
            case NemesisType.Warchief:
                system.warchiefs.Add(nemesisData);
                break;
            case NemesisType.Overlord:
                system.overlords.Add(nemesisData);
                break;
        }

        nr.data = nemesisData;

        Random.state = prevState;

        return nemesis;
    }

    public GameObject GenerateNemesis(NemesisData data)
    {
        GameObject nemesis = null;
        NemesisRenderer nr = null;
        
        Random.State prevState = Random.state;
        Random.InitState(data.PID);

        switch (data.gender)
        {
            case 0:
                nemesis = Instantiate(maleNemesisPrefab);
                nr = nemesis.GetComponent<NemesisRenderer>();
                AddPart(ref nr, maleHeads);
                AddPart(ref nr, maleTorsos);
                AddWeapon(ref nr, weapons);
                AddPart(ref nr, maleHairs);
                AddPart(ref nr, maleLegs);
                break;
            case 1:
                nemesis = Instantiate(femaleNemesisPrefab);
                nr = nemesis.GetComponent<NemesisRenderer>();
                AddPart(ref nr, femaleHeads);
                AddPart(ref nr, femaleTorsos);
                AddWeapon(ref nr, weapons);
                AddPart(ref nr, femaleHairs);
                AddPart(ref nr, femaleLegs);
                break;
        }

        nr.data = data;

        Random.state = prevState;

        return nemesis;
    }

    public void GenerateNewMap()
    {
        FindObjectOfType<NemesisMap>().GenerateNewMap();
    }

    public void PurgeNemesisSystem()
    {
        system.Purge();
    }

    public static string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);

    public void SaveSystem()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(path + "/NemesisSave.txt", FileMode.Create);

        NemesisSystem data = system;

        bf.Serialize(stream, data);
        stream.Close();
    }

    public void LoadSystem()
    {
        if (File.Exists(path + "/NemesisSave.txt"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path + "/NemesisSave.txt", FileMode.Open);

            NemesisSystem data = bf.Deserialize(stream) as NemesisSystem;
            stream.Close();

            system = data;
        }
    }
}