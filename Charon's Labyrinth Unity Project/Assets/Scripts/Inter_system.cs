using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Inter_system : MonoBehaviour
{
    public int coinsCollected = 0;
    bool interactableKey = false;
    bool interactableHole = true;
    bool movedHand = false;
    bool haveKey = false;

    private Text text;
    public GameObject handKey;
    public GameObject skeletHand;
    public GameObject holeKey;
    public GameObject exitGate;
    public GameObject pierce;
    public GameObject charonCoins;

    public string RaycastReturn;
    int layerCoin = 1 << 8;
    int layerReservoir = 1 << 9;
    int layerKey = 1 << 10;
    int layerKeyHole = 1 << 11;
    public float rayLength = 2.0f;
    public float rayTime = 3f;

    AudioSource audioCoin;
    public AudioClip[] coinSoundArray;

    private void Start()
    {
        handKey = GameObject.Find("HandKey");
        skeletHand = GameObject.Find("SkeletonHandReverse");
        holeKey = GameObject.Find("KeyExit");
        exitGate = GameObject.Find("Gate");
        pierce = GameObject.Find("Pierce");

        audioCoin = GetComponent<AudioSource>();
        audioCoin.clip = coinSoundArray[Random.Range(0, coinSoundArray.Length)];

        handKey.SetActive(false);
        holeKey.SetActive(false);


    }
    void Update()
     {
         if (Input.GetKeyDown(KeyCode.E))
         {
             RayPickUp();
         }
     }


     void RayPickUp() 
     {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength, layerCoin) && (hit.collider != null))
        {
            RaycastReturn = hit.collider.gameObject.name;
            Destroy(hit.collider.gameObject);
            //
            audioCoin.PlayOneShot(audioCoin.clip);
            //
            coinsCollected++;            
            coinsCounterUpdate();
            Debug.Log("Hit " + hit.collider.gameObject.name, hit.collider.gameObject);
        }
        else if (Physics.Raycast(ray, out hit, rayLength, layerReservoir) && (movedHand != true) && (coinsCollected == 6) && (hit.collider != null))
        {
            RaycastReturn = hit.collider.gameObject.name;
            //звук падающих монет
            movedHand = true;

            // включение руки
            handKey.SetActive(true);
            handKey.GetComponentInChildren<Animation>().Play("Hand anim");
            //
            StartCoroutine(HandPause());
            Debug.Log("Hit " + hit.collider.gameObject.name, hit.collider.gameObject);
        }
        else if (Physics.Raycast(ray, out hit, rayLength, layerKey) && (interactableKey != false) && (hit.collider != null))
        {
            RaycastReturn = hit.collider.gameObject.name;
            Destroy(hit.collider.gameObject);
            haveKey = true;
            Debug.Log("Hit " + hit.collider.gameObject.name, hit.collider.gameObject);
        }
        else if (Physics.Raycast(ray, out hit, rayLength, layerKeyHole) && (haveKey != false) && (interactableHole != false) && (hit.collider != null))
        {
            RaycastReturn = hit.collider.gameObject.name;
            interactableHole = false;
            holeKey.SetActive(true);
            StartCoroutine(KeyExitPause());
            Debug.Log("Hit " + hit.collider.gameObject.name, hit.collider.gameObject);
        }
    }

    IEnumerator HandPause()
    {
        yield return new WaitForSeconds(4);
        interactableKey = true;
    }

    IEnumerator KeyExitPause()
    {
        yield return new WaitForSeconds(4);
        interactableHole = false;
        exitGate.GetComponent<Animation>().Play("Scene");
        pierce.GetComponent<Animation>().Play("Scene");
    }
    void coinsCounterUpdate()
     {
         if (coinsCollected != 6)
         {
             Font arial;
             arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

             GameObject canvasGO = new GameObject();
             canvasGO.name = "Canvas";
             canvasGO.AddComponent<Canvas>();
             canvasGO.AddComponent<CanvasScaler>();
             canvasGO.AddComponent<GraphicRaycaster>();

             Canvas canvas;
             canvas = canvasGO.GetComponent<Canvas>();
             canvas.renderMode = RenderMode.ScreenSpaceOverlay;

             GameObject textGO = new GameObject();
             textGO.transform.parent = canvas.transform;
             textGO.AddComponent<Text>();

             text = textGO.GetComponent<Text>();
             text.font = arial;
             text.text = "Coins collected:" + coinsCollected + "/6";
             text.fontSize = 42;
             text.alignment = TextAnchor.UpperCenter;

             RectTransform rectTransform;
             rectTransform = text.GetComponent<RectTransform>();
             rectTransform.localPosition = new Vector3(0, 0, 0);
             rectTransform.sizeDelta = new Vector2(600, 200);

             Destroy(canvasGO, 4f);
         }
         else
         {
             Font arial;
             arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

             GameObject canvasGO = new GameObject();
             canvasGO.name = "Canvas";
             canvasGO.AddComponent<Canvas>();
             canvasGO.AddComponent<CanvasScaler>();
             canvasGO.AddComponent<GraphicRaycaster>();

             Canvas canvas;
             canvas = canvasGO.GetComponent<Canvas>();
             canvas.renderMode = RenderMode.ScreenSpaceOverlay;

             GameObject textGO = new GameObject();
             textGO.transform.parent = canvas.transform;
             textGO.AddComponent<Text>();

             text = textGO.GetComponent<Text>();
             text.font = arial;
             text.text = "All coins collected. Pick up the key and run to the exit!";
             text.fontSize = 48;
             text.alignment = TextAnchor.UpperCenter;

             RectTransform rectTransform;
             rectTransform = text.GetComponent<RectTransform>();
             rectTransform.localPosition = new Vector3(0, 0, 0);
             rectTransform.sizeDelta = new Vector2(600, 200);

             Destroy(canvasGO, 7f);
         }
     }
}
