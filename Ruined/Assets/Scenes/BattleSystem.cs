using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public string level;

	public GameObject playerPrefab;
	public GameObject enemyPrefab;  //enemy loop here
	public GameObject enemy2Prefab;

	public Transform playerStart;
	public Transform enemyStart;   //enemy loop here
	public Transform enemy2Start;

    //public GameObject Grid;
    public GameObject EnemyGrid;

	Unit playerUnit;
	//Unit enemyUnit;  //enemy loop here
	//Unit enemy2Unit;
    private List<EnemyData> enemyDataList;
    private List<Unit> enemyUnits;


    public TextMeshProUGUI dialogueText;

	public BattleHUD playerHUD;
	//public BattleHUD enemyHUD; //enemy loop here
	//public BattleHUD enemy2HUD;

	public BattleState state;

	public GameObject rewardScreen;
	public GameObject lostScreen;

	// Start is called before the first frame update
	void Start()
	{
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

    //ienumerator nextenemyturn(string nextenemy) //enemy loop here
    //   {
    //	if (nextenemy == "enemy")
    //       {
    //		return enemyturn();
    //       }
    //	else if (nextenemy == "enemy2") {
    //		return enemy2turn();
    //       }
    //       else
    //       {
    //		debug.log("hello");  //this failsafe catch remove after
    //		return setupbattle();
    //       }
    //   }
    //implement last enumerator that just starts player turn()
    IEnumerator SetupBattle()
	{
		//GameObject playerGO = Instantiate(playerPrefab, playerStart);
		playerUnit = playerPrefab.GetComponent<Unit>();

        enemyDataList = EnemyDataManager.getEnemyData(level);
        enemyUnits = new List<Unit>();

        //GameObject enemyGO = Instantiate(enemyPrefab, enemyStart);  //bilal enemy script
		//enemyUnit = enemyGO.GetComponent<Unit>();

		//GameObject enemy2GO = Instantiate(enemy2Prefab, enemy2Start);
		//enemy2Unit = enemy2GO.GetComponent<Unit>();

        for (int i = 0; i < enemyDataList.Count; i++)
        {
            Unit enemy = new Unit();
            enemy.currentHP = enemyDataList[i].HP;
            enemy.maxHP = enemyDataList[i].HP;
            enemy.isStunned = false;
            enemy.unitName = enemyDataList[i].Name;
			enemy.location = enemyDataList[i].location;
			enemy.damage = enemyDataList[i].Damage;
			enemyUnits.Add(enemy);
            EnemyGrid.transform.GetChild(i).gameObject.SetActive(true);
            EnemyGrid.transform.GetChild(i).gameObject.GetComponent<BattleHUD>().SetHUD(enemy);
        }

		dialogueText.text = "A wild " + enemyUnits[0].unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);   
		//enemyHUD.SetHUD(enemyUnit);    //enemy loop here
		//enemy2HUD.SetHUD(enemy2Unit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}


	IEnumerator EnemyTurn(int enemyNum)    //enemy loop here + enemyturn2
	{
        Unit enemyUnit = enemyUnits[enemyNum];
        if (enemyUnit.isStunned == true)
        {
            dialogueText.text = enemyUnits[enemyNum].unitName + " is stunned!";
            yield return new WaitForSeconds(1f);
            enemyUnits[enemyNum].isStunned = false;
            state = BattleState.ENEMYTURN; //make this next turn function
            if (enemyNum + 1 < enemyUnits.Count)
                yield return StartCoroutine(EnemyTurn(enemyNum+1));
            //here would call next enemy turn
        }
        else
        {
            dialogueText.text = enemyUnits[enemyNum].unitName + " attacks!";

            yield return new WaitForSeconds(1f);

            bool isDead = playerUnit.TakeDamage(enemyUnits[enemyNum].damage);

            playerHUD.SetHP(playerUnit.currentHP);

            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                state = BattleState.LOST;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                if (enemyNum + 1 < enemyUnits.Count)
                    yield return StartCoroutine(EnemyTurn(enemyNum+1));
            }
        }
    }

	//IEnumerator Enemy2Turn()  //remove this after enemy turn loop
	//{
	//	if (enemyUnit.isStunned == true)
	//	{
	//		dialogueText.text = enemy2Unit.unitName + " is stunned!";
	//		yield return new WaitForSeconds(1f);
	//		enemyUnit.isStunned = false;
	//		state = BattleState.PLAYERTURN; //make this next turn function
	//		PlayerTurn();
	//	}
	//	else
	//	{
	//		dialogueText.text = enemy2Unit.unitName + " attacks!";

	//		yield return new WaitForSeconds(1f);

	//		bool isDead = playerUnit.TakeDamage(enemy2Unit.damage);

	//		playerHUD.SetHP(playerUnit.currentHP);

	//		yield return new WaitForSeconds(1f);

	//		if (isDead)
	//		{
	//			state = BattleState.LOST;
	//			EndBattle();
	//		}
	//		else
	//		{
	//			state = BattleState.PLAYERTURN;
	//			PlayerTurn();
	//		}
	//	}


	//}

	void EndBattle()
	{

        for (int i = 0; i < enemyUnits.Count; i++)
        {
            GameObject.Find(enemyUnits[i].unitName).gameObject.SetActive(false);
        }


		if (state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
			rewardScreen.SetActive(true);
			int curLev = PlayerPrefs.GetInt("areaLevel");
			curLev += 1;
			PlayerPrefs.SetInt("areaLevel", curLev);
		}
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
			PlayerPrefs.SetString("areaName", "start");
        	PlayerPrefs.SetInt("areaLevel", 1);
			lostScreen.SetActive(true);

		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerAttack()
	{
		state = BattleState.ENEMYTURN;
        //check if enemy is in pattern and can just make another button that hard codes attack one  //enemy loop here
        //bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        //bool isDead2 = enemy2Unit.TakeDamage(playerUnit.damage);
        //List<bool> deadUnits = new List<bool>();
        bool foundDead = false;

        for (int i = 0; i < enemyUnits.Count; i++)
        {
            if (enemyUnits[i].TakeDamage(playerUnit.damage))
                foundDead = true;
        }


        for (int i = 0; i < enemyDataList.Count; i++)
        {
            EnemyGrid.transform.GetChild(i).gameObject.GetComponent<BattleHUD>().SetHP(enemyUnits[i].currentHP);  //enemy loop here
            //enemy2HUD.SetHP(enemy2Unit.currentHP);
        }

        dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);


        if (foundDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			yield return StartCoroutine(EnemyTurn(0));
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
	}

	IEnumerator PlayerWholeAttack()
	{
		state = BattleState.ENEMYTURN;
		//check if enemy is in pattern and can just make another button that hard codes attack one  //enemy loop here
		//bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		//bool isDead2 = enemy2Unit.TakeDamage(playerUnit.damage);
		//List<bool> deadUnits = new List<bool>();
		bool foundDead = false;

		for (int i = 0; i < enemyUnits.Count; i++)
		{
			if (enemyUnits[i].TakeDamage(2))
				foundDead = true;
		}


		for (int i = 0; i < enemyDataList.Count; i++)
		{
			EnemyGrid.transform.GetChild(i).gameObject.GetComponent<BattleHUD>().SetHP(enemyUnits[i].currentHP);  //enemy loop here
																												  //enemy2HUD.SetHP(enemy2Unit.currentHP);
		}

		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);


		if (foundDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			yield return StartCoroutine(EnemyTurn(0));
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}
	}

	IEnumerator PlayerLineAttack()
	{
		state = BattleState.ENEMYTURN;
		//check if enemy is in pattern and can just make another button that hard codes attack one  //enemy loop here
		//bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		//bool isDead2 = enemy2Unit.TakeDamage(playerUnit.damage);
		//List<bool> deadUnits = new List<bool>();
		bool foundDead = false;

		for (int i = 0; i < enemyUnits.Count; i++)
		{
			if (enemyUnits[i].location == 1 || enemyUnits[i].location == 4 || enemyUnits[i].location == 7)
				if (enemyUnits[i].TakeDamage(3))
					foundDead = true;
		}


		for (int i = 0; i < enemyDataList.Count; i++)
		{
			EnemyGrid.transform.GetChild(i).gameObject.GetComponent<BattleHUD>().SetHP(enemyUnits[i].currentHP);  //enemy loop here
																												  //enemy2HUD.SetHP(enemy2Unit.currentHP);
		}

		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);


		if (foundDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			yield return StartCoroutine(EnemyTurn(0));
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}
	}

	IEnumerator PlayerHorizontalAttack()
	{
		state = BattleState.ENEMYTURN;
		//check if enemy is in pattern and can just make another button that hard codes attack one  //enemy loop here
		//bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		//bool isDead2 = enemy2Unit.TakeDamage(playerUnit.damage);
		//List<bool> deadUnits = new List<bool>();
		bool foundDead = false;

		for (int i = 0; i < enemyUnits.Count; i++)
		{
			if (enemyUnits[i].location == 3 || enemyUnits[i].location == 4 || enemyUnits[i].location == 5)
				if (enemyUnits[i].TakeDamage(3))
					foundDead = true;
		}


		for (int i = 0; i < enemyDataList.Count; i++)
		{
			EnemyGrid.transform.GetChild(i).gameObject.GetComponent<BattleHUD>().SetHP(enemyUnits[i].currentHP);  //enemy loop here
																												  //enemy2HUD.SetHP(enemy2Unit.currentHP);
		}

		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);


		if (foundDead)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			yield return StartCoroutine(EnemyTurn(0));
			state = BattleState.PLAYERTURN;
			PlayerTurn();
		}
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
        yield return StartCoroutine(EnemyTurn(0));
        state = BattleState.PLAYERTURN;
        PlayerTurn();//nextEnemyTurn("enemy"));
    }

	IEnumerator PlayerStun()
	{
		//check if enemy is in squares, also //stuns only one enemy
        int stunnedEnemyNum=0;
        for (int i = 0; i < enemyUnits.Count; i++)
        {
            if (!enemyUnits[i].isStunned)
            {
                stunnedEnemyNum = i;
                enemyUnits[i].isStunned = true;
                break;
            }
        }
		//enemyUnit.isStunned = true;

		dialogueText.text = "You stunned " + enemyUnits[stunnedEnemyNum].unitName;

		yield return new WaitForSeconds(2f);
		

		state = BattleState.ENEMYTURN;
        yield return StartCoroutine(EnemyTurn(stunnedEnemyNum));
        state = BattleState.PLAYERTURN;
        PlayerTurn();// nextEnemyTurn("enemy"));
    }

	public void OnWholeAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerWholeAttack());
	}

	public void OnLineAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerLineAttack());
	}

	public void OnHorizontalAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHorizontalAttack());
	}

	public void OnHealButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerHeal());
	}

	public void OnStunButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerStun());
	}
}