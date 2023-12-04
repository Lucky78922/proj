using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Node : MonoBehaviour
{
    private int nodeId;
    private int nodeSize;
    private int nodeTeam;
    private int unitCount;
    private int id;
    
    public TextMeshProUGUI diplayText;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    public void Init(int id, int size, int team, int units)
    {
        nodeId = id;
        nodeSize = size;
        nodeTeam = team;
        unitCount = units;

        diplayText.text = unitCount.ToString();

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        SetTeam(nodeTeam);
    }

    private void SetTeam(int team)
    {
        spriteRenderer.sprite = sprites[(team + 1) * 3 + nodeSize - 1];
        this.spriteRenderer.size = new Vector2(1f, 1f);
        nodeTeam = team;
        if (team == 1)
        {
            diplayText.color = Color.blue;
        }
        else if (team == -1)
        {
            diplayText.color = Color.red;
        }
        else
        {
            diplayText.color = Color.white;
        }
    }
}