using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public enum state : byte { nikt, enemy, player, }
[System.Serializable]
public enum pointLvl : byte { a,b,c,d, }
public class Point : MonoBehaviour {
	public AnimationControll pointAnimation;
	public CamMove move;
	public int sprite_id;
	public state state;
	public pointLvl pointLvl;
	(short lvl, short maxPointsInPlanet)[] lvls = {
		(1,10),
		(2,15),
		(3,20),
		(4,30),
	};
	public lineSO lines;
	float time;
	public int points;
	bool haveNotEnemy;
	void Awake()=>StartCoroutine(move.TextControl(transform.GetComponent<SpriteRenderer>(), points));
	void Update() {
		if (state != state.nikt) time +=Time.deltaTime;
		if (time >= 1) {
			time = 0;
			int n = (int)char.ToUpper((char)pointLvl) - 1;
			if (n < 0) n = 0;
			if (lvls[n].maxPointsInPlanet >= points + 1) points++;
			if (state == state.enemy) {
				haveNotEnemy = false;
				for (int g = 0; g < lines.linesId.Count; g++) { 
					if (move.points[lines.linesId[g].idd].state == state.nikt || move.points[lines.linesId[g].idd].state == state.player) 
						haveNotEnemy = true;
				}
				if (haveNotEnemy) {
					for (int i = 0; i < lines.linesId.Count; i++) {
						if (move.points[lines.linesId[i].idd].state == state.nikt && (points >= move.points[lines.linesId[i].idd].points * 1.5)||(points == move.points[lines.linesId[i].idd].lvls[(int)move.points[lines.linesId[i].idd].pointLvl].maxPointsInPlanet)) {
							haveNotEnemy = false;
							Bullet go = Instantiate(move.bulletPref, transform.position, Quaternion.identity).GetComponent<Bullet>();
							move.SetStatekDatas(go, this,i);
							break;
						}
						if (haveNotEnemy)
							for (int h = 0; h < lines.linesId.Count; h++) {
								if (move.points[lines.linesId[i].idd].state == state.player) {
									if (points >= move.points[lines.linesId[i].idd].points * 1.2 || points == lvls[(int)char.ToUpper((char)pointLvl)].maxPointsInPlanet) {
										haveNotEnemy = false;
										Bullet go = Instantiate(move.bulletPref, transform.position, Quaternion.identity).GetComponent<Bullet>();
										move.SetStatekDatas(go, this,i);
										break;
									}
								}
							}
					}
				}
				else {
					int g = Random.RandomRange(1, 100);
					if (g%25 == 3) {
						Bullet go = Instantiate(move.bulletPref, transform.position, Quaternion.identity).GetComponent<Bullet>();
						move.SetStatekDatas(go,this,Random.Range(1,2));
					}
				}
			}
			StartCoroutine(move.TextControl(transform.GetComponent<SpriteRenderer>(), points));
		}
	}
}