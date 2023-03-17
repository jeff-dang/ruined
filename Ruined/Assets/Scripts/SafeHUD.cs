using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SafeHUD : MonoBehaviour
{

	public static string nameText = "Ruined Mage";
	public static TextMeshProUGUI hpText;
	public static Slider hpSlider;

	void Start() {
		Debug.Log(MapManager.maxHP);
		this.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = nameText;
		this.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = MapManager.currentHP.ToString();
		hpSlider = this.gameObject.transform.GetChild(1).gameObject.GetComponent<Slider>();
		hpSlider.maxValue = MapManager.maxHP;
		hpSlider.value = MapManager.currentHP;
	}
	//public void SetHUD(Unit unit)
	//{
	//	nameText.text = unit.unitName;
	//	hpText.text = unit.currentHP.ToString();
	//	hpSlider.maxValue = unit.maxHP;
	//	hpSlider.value = unit.currentHP;
	//}
	//public void SetHUD(Unit unit)
	//{
	//	nameText.text = unit.unitName;
	//	hpText.text = unit.currentHP.ToString();
	//	hpSlider.maxValue = unit.maxHP;
	//	hpSlider.value = unit.currentHP;
	//}

	public void SetHP(int hp)
	{
		hpSlider.value = hp;
		hpText = this.gameObject.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
		hpText.text = hp.ToString();
	}

}
