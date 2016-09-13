using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManaController : MonoBehaviour {
    public float currentMana;
    private StatsController _stats;
    public Renderer manaBar;
    public Text manaText;

    public float manaGenerationTime;
    private float currentGenerationTime;

    // Use this for initialization
    void Start () {
        _stats = GetComponent<StatsController>();
        currentMana = _stats.initMana;
        currentGenerationTime = manaGenerationTime;
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

        if (manaGenerationTime > 0)
        {
            currentGenerationTime = currentGenerationTime - Time.deltaTime;
            if (currentGenerationTime <= 0)
            {
                currentMana = currentMana + 1;
                currentGenerationTime = manaGenerationTime;
            }
        }


    }

    public bool decreaseMana(float amount)
    {
        if (currentMana - amount < 0)
        {
            return false;
        }
        else
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
            return true;
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
