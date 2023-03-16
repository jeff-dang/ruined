using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{

	public TextMeshProUGUI nameText;
	public TextMeshProUGUI hpText;
	public Slider hpSlider;

	public void SetHUD(Unit unit)
	{
		nameText.text = unit.unitName;
		hpText.text = unit.currentHP.ToString();
		hpSlider.maxValue = unit.maxHP;
		hpSlider.value = unit.currentHP;
	}

	public void SetHP(int hp)
	{
		hpSlider.value = hp;
		hpText.text = hp.ToString();
	}

}
