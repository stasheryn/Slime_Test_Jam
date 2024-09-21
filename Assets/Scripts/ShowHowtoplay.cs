using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHowtoplay : MonoBehaviour
{
    [SerializeField] private GameObject toHideShow;

    public void ShowHidePanelHowtoplay()
    {
        toHideShow.SetActive(!toHideShow.activeInHierarchy);
    }
}