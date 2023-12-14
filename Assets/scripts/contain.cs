using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contain : MonoBehaviour
{
	//public List<Vector3> vc3s;
	public CamMove movec;
	public List<lineSO> lins;
	public GameObject pref;
	/*void Start() {
		for (int i = 0; i < transform.childCount; i++) {
			transform.GetChild(i).GetComponent<Point>().lines = lins[i];
			//vc3s.Add(new Vector3((int)transform.GetChild(i).position.x, (int)transform.GetChild(i).position.y, 0));
			//string nam = transform.GetChild(i).name.Split(' ')[1];
			//StartCoroutine(TextControl(nam,transform.GetChild(i)));
		}
	}*/
	[ContextMenu("DevTools")]
	public void DevTools() {
		for (int i = 0; i < transform.childCount; i++) {
			/*var child = transform.GetChild(i);
			print(child.name);
            string str = child.gameObject.name;
			str.Replace('_', ' ');
			child.gameObject.name = str;*/
            //transform.GetChild(i).GetChild(1).gameObject.SetActive(false);
            //if (i < 11)
            //	continue;
            //transform.GetChild(i).GetChild(1).transform.localScale = new Vector3(1, 1, 1);
            //Instantiate(pref, transform.GetChild(i));
            //transform.GetChild(i).transform.localScale *= 5;
            //transform.GetChild(i).name = "Point " + transform.GetChild(i).GetComponent<Point>().lines.name.Split(' ')[transform.GetChild(i).GetComponent<Point>().lines.name.Split(' ').Length-1];
            /*transform.GetChild(i).GetChild(0).GetChild(0).localPosition = new Vector3(.35f, 0, 0);
			transform.GetChild(i).GetChild(0).GetChild(1).localPosition = new Vector3(1.05f, 0, 0);
			transform.GetChild(i).GetChild(0).GetChild(2).gameObject.SetActive(false);*/
            /*print(i);
			Point point = transform.GetChild(i).GetComponent<Point>();
			point.lines = lins[int.Parse(point.name.Split(' ')[1])];*/
        }
	}
	/*public IEnumerator TextControl(string str,Transform tr) {
		print(tr.name);
		Transform text = tr;
		string numberString = str;
		for (int i = 0; i < numberString.Length; i++) {
			GameObject go = Instantiate(movec.numbprefab, text);
			go.name=i.ToString();
			go.GetComponent<SpriteRenderer>().sprite = movec.numbers[int.Parse(numberString[i].ToString())];
		}
		while (transform.childCount!= numberString.Length)
			yield return new WaitForSeconds(.1f);
		if (numberString.Length == 1)
			text.transform.GetChild(0).GetChild(0).localPosition = new Vector3(.7f, 0, 0);
		else if (numberString.Length == 2) {
			text.transform.GetChild(0).GetChild(0).localPosition = new Vector3(.35f, 0, 0);
			text.transform.GetChild(0).GetChild(1).localPosition = new Vector3(1.05f, 0, 0);
		}
		yield return null;
	}*/
}
