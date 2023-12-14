using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System;
public class CamMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	public Sprite[] numbers;
	public GameObject numbprefab, bulletPref,StartPoint,EndPoint;
	public Camera cam;
	public Sprite[] stateSprites;
	public Point[] points;
	Ray _ray;
	RaycastHit _hit;
	void Awake() => Application.targetFrameRate = 30;
	public IEnumerator TextControl(SpriteRenderer text, int number) {
		string numberString = Math.Abs(number).ToString();
		if (numberString.Length == 1) numberString = 0+numberString;
		for (int i = 0; i < numberString.Length; i++) text.transform.GetChild(0).GetChild(i).GetComponent<SpriteRenderer>().sprite = numbers[int.Parse(numberString[i].ToString())];
		if (numberString.Length == 2) {
			text.transform.GetChild(0).GetChild(0).localPosition = new Vector3(.35f, 0, 0);
			text.transform.GetChild(0).GetChild(1).localPosition = new Vector3(1.05f, 0, 0);
			text.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
		}
		else if(numberString.Length == 3) {
			text.transform.GetChild(0).GetChild(0).localPosition = new Vector3(0,0,0);
			text.transform.GetChild(0).GetChild(1).localPosition = new Vector3(.7f,0,0);
			text.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
			text.transform.GetChild(0).GetChild(2).localPosition = new Vector3(1.4f,0,0);
		}
		yield return null;
	}
	public void OnPointerUp(PointerEventData eventData) {
		_ray = cam.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(_ray, out _hit, 100f))
			if (_hit.collider != null) { 
				GameObject NewPoint = _hit.collider.gameObject;
				if (NewPoint == null) return;
				if (StartPoint != null) {
					if (StartPoint.GetComponent<Point>().state != state.player)
						return;
					if (NewPoint == StartPoint&& StartPoint.transform.GetChild(1).gameObject.activeSelf) { 
						StartPoint?.transform.GetChild(1).gameObject.SetActive(false);
						EndPoint?.transform.GetChild(1).gameObject.SetActive(false);
						StartPoint = null;
						EndPoint = null;
						return;
					}
				}
				if (StartPoint==null)
					if (NewPoint.GetComponent<Point>().state==state.player) {
						StartPoint = NewPoint;
						EndPoint = null;
					}
				if (StartPoint != null) {
					StartPoint.transform.GetChild(1).gameObject.SetActive(true);
					EndPoint = StartPoint;
					StartPoint= NewPoint;
				}
				if ((EndPoint != null&&StartPoint!=null)&&(EndPoint!=StartPoint)) {
					bool have = false;
					for (int i = 0; i < StartPoint.GetComponent<Point>().lines.linesId.Count; i++) {
						if (StartPoint.GetComponent<Point>().lines.linesId[i].idd == int.Parse(EndPoint.name.Split(' ')[1])) {
							have = true;
							Bullet go = Instantiate(bulletPref, EndPoint.transform.position, Quaternion.identity).GetComponent<Bullet>();
							if (go == null) return;
							go.target = StartPoint;
							go.minusPoints = EndPoint.GetComponent<Point>().points;
							go.endState = state.player;
							go.startState = state.player;
							go.spriteId = StartPoint.GetComponent<Point>().sprite_id;
							if (go.transform.GetChild(1)) 
								if (go.transform.GetChild(1).GetChild(0))
									go.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = go.minusPoints.ToString();
							go.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = go.sprites[(int)go.startState-2];
							StartPoint.transform.GetChild(1).gameObject.SetActive(false);
							EndPoint.transform.GetChild(1).gameObject.SetActive(false);
							EndPoint.GetComponent<Point>().points = 0;
							EndPoint = null;
							StartPoint = null;
							break;
						}
					}
					if (have == false){
						StartPoint.transform.GetChild(1).gameObject.SetActive(false);
						EndPoint.transform.GetChild(1).gameObject.SetActive(false);
						EndPoint = null;
						StartPoint = null;
					}
				}
			}
	}
	public void OnPointerDown(PointerEventData eventData) { }
	public void SetStatekDatas(Bullet go, Point p,int i) {
		go.target = points[p.lines.linesId[i].idd].transform.gameObject;
		go.minusPoints = p.points;
		go.endState = state.enemy;
		go.startState = p.state;
		go.spriteId = go.target.GetComponent<Point>().sprite_id;
		go.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = go.minusPoints.ToString();
		go.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = go.sprites[(int)go.startState];
		p.points = 0;
	}
	public void ChangeTimeSpeed(float speed)=>Time.timeScale = speed;
}
