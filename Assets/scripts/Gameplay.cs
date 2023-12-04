using UnityEngine;

public class Gameplay : MonoBehaviour
{
	private int nodeCount = 32;
	public Vector3[] nodePositions = new Vector3[] {
		new Vector2(0.2f, 4.48f),   new Vector2(-2.24f, 4.16f), new Vector2(2.76f, 4.17f),  new Vector2(-1.19f, 3.19f),
		new Vector2(1.7f,3.19f),    new Vector2(-2f,1.64f),     new Vector2(2f,1.67f),      new Vector2(-2.48f,0.02f),
		new Vector2(2.97f,0.04f),   new Vector2(0.21f,-0.01f),  new Vector2(-1.99f,-1.55f), new Vector2(2f,-1.55f),
		new Vector2(-1.25f,-3.24f), new Vector2(1.63f,-3.24f),  new Vector2(-2.31f,-4.24f), new Vector2(2.69f,-4.22f),
		new Vector2(0.19f,-4.51f),  new Vector2(5.12f,0.09f),   new Vector2(7.27f,0.07f),   new Vector2(3.74f,2.07f),
		new Vector2(3.69f,-2.12f),  new Vector2(-4.18f,0.03f),  new Vector2(-5.88f,-0.01f), new Vector2(-7.95f,0f),
		new Vector2(-7.13f,1.68f),  new Vector2(-7.14f,-1.69f), new Vector2(-6.31f,-3.12f), new Vector2(-3.34f,-2.14f),
		new Vector2(-4.93f,-2.17f), new Vector2(-3.29f,2.1f),   new Vector2(-4.88f,2.12f),  new Vector2(-6.23f,3.07f)
	};
	//                                         0  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31
	private int[] nodeTeam = new int[]      { -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	private int[] nodeSize = new int[]      {  1, 1, 1, 1, 1, 1, 1, 2, 2, 3, 1, 1, 1, 1, 1, 1, 1, 2, 3, 1, 1, 2, 1, 2, 1, 1, 1, 1, 2, 1, 2, 1 };
	private int[] nodeUnitCount = new int[] { 10, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };

	public GameObject nodeOriginal;
	public GameObject nodeContainer;

	void Start()
	{
		for (int i = 0; i < nodeCount; i++)
		{
			GameObject node = Instantiate(nodeOriginal, nodePositions[i], Quaternion.identity);
			node.transform.SetParent(nodeContainer.transform);
			node.name = "Node " + i;
		}
	}
}