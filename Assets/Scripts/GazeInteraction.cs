using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GazeInteraction : MonoBehaviour
{
    public Sprite reticle;
    public Sprite openReticle;
    public SpriteRenderer reticleRenderer;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,out hit, float.MaxValue, LayerMask.GetMask("Interactable")))
        {
                reticleRenderer.color = Color.red;
                StartCoroutine(startAction(hit.collider.gameObject));
        }
        else
        {
            reticleRenderer.color = Color.white;
        }
    }
    public IEnumerator startAction(GameObject interactable)
    {

        yield return new WaitForSeconds(1.0f);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, float.MaxValue, LayerMask.GetMask("Interactable")) && hit.collider.gameObject == interactable)
        {
            Debug.Log("Task Done");
            hit.collider.gameObject.GetComponent<Interactable>().action(); 
        }
    }
}
