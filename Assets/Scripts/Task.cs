using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Task : MonoBehaviour, Interactable
{
    public Tasks task;
    public Color Target;
    private Color next;
    public float changeTime;
    private bool changing= false;
    private List<Material> spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = (from mat in GetComponentsInChildren<MeshRenderer>() select mat.materials[1]).ToList();
    }
    private void Update()
    {
        if (spriteRenderer[0].color == Target)
        {
            GameManager.Instance.schedueler.markTask(task);
        }
        else
        {
            GameManager.Instance.schedueler.unmarkTask(task);
        }
    }
    public void action()
    {
        StartCoroutine(changeColor());
    }
    private IEnumerator changeColor() 
    {
        if(changing)
            yield break;
        changing = true ;
        next = GameManager.Instance.Colors[(GameManager.Instance.Colors.IndexOf(next) + 1) % GameManager.Instance.Colors.Count];
        Color previous = spriteRenderer[0].color;
        float CurrentTime = 0;
        while (spriteRenderer[0].color != next)
        {
            foreach(Material sr in spriteRenderer)
                sr.color = Color.Lerp(previous, next, CurrentTime / changeTime);
            CurrentTime += Time.smoothDeltaTime;
            yield return null;
        }
        changing = false ;
    }
}
public interface Interactable
{
    public abstract void action();
}