using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bullet : MonoBehaviour
{
    public List<Sprite> sprites;
    public int minusPoints;
    [Range(1, 3)]
    public int spriteId;
    public GameObject target;
    public float speed, time;
    public CamMove movec;
    public state startState, endState;
    void Awake() => movec = FindObjectOfType<CamMove>();
    void Start() => StartCoroutine(move());
    IEnumerator move()
    {
        while (Vector3.Distance(transform.position, target.transform.position) > 0.2f)
        {
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.GetChild(0).rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            yield return null;
        }
        if (startState != target.GetComponent<Point>().state) target.GetComponent<Point>().points -= minusPoints;
        else target.GetComponent<Point>().points += minusPoints;
        if (target.GetComponent<Point>().points <= 0)
        {
            target.GetComponent<Point>().points = target.GetComponent<Point>().points * -1;
            target.GetComponent<Point>().state = endState;
            //target.GetComponent<SpriteRenderer>().sprite = movec.stateSprites[((spriteId * 3) - 3) + (int)endState];

            if (endState == state.player)
                target.GetComponent<Point>().pointAnimation.ChangeTeam(AnimationControll.Team.player);
            else if (endState == state.enemy)
                target.GetComponent<Point>().pointAnimation.ChangeTeam(AnimationControll.Team.enemy);
            else
                target.GetComponent<Point>().pointAnimation.ChangeTeam(AnimationControll.Team.neutral);
        }
        StartCoroutine(movec.TextControl(target.GetComponent<SpriteRenderer>(), target.GetComponent<Point>().points));
        Destroy(gameObject);
    }
}
