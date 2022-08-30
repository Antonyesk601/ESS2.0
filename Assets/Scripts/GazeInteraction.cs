using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.XR;
public class GazeInteraction : MonoBehaviour
{
    public Sprite reticle;
    public Sprite openReticle;
    public SpriteRenderer reticleRenderer;
    [HideInInspector]
    public bool active = false;
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
    private void FixedUpdate()
    {
        reticleRenderer.transform.position = transform.position + transform.forward * 1.0f;
        reticleRenderer.transform.rotation = transform.rotation;
    }
    public IEnumerator startAction(GameObject interactable)
    {

        yield return new WaitForSeconds(1.0f);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, float.MaxValue, LayerMask.GetMask("Interactable")) && hit.collider.gameObject == interactable)
        {
            hit.collider.gameObject.GetComponent<Interactable>().action();
            Debug.Log(interactable.name);
        }
    }
}
