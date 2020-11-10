using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NemesisRenderer : MonoBehaviour
{
    public NemesisData data;
    public Transform characterRoot;
    const string namePrefix = "Set Character_";

    public GameObject rightHand;
    public GameObject leftHand;

    private GameObject weapon;

    public void AddItem(GameObject item)
    {
        GameObject itemInstance = GameObject.Instantiate(item);
        itemInstance.name = itemInstance.name.Substring(0, itemInstance.name.Length - "(Clone)".Length);
        RemoveAnimator(itemInstance);
        ParentObjectAndBones(itemInstance);
    }

    public void AddWeapon(GameObject item)
    {
        GameObject itemInstance = GameObject.Instantiate(item);
        itemInstance.name = itemInstance.name.Substring(0, itemInstance.name.Length - "(Clone)".Length);

        itemInstance.transform.SetParent(rightHand.transform);

        itemInstance.transform.localPosition = Vector3.zero;
        itemInstance.transform.localRotation = Quaternion.identity;
        itemInstance.transform.localScale = Vector3.one;

        weapon = itemInstance;
    }

    public Transform GetRoot()
    {
        Transform root;
        if (characterRoot == null)
        {
            root = transform;
        }
        else
        {
            root = characterRoot;
        }
        return root;
    }

    public void MatchTransform(Transform obj, Transform target)
    {
        obj.position = target.position;
        obj.rotation = target.rotation;
    }

    public Transform[] GetAllCharacterChildren()
    {
        Transform root = GetRoot();
        Transform[] allCharacterChildren = root.GetComponentsInChildren<Transform>();

        /*List<Transform> allCharacterChildren_List = new List<Transform>();

        for(int i = 0; i < allCharacterChildren.Length; i++){
            if(allCharacterChildren[i].GetComponent<SkinnedMeshRenderer>() != null || allCharacterChildren[i].GetComponent<Animator>() != null)
            {
                continue;
            }
            allCharacterChildren_List.Add(allCharacterChildren[i]);
        }

        allCharacterChildren = allCharacterChildren_List.ToArray();*/

        return allCharacterChildren;
    }

    public void ParentObjectAndBones(GameObject itemInstance)
    {
        Transform[] allCharacterChildren = GetAllCharacterChildren();
        Transform[] allItemChildren = itemInstance.GetComponentsInChildren<Transform>();
        itemInstance.transform.position = transform.position;
        itemInstance.transform.parent = transform;

        string[] allItemChildren_NewNames = new string[allItemChildren.Length];

        for (int i = 0; i < allItemChildren.Length; i++)
        {
            //Match and parent bones
            for (int n = 0; n < allCharacterChildren.Length; n++)
            {
                if (allItemChildren[i].name == allCharacterChildren[n].name)
                {
                    MatchTransform(allItemChildren[i], allCharacterChildren[n]);
                    allItemChildren[i].parent = allCharacterChildren[n];
                }
            }

            //Rename
            allItemChildren_NewNames[i] = allItemChildren[i].name;

            if (!allItemChildren[i].name.Contains(namePrefix))
            {
                allItemChildren_NewNames[i] = namePrefix + allItemChildren[i].name;
            }

            if (!allItemChildren[i].name.Contains(itemInstance.name))
            {
                allItemChildren_NewNames[i] += "_" + itemInstance.name;
            }
        }

        for (int i = 0; i < allItemChildren.Length; i++)
        {
            allItemChildren[i].name = allItemChildren_NewNames[i];
        }
    }

    public void RemoveAnimator(GameObject item)
    {
        Animator animator = item.GetComponent<Animator>();
        if (animator != null)
        {
            DestroyImmediate(animator);
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("AHHHHHHHHHHHHH HE FUCKING POKED ME");
        Camera.main.GetComponent<MapCamera>().RefocusCamera(transform.parent.position + new Vector3(0.5f, 1, -2));
        Camera.main.GetComponent<MapCamera>().focus = data;
    }
}
