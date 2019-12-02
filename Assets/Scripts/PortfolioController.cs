using UnityEngine;

public class PortfolioController : MonoBehaviour
{
    public GameObject project;

    private Object[] projects;

    void Start() {
        projects = Resources.LoadAll("");
        foreach (Object p in projects) Debug.Log(p.name);
    }

    void Update() {
        if (PlayerPrefs.GetString("project") != "") {
            foreach (Object p in projects) 
                if (PlayerPrefs.GetString("project") == p.name) 
                    Instantiate(p, project.transform);
        }
    }
}