using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BloodController : MonoBehaviour {
    public float currentBlood;
    private StatsController _stats;
    public Renderer bloodBar;
    public Text bloodText;

    // Use this for initialization
    void Start()
    {
        _stats = GetComponent<StatsController>();
        currentBlood = _stats.initBlood;
        if (bloodBar)
        {
            bloodBar.material.SetFloat("_Progress", currentBlood / _stats.initBlood);
        }
        if(bloodText)
        {
            bloodText.text = currentBlood.ToString();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (bloodBar)
        {
            bloodBar.material.SetFloat("_Progress", currentBlood / _stats.initBlood);
        }
        if (bloodText)
        {
            bloodText.text = currentBlood.ToString();
        }

    }

    public void decreaseBlood(float amount)
    {
        currentBlood -= amount;
        if (bloodBar)
        {
            bloodBar.material.SetFloat("_Progress", currentBlood / _stats.initBlood);
        }
    }
    public void incrementBlood(float amount)
    {
        currentBlood += amount;
        if (bloodBar)
        {
            bloodBar.material.SetFloat("_Progress", currentBlood / _stats.initBlood);
        }
    }

}
