using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        reticleRenderer.transform.position = transform.position + transform.forward * 1.0f;
        reticleRenderer.transform.rotation = Quaternion.Euler((float)System.Math.Round(transform.rotation.eulerAngles.x, 2), (float)System.Math.Round(transform.rotation.eulerAngles.y, 2), (float)System.Math.Round(transform.rotation.eulerAngles.z, 2));
        if(Input.touchCount>0)
            if (Input.GetTouch(0).phase== TouchPhase.Stationary)
            {
                SceneManager.UnloadSceneAsync(1);
                SceneManager.LoadScene(0);
            }
    }
    public IEnumerator startAction(GameObject interactable)
    {
        if(!(GameManager.Instance.initailized||interactable.name.ToLower().Contains("init")))
            yield break;
        yield return new WaitForSeconds(1.0f);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, float.MaxValue, LayerMask.GetMask("Interactable")) && hit.collider.gameObject == interactable)
        {
            hit.collider.gameObject.GetComponent<Interactable>().action();
        }
    }
}
