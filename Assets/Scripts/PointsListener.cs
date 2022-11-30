using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsListener : MonoBehaviour
{
    public TextMeshProUGUI points;

    // Start is called before the first frame update
    void Start()
    {
        //BM: Points link to event system
        EventSystem.Instance.OnPointsChange += OnPointsChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnPointsChange(int pts)
    {
        if(pts != 0)
        {
            points.text = "" + pts;
        }        
    }

    private void OnDestroy()
    {
        EventSystem.Instance.OnPointsChange -= OnPointsChange;
    }
}
