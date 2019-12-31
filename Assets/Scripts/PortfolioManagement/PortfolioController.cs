using System.Collections.Generic;
using UnityEngine;

public class PortfolioController : MonoBehaviour
{
    public GameObject project;

    private Object[] res;
    private List<Object> portfolios = new List<Object>();
    private GameObject portfolio;
    private bool hasProject = false;

    void Start() {
        res = Resources.LoadAll("");
        foreach (Object r in res) if (!r.name.Contains("CollabHistory")) portfolios.Add(r);
    }

    void Update() {
        if (PlayerPrefs.GetString("region") != "" && !hasProject) {
            foreach (Object p in portfolios) if (p.name.Contains(PlayerPrefs.GetString("region"))) portfolio = (GameObject) p;
            Instantiate(portfolio, project.transform);
            hasProject = true;
        }
        if (PlayerPrefs.GetString("region") == "" && hasProject) {
            hasProject = false;
        }
    }

    public void closeProject() {
        PlayerPrefs.SetString("region", "");
        PlayerPrefs.SetInt("destroyProject", 1);
        PlayerPrefs.SetInt("zoomOut", 1);
    } 

    public void increaseActiveProjectIndex() {
    }

    public void decreaseActiveProjectIndex() {
    }
}