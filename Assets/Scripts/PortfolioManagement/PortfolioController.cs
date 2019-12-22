using System.Collections.Generic;
using UnityEngine;

public class PortfolioController : MonoBehaviour
{
    public GameObject project;

    private Object[] res;
    private List<Object> projects = new List<Object>();
    private List<Object> studentProjects = new List<Object>();
    private bool hasProject = false;

    void Start() {
        res = Resources.LoadAll("");
        foreach (Object r in res) if (!r.name.Contains("CollabHistory")) projects.Add(r);
    }

    void Update() {
        if (PlayerPrefs.GetString("region") != "" && !hasProject) {
            foreach (Object p in projects) if (p.name.Contains(PlayerPrefs.GetString("region"))) studentProjects.Add(p);            
            Instantiate(studentProjects[0], project.transform);
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
}