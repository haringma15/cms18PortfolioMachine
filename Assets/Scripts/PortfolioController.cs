using System.Collections.Generic;
using UnityEngine;

public class PortfolioController : MonoBehaviour
{
    public GameObject project;

    private Object[] res;
    private List<Object> projects = new List<Object>();
    private bool hasProject = false;

    void Start() {
        res = Resources.LoadAll("");
        foreach (Object r in res) if (!r.name.Contains("CollabHistory")) projects.Add(r);
    }

    void Update() {
        if (PlayerPrefs.GetString("project") != "" && !hasProject) {
            foreach (Object p in projects) 
                if (PlayerPrefs.GetString("project") == p.name) 
                    Instantiate(p, project.transform);
            hasProject = true;
        }
        if (PlayerPrefs.GetString("project") == "" && hasProject) {
            hasProject = false;
        }
    }

    public void closeProject() {
        PlayerPrefs.SetString("project", "");
        PlayerPrefs.SetInt("destroyProject", 1);
    } 
}