using System.Collections.Generic;
using UnityEngine;

public class PortfolioController : MonoBehaviour
{
    public GameObject project;
    public int defaultProjectDistance = 1420;
    public int movementSpeed = 20;

    private Object[] res;
    private List<Object> portfolios = new List<Object>();
    private GameObject portfolio;
    private bool hasPortfolio = false;
    private int movement;

    void Start() {
        res = Resources.LoadAll("");
        foreach (Object r in res) if (!r.name.Contains("CollabHistory")) portfolios.Add(r);
    }

    void Update() {
        if (PlayerPrefs.GetString("region") != "" && !hasPortfolio) {
            foreach (Object p in portfolios) if (p.name.Contains(PlayerPrefs.GetString("region"))) portfolio = (GameObject) p;
            Instantiate(portfolio, project.transform);
            hasPortfolio = true;
        }
        if (PlayerPrefs.GetString("region") == "" && hasPortfolio) {
            hasPortfolio = false;
        }
        if (hasPortfolio && movement > 0) { 
            project.transform.localPosition -= new Vector3(defaultProjectDistance/movementSpeed, 0, 0);
            movement -= defaultProjectDistance/movementSpeed;
        }
        if (hasPortfolio && movement < 0) { 
            project.transform.localPosition += new Vector3(defaultProjectDistance/movementSpeed, 0, 0);
            movement += defaultProjectDistance/movementSpeed;
        }  
    }

    public void closeProject() {
        project.transform.localPosition = Vector3.zero;
        PlayerPrefs.SetString("region", "");
        PlayerPrefs.SetInt("destroyProject", 1);
        PlayerPrefs.SetInt("zoomOut", 1);
    } 

    public void increaseActiveProjectIndex() => movement += defaultProjectDistance;
    public void decreaseActiveProjectIndex() => movement -= defaultProjectDistance;
}