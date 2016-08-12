﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaController : MonoBehaviour {
    public float currentMana;
    private StatsController _stats;
    public Renderer manaBar;
    public Text manaText;

    // Use this for initialization
    void Start () {
        _stats = GetComponent<StatsController>();
        currentMana = _stats.initMana;
    }

    // Update is called once per frame
    void Update ()
    {

        if (manaBar)
        {
            manaBar.material.SetFloat("_Progress", currentMana / _stats.initMana);
        }

        if (manaText)
        {
            manaText.text = currentMana.ToString();
        }


    }

    public void decreaseMana(float amount)
    {
        currentMana -= amount;
        if (manaBar)
        {
            manaBar.material.SetFloat("_Progress", currentMana / _stats.initMana);
        }
        if (manaText)
        {
            manaText.text = currentMana.ToString();
        }

    }
    public void incrementMana(float amount)
    {
        currentMana += amount;
        if (manaBar)
        {
            manaBar.material.SetFloat("_Progress", currentMana / _stats.initMana);
        }
    }

}
