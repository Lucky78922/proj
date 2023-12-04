using UnityEngine;
using System.Collections.Generic;
[System.Serializable]
public class id { public int idd; };
[CreateAssetMenu(fileName = "line", menuName = "New line")]
public class lineSO : ScriptableObject {
	public List<id> linesId;
	//public int id;
	/*public List<Transform> objects;
	[ContextMenu("Updatee")]
	void Updatee()
	{
		lines = new List<Vector3>();
		for (int i = 0;i<objects.Count;i++) {
			lines.Add(objects[i].position);
		}
	}*/
}