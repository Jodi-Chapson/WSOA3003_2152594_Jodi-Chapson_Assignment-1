using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// Reference for the state machine/combat system from Brackey's "Turn-Based Combat in Unity" https://www.youtube.com/watch?v=_1pz_ohupPs&t
public enum BattleState { OUTCOMBAT, START, PLAYERTURN, ENEMYTURN, END }

public class StateMachine : MonoBehaviour
{
	public GameObject player, enemy;
	public Chara_Info playerinfo, enemyinfo;
	public Transform playerPos, enemypos, camplacement;
	public Vector3 playerlastPos, enemylastPos, camlastpos;
	public BattleState state;
	public CharacterMovement playermove;
	public CamController cam;
	public Animator fadeanim;


	public GameObject battlemenu;


	public void Start()
	{
		state = BattleState.OUTCOMBAT;
		
	}



	

	public IEnumerator BattleSetup()
	{
		yield return new WaitForSeconds(0.05f);

		fadeanim.Play("Toblack", 0, 0.0f);

		

		cam.CamFollow = false;
		playerlastPos = player.transform.position;
		enemylastPos = enemy.transform.position;
		camlastpos = cam.transform.position;
		player.transform.position = playerPos.transform.position;
		enemy.transform.position = enemypos.transform.position;

		cam.transform.position = camplacement.transform.position;
		playermove.sprite.transform.eulerAngles = new Vector3(0, 0, 0);
		
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		playermove.canmove = false;

		yield return new WaitForSeconds(0.1f);

		fadeanim.Play("Fadeout", 0, 0.0f);

		yield return new WaitForSeconds(0.5f);

		state = BattleState.PLAYERTURN;

		//PlayerTurn();
	}

	public void PlayerTurn()
	{
		battlemenu.SetActive(true);
	}


	IEnumerator Flee ()
	{
		yield return new WaitForSeconds (0.3f);

		fadeanim.Play("Toblack", 0, 0.0f);


		//player.transform.position = playerlastPos;
		enemy.transform.position = enemylastPos;
		playermove.canmove = true;
		cam.CamFollow = true;
		cam.transform.position = camlastpos;

		Vector3 newpos = new Vector3((-enemylastPos.x + 2*playerlastPos.x), (-enemylastPos.y + 2*playerlastPos.y), 0); 
		
		//a basic highschool maths formula that took me way too long to get haha
		player.transform.position = newpos;
		
		yield return new WaitForSeconds(0.1f);

		fadeanim.Play("Fadeout", 0, 0.0f);




		yield return new WaitForSeconds(0.5f);



	}


	public void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			StartCoroutine(Flee());
		}
	}



	//IEnumerator PlayerAttack()
	//{
	//	bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

	//	enemyHUD.SetHP(enemyUnit.currentHP);
	//	dialogueText.text = "The attack is successful!";

	//	yield return new WaitForSeconds(2f);

	//	if (isDead)
	//	{
	//		state = BattleState.WON;
	//		EndBattle();
	//	}
	//	else
	//	{
	//		state = BattleState.ENEMYTURN;
	//		StartCoroutine(EnemyTurn());
	//	}
	//}

	//IEnumerator EnemyTurn()
	//{
	//	dialogueText.text = enemyUnit.unitName + " attacks!";

	//	yield return new WaitForSeconds(1f);

	//	bool isDead = playerUnit.TakeDamage(enemyUnit.damage);

	//	playerHUD.SetHP(playerUnit.currentHP);

	//	yield return new WaitForSeconds(1f);

	//	if (isDead)
	//	{
	//		state = BattleState.LOST;
	//		EndBattle();
	//	}
	//	else
	//	{
	//		state = BattleState.PLAYERTURN;
	//		PlayerTurn();
	//	}

	//}

	//void EndBattle()
	//{
	//	if (state == BattleState.WON)
	//	{
	//		dialogueText.text = "You won the battle!";
	//	}
	//	else if (state == BattleState.LOST)
	//	{
	//		dialogueText.text = "You were defeated.";
	//	}
	//}

	//void PlayerTurn()
	//{
	//	dialogueText.text = "Choose an action:";
	//}

	//IEnumerator PlayerHeal()
	//{
	//	playerUnit.Heal(5);

	//	playerHUD.SetHP(playerUnit.currentHP);
	//	dialogueText.text = "You feel renewed strength!";

	//	yield return new WaitForSeconds(2f);

	//	state = BattleState.ENEMYTURN;
	//	StartCoroutine(EnemyTurn());
	//}

	//public void OnAttackButton()
	//{
	//	if (state != BattleState.PLAYERTURN)
	//		return;

	//	StartCoroutine(PlayerAttack());
	//}


}
