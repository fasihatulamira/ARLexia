using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ARDrawOnPlane : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    public ARPlaneManager planeManager;
    public GameObject linePrefab;
    public Button deleteButton;

    private LineRenderer currentLineRenderer;
    private List<Vector3> points = new List<Vector3>();
    private List<LineRenderer> allLines = new List<LineRenderer>();

    void Start()
    {
        deleteButton.onClick.AddListener(ClearDrawing);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                CreateLine();
            }

            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                UpdateLine(touchPosition);
            }
        }
    }

    void CreateLine()
    {
        GameObject newLine = Instantiate(linePrefab);
        currentLineRenderer = newLine.GetComponent<LineRenderer>();
        points.Clear();
        allLines.Add(currentLineRenderer);
    }

    void UpdateLine(Vector2 touchPosition)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        if (raycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], hitPose.position) > 0.01f)
            {
                points.Add(hitPose.position);
                currentLineRenderer.positionCount = points.Count;
                currentLineRenderer.SetPositions(points.ToArray());
            }
        }
    }

    public void ClearDrawing()
    {
        foreach (LineRenderer line in allLines)
        {
            Destroy(line.gameObject);
        }
        allLines.Clear();
        points.Clear();
    }

    public void back()
    {
        SceneManager.LoadScene("Belajar");
    }
}