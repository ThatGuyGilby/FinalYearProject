using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject[] heads;
    public GameObject[] hairs;
    public GameObject[] legs;
    public GameObject[] torsos;
    public GameObject[] weapons;

    public GameObject nemesisPrefab;
    private GameObject spawnedNemesis;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DEBUG_SpawnNemesis();
        }
    }

    private void DEBUG_SpawnNemesis()
    {
        if (spawnedNemesis != null)
        {
            Destroy(spawnedNemesis);
        }

        spawnedNemesis = Instantiate(nemesisPrefab);

        NemesisRenderer nr = spawnedNemesis.GetComponent<NemesisRenderer>();

        AddPart(ref nr, heads);
        AddPart(ref nr, torsos);
        AddWeapon(ref nr, weapons);
        AddPart(ref nr, hairs);
        AddPart(ref nr, legs);

        spawnedNemesis.transform.Rotate(new Vector3(0, 180, 0));
    }

    private void AddPart(ref NemesisRenderer nemesis, GameObject[] parts)
    {
        GameObject newPart = parts[Random.Range(0, parts.Length)];
        nemesis.AddItem(newPart);
    }

    private void AddWeapon(ref NemesisRenderer nemesis, GameObject[] parts)
    {
        GameObject newPart = parts[Random.Range(0, parts.Length)];
        nemesis.AddWeapon(newPart);
    }
}
