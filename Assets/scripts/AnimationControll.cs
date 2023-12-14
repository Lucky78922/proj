using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll: MonoBehaviour
{
    public enum Team : int { enemy, neutral, player }
    public enum Size : int { small, medium, large };


    [SerializeField] private MeshRenderer planet;
    [SerializeField] private MeshRenderer ring;
    [SerializeField] private Material[] planets;
    [SerializeField] private Material[] rings;
    [SerializeField] private Size size;
    [SerializeField] private Team team;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ChangeSize(size);
        ChangeTeam(team);
    }

    public void ChangeSize(Size newSize)
    {
        size = newSize;
        if ((int)size == 2)
            ring.enabled = true;
        else
            ring.enabled = false;

        switch (size)
        {
            case Size.small:
                anim.SetFloat("Speed", 1.5f);
                break;
            case Size.medium:
                anim.SetFloat("Speed", 1f);
                break;
            case Size.large:
                anim.SetFloat("Speed", 0.5f);
                break;
        }
    }

    public void ChangeTeam(Team newTeam)
    {
        team = newTeam;
        planet.material = planets[(int)size * 3 + (int)team];
        
        if ((int)size == 2)
            ring.material = rings[(int)team];
    }
}
