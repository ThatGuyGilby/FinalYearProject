using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemesisMap : MonoBehaviour
{
    public Transform[] captains;
    public Transform[] warchiefs;
    public Transform[] overlords;

    private List<GameObject> nemRens;

    public void Awake()
    {
        nemRens = new List<GameObject>();
    }

    public void Start()
    {
        GenerateNewMap();
    }

    public void GenerateNewMap()
    {
        GameManager.Instance.PurgeNemesisSystem();

        if (nemRens.Count > 0)
        {
            foreach(GameObject renderer in nemRens)
            {
                Destroy(renderer);
            }
        }

        foreach (Transform point in captains)
        {
            GameObject nemesis = GameManager.Instance.GenerateNemesis(NemesisType.Captain);
            nemesis.transform.SetParent(point);

            nemesis.transform.localPosition = Vector3.zero - new Vector3(0, 0.5f, 0);
            nemesis.transform.localRotation = Quaternion.identity;
            nemesis.transform.localScale = Vector3.one;

            nemesis.transform.Rotate(new Vector3(0, 180, 0));
            nemRens.Add(nemesis);
        }

        foreach (Transform point in warchiefs)
        {
            GameObject nemesis = GameManager.Instance.GenerateNemesis(NemesisType.Warchief);
            nemesis.transform.SetParent(point);

            nemesis.transform.localPosition = Vector3.zero - new Vector3(0, 0.5f, 0);
            nemesis.transform.localRotation = Quaternion.identity;
            nemesis.transform.localScale = Vector3.one;

            nemesis.transform.Rotate(new Vector3(0, 180, 0));
            nemRens.Add(nemesis);
        }

        foreach (Transform point in overlords)
        {
            GameObject nemesis = GameManager.Instance.GenerateNemesis(NemesisType.Overlord);
            nemesis.transform.SetParent(point);

            nemesis.transform.localPosition = Vector3.zero - new Vector3(0, 0.5f, 0);
            nemesis.transform.localRotation = Quaternion.identity;
            nemesis.transform.localScale = Vector3.one;

            nemesis.transform.Rotate(new Vector3(0, 180, 0));
            nemRens.Add(nemesis);
        }
    }

    public void GenerateMapFromSystem()
    {
        if (nemRens.Count > 0)
        {
            foreach (GameObject renderer in nemRens)
            {
                Destroy(renderer);
            }
        }

        for (int i = 0; i < captains.Length; i++)
        {
            GameObject nemesis = GameManager.Instance.GenerateNemesis(GameManager.Instance.system.captains[i]);
            nemesis.transform.SetParent(captains[i]);
            nemesis.GetComponent<NemesisRenderer>().data = GameManager.Instance.system.captains[i];

            nemesis.transform.localPosition = Vector3.zero - new Vector3(0, 0.5f, 0);
            nemesis.transform.localRotation = Quaternion.identity;
            nemesis.transform.localScale = Vector3.one;

            nemesis.transform.Rotate(new Vector3(0, 180, 0));
            nemRens.Add(nemesis);
        }

        for (int i = 0; i < warchiefs.Length; i++)
        {
            GameObject nemesis = GameManager.Instance.GenerateNemesis(GameManager.Instance.system.warchiefs[i]);
            nemesis.transform.SetParent(warchiefs[i]);
            nemesis.GetComponent<NemesisRenderer>().data = GameManager.Instance.system.warchiefs[i];

            nemesis.transform.localPosition = Vector3.zero - new Vector3(0, 0.5f, 0);
            nemesis.transform.localRotation = Quaternion.identity;
            nemesis.transform.localScale = Vector3.one;

            nemesis.transform.Rotate(new Vector3(0, 180, 0));
            nemRens.Add(nemesis);
        }

        for (int i = 0; i < overlords.Length; i++)
        {
            GameObject nemesis = GameManager.Instance.GenerateNemesis(GameManager.Instance.system.overlords[i]);
            nemesis.transform.SetParent(overlords[i]);
            nemesis.GetComponent<NemesisRenderer>().data = GameManager.Instance.system.overlords[i];

            nemesis.transform.localPosition = Vector3.zero - new Vector3(0, 0.5f, 0);
            nemesis.transform.localRotation = Quaternion.identity;
            nemesis.transform.localScale = Vector3.one;

            nemesis.transform.Rotate(new Vector3(0, 180, 0));
            nemRens.Add(nemesis);
        }
    }
}
