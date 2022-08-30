using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class InitTask : MonoBehaviour,Interactable
{
    public Light lighting;
    public GameObject interactables;
    public int maxSimilarColorCount;
    private Dictionary<Color,int> Chosen;
    [HideInInspector]
    public Tasks Task = Tasks.Init;
    private void Start()
    {
        Chosen= new Dictionary<Color,int>();
        lighting.intensity = 0;
        foreach (Transform interactable in interactables.transform)
        {
            if (interactable == transform)
                continue;
            List<Material> spriteRenderer = (from mat in interactable.GetComponentsInChildren<MeshRenderer>() select mat.materials[1]).ToList();
            Color currentColor= GameManager.Instance.Colors[Random.Range(0, GameManager.Instance.Colors.Count)]; 
                if (!Chosen.ContainsKey(currentColor))
                    Chosen[currentColor] = 0;
                Chosen[currentColor]++;
            foreach (Material sr in spriteRenderer)
            {
                sr.color = new Color(currentColor.r,currentColor.g,currentColor.b,0.0f);
            }
        }
        maxSimilarColorCount = Mathf.Max(Chosen.Values.ToArray());
    }
    public void action()
    {
        foreach (Transform interactable in interactables.transform)
        {
            if (interactable == transform)
                continue;
            StartCoroutine(InitInteractable((from mat in interactable.GetComponentsInChildren<MeshRenderer>() select mat.materials[1]).ToList()));
        }

        StartCoroutine(InitLight());
    }
    private IEnumerator InitInteractable(List<Material> spriteRenderer)
    {
        
        Color previous = spriteRenderer[0].color;
        Color Target = new Color(previous.r, previous.g, previous.b, 0.5f);
        foreach (Material sr in spriteRenderer)
        {
            StartCoroutine(ChangeColor(sr, Target, previous));
        }
        yield return null;
    }
    private IEnumerator ChangeColor(Material sr, Color Target, Color previous)
    {
        float CurrentTime = 0;
        while (sr.color != Target)
        {
            sr.color = Color.Lerp(previous, Target, CurrentTime / 5.0f);
            CurrentTime += Time.smoothDeltaTime;
            yield return null;
        }
    }
    private IEnumerator InitLight()
    {
        float CurrentTime = 0;
        while (lighting.intensity < 4.0f)
        {
            lighting.intensity = (CurrentTime / 5.0f)*4.0f;
            CurrentTime += Time.smoothDeltaTime;
            Debug.Log(CurrentTime);
            yield return null;

        }
    }

}
