using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {
    public float timeLeft;
    private float cooldown;
    private Image cooldownImage;
	// Use this for initialization
	void Start () {
        cooldownImage = GetComponent<Image>();
	}
	public void setCooldown(float pCooldown)
    {
        cooldown = pCooldown;
        timeLeft = pCooldown;
    }
    public bool isCooldown()
    {
        if (timeLeft <= 0)
        {
            return false;
        }else
        {
            return true;
        }
    }
	// Update is called once per frame
	void Update () {
        if (timeLeft > 0)
        {
            timeLeft = timeLeft - Time.deltaTime;
            cooldownImage.fillAmount = timeLeft / cooldown;
        }
        else
        {
            cooldownImage.fillAmount = 0;
        }
    }
}
