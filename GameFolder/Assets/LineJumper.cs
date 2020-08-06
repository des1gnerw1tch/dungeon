using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineJumper : MonoBehaviour
{
    [SerializeField] private List<Transform> checkpoints = new List<Transform>();
    private LineRenderer lineRenderer;
    Vector2 mousePosStart;
    Vector2 mousePosEnd;
    public float bounds = .5f;
    private int curLines = 0;
    private bool wasFound;
    public string[] combo;
    public GameObject[] EnchantmentDrops;
    public string playerAtempt = "";
    private string holder;
    public Material material;
    public bool isSuccess = false;
    // Start is called before the first frame update
    void Start()
    {
        //this.DrawLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && GetComponent<CanvasGroup>().alpha == 1)
        {


            mousePosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            for (int i = 0; i < checkpoints.Count; i++)
            {
                if (mousePosStart.x > checkpoints[i].position.x - bounds && mousePosStart.x < checkpoints[i].position.x + bounds)
                {
                    if (mousePosStart.y > checkpoints[i].position.y - bounds && mousePosStart.y < checkpoints[i].position.y + bounds)
                    {
                        if (lineRenderer == null)
                        {
                            CreateLine();
                        }
                        mousePosEnd.Set(checkpoints[i].position.x, checkpoints[i].position.y);
                        lineRenderer.SetPosition(0, mousePosEnd);
                        lineRenderer.SetPosition(1, mousePosStart);
                        Debug.Log("From " + checkpoints[i].name);
                        holder = playerAtempt;
                        playerAtempt = playerAtempt + checkpoints[i].name;
                    }
                }
            }

        }
        else if (Input.GetMouseButtonUp(0) && lineRenderer)
        {
            wasFound = false;
            mousePosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            for (int i = 0; i < checkpoints.Count; i++)
            {
                if (mousePosStart.x > checkpoints[i].position.x - bounds && mousePosStart.x < checkpoints[i].position.x + bounds)
                {
                    if (mousePosStart.y > checkpoints[i].position.y - bounds && mousePosStart.y < checkpoints[i].position.y + bounds)
                    {
                        Vector2 pos = new Vector2();
                        pos.Set(checkpoints[i].position.x, checkpoints[i].position.y);
                        lineRenderer.SetPosition(1, pos);
                        Debug.Log("To " + checkpoints[i].name);
                        playerAtempt = playerAtempt + checkpoints[i].name;
                        if (pos != mousePosEnd)
                        {
                            wasFound = true;
                        }

                    }
                }

            }
            if (!wasFound)
            {
                Destroy(lineRenderer);
                playerAtempt = holder;
            }
            lineRenderer = null;
            curLines++;
        }
        else if (Input.GetMouseButton(0) && lineRenderer)
        {
            mousePosStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            lineRenderer.SetPosition(1, mousePosStart);
        }
        if (Input.GetKey("c"))
        {
            clearLines();

        }
        for (int i = 0; i < combo.Length; i++)
        {
            if (combo[i] == playerAtempt)
            {
                Debug.Log("Success");
                GameObject.Find("ItemManager").GetComponent<ItemManager>().ConsumeItem();
                if(GetComponent<CanvasGroup>().alpha == 1)
                {
                    Instantiate(EnchantmentDrops[i], GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
                }
                
                
                isSuccess = true;
            }
        }
        
    }
    private void DrawLine()
    {
        GameObject lineObject = new GameObject();
        this.lineRenderer = lineObject.AddComponent<LineRenderer>();
        this.lineRenderer.startWidth = .1f;
        this.lineRenderer.endWidth = .1f;
        this.lineRenderer.positionCount = checkpoints.Count;

        Vector3[] checkPointArray = new Vector3[this.checkpoints.Count];
        for (int i = 0; i < this.checkpoints.Count; i++)
        {
            Vector3 checkpointpos = this.checkpoints[i].position;
            checkPointArray[i] = new Vector3(checkpointpos.x, checkpointpos.y, 0f);
        }

        //this.lineRenderer.SetPositions(checkPointArray);
    }
    void CreateLine()
    {
        lineRenderer = new GameObject("line " + curLines).AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = .2f;
        lineRenderer.endWidth = .2f;
        lineRenderer.numCapVertices = 40;
        lineRenderer.material = material;

        //lineRenderer.useWorldSpace = true;
        lineRenderer.sortingOrder = 3;
    }
    public void clearLines()
    {
        for (int i = 0; i < curLines; i++)
        {
            Destroy(lineRenderer);
            Destroy(GameObject.Find("line " + i));
        }
        playerAtempt = "";
    }
}
