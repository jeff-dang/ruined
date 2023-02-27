using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

	public GameObject playerPrefab;
	public GameObject enemyPrefab;
	public GameObject enemy2Prefab;

	public Transform playerStart;
	public Transform enemyStart;
	public Transform enemy2Start;

	Unit playerUnit;
	Unit enemyUnit;
	Unit enemy2Unit;

	public TextMeshProUGUI dialogueText;

	public BattleHUD playerHUD;
	public BattleHUD enemyHUD;
	public BattleHUD enemy2HUD;

	public BattleState state;

	public GameObject rewardScreen;

	// Start is called before the first frame update
	void Start()
	{
		state = BattleState.START;
		StartCoroutine(SetupBattle());
	}

	IEnumerator nextEnemyTurn(string nextEnemy)
    {
		if (nextEnemy == "enemy")
        {
			return EnemyTurn();
        }
		else if (nextEnemy == "enemy2") {
			return Enemy2Turn();
        }
        else
        {
			Debug.Log("hello");
			return SetupBattle();
        }
    }
	//implement last enumerator that just starts player turn()
	IEnumerator SetupBattle()
	{
		GameObject playerGO = Instantiate(playerPrefab, playerStart);
		playerUnit = playerGO.GetComponent<Unit>();

		GameObject enemyGO = Instantiate(enemyPrefab, enemyStart);
		enemyUnit = enemyGO.GetComponent<Unit>();

		GameObject enemy2GO = Instantiate(enemy2Prefab, enemy2Start);
		enemy2Unit = enemy2GO.GetComponent<Unit>();

		dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

		playerHUD.SetHUD(playerUnit);
		enemyHUD.SetHUD(enemyUnit);
		enemy2HUD.SetHUD(enemy2Unit);

		yield return new WaitForSeconds(2f);

		state = BattleState.PLAYERTURN;
		PlayerTurn();
	}


	IEnumerator EnemyTurn()
	{
		if (enemyUnit.isStunned == true) 
        {
			dialogueText.text = enemyUnit.unitName + " is stunned!";
			yield return new WaitForSeconds(1f);
			enemyUnit.isStunned = false;
			state = BattleState.ENEMYTURN; //make this next turn function
			StartCoroutine(nextEnemyTurn("enemy2")); ;  //here would call next enemy turn
		}
        else
        {
			dialogueText.text = enemyUnit.unitName + " attacks!";

			yield return new WaitForSeconds(1f);

			bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

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
				StartCoroutine(nextEnemyTurn("enemy2")); ;
			}
		}
		

	}

	IEnumerator Enemy2Turn()
	{
		if (enemyUnit.isStunned == true)
		{
			dialogueText.text = enemy2Unit.unitName + " is stunned!";
			yield return new WaitForSeconds(1f);
			enemyUnit.isStunned = false;
			state = BattleState.PLAYERTURN; //make this next turn function
			PlayerTurn();
		}
		else
		{
			dialogueText.text = enemy2Unit.unitName + " attacks!";

			yield return new WaitForSeconds(1f);

			bool isDead = playerUnit.TakeDamage(enemy2Unit.damage);

			playerHUD.SetHP(playerUnit.currentHP);

			yield return new WaitForSeconds(1f);

			if (isDead)
			{
				state = BattleState.LOST;
				EndBattle();
			}
			else
			{
				state = BattleState.PLAYERTURN;
				PlayerTurn();
			}
		}


	}

	void EndBattle()
	{
		if (state == BattleState.WON)
		{
			dialogueText.text = "You won the battle!";
			rewardScreen.SetActive(true);

		}
		else if (state == BattleState.LOST)
		{
			dialogueText.text = "You were defeated.";
		}
	}

	void PlayerTurn()
	{
		dialogueText.text = "Choose an action:";
	}

	IEnumerator PlayerAttack()
	{
		state = BattleState.ENEMYTURN;
		//check if enemy is in pattern and can just make another button that hard codes attack one
		bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
		bool isDead2 = enemy2Unit.TakeDamage(playerUnit.damage);

		enemyHUD.SetHP(enemyUnit.currentHP);
		enemy2HUD.SetHP(enemy2Unit.currentHP);
		dialogueText.text = "The attack is successful!";

		yield return new WaitForSeconds(2f);

		if (isDead || isDead2)
		{
			state = BattleState.WON;
			EndBattle();
		}
		else
		{
			state = BattleState.ENEMYTURN;
			StartCoroutine(nextEnemyTurn("enemy"));
		}
	}

	IEnumerator PlayerHeal()
	{
		playerUnit.Heal(5);

		playerHUD.SetHP(playerUnit.currentHP);
		dialogueText.text = "You feel renewed strength!";

		yield return new WaitForSeconds(2f);

		state = BattleState.ENEMYTURN;
		StartCoroutine(nextEnemyTurn("enemy"));
	}

	IEnumerator PlayerStun()
	{
		//check if enemy is in squares, also //stuns only one enemy
		enemyUnit.isStunned = true;

		dialogueText.text = "You stunned " + enemyUnit.unitName;

		yield return new WaitForSeconds(2f);
		

		state = BattleState.ENEMYTURN;
		StartCoroutine(nextEnemyTurn("enemy"));
	}

	public void OnAttackButton()
	{
		if (state != BattleState.PLAYERTURN)
			return;

		StartCoroutine(PlayerAttack());
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