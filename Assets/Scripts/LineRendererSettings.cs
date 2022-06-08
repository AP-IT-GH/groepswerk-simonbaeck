using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererSettings : MonoBehaviour
{
    [SerializeField] LineRenderer rend;
    public LayerMask layerMask;
    public GameObject panel;
<<<<<<< Updated upstream
    public Image img;
=======
    public Image[] imgs;
>>>>>>> Stashed changes
    public Button btn;

    Vector3[] points;

    private void Start()
    {
        rend = gameObject.GetComponent<LineRenderer>();
<<<<<<< Updated upstream
        img = panel.GetComponent<Image>();
=======
        //imgs = panel.GetComponent<Image>();
        imgs[0] = gameObject.GetComponent("start_button").gameObject.GetComponent<Image>();
>>>>>>> Stashed changes
        points = new Vector3[2];
        points[0] = Vector3.zero;
        points[1] = transform.position + new Vector3(0,0,20);

        rend.SetPositions(points);
        rend.enabled = true;
    }

    private void Update()
    {
        AlignLineRenderer(rend);
        if(AlignLineRenderer(rend) && Input.GetAxis("Submit") > 0)
        {
            btn.onClick.Invoke();
        }
    }

    public bool AlignLineRenderer(LineRenderer rend)
    {
        bool hitBtn = false;
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, layerMask))
        {
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
            btn = hit.collider.gameObject.GetComponent<Button>();
<<<<<<< Updated upstream
            rend.startColor = Color.green;
            rend.endColor = Color.green;
=======
            rend.startColor = Color.yellow;
            rend.endColor = Color.yellow;
>>>>>>> Stashed changes
            hitBtn = true;
        }
        else
        {
            points[1] = transform.forward + new Vector3(0,0,20);
            hitBtn = false;
        }

        rend.SetPositions(points);
        rend.material.color = rend.startColor;
        return hitBtn;
    }

    public void ColorChangeOnClick()
    {
        if(btn != null)
        {
<<<<<<< Updated upstream
            if(btn.name == "red_button")
            {
                img.color = Color.red;
            }
            else if(btn.name == "blue_button")
            {
                img.color = Color.blue;
            }
            else if(btn.name == "green_button")
            {
                img.color = Color.green;
=======
            if(btn.name == "start_button")
            {
                imgs[0].color = Color.blue;
            }
            else if(btn.name == "sound_button")
            {
                if(imgs[0].color != Color.red)
                {
                    imgs[0].color= Color.red;
                }
                else
                {
                    imgs[0].color = Color.green;
                }
            }
            else if(btn.name == "exit_button")
            {
                imgs[0].color = Color.clear;
>>>>>>> Stashed changes
            }
        }
    }
}
