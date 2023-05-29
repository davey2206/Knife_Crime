using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class TourniquetIndicatorBehaviour : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] UnityEngine.UI.Image turnIndicator;
    [SerializeField] int spinToWin = 3;
    [SerializeField] int unwindSpeed = 2;
    float turnIndicatorRadiusTrim = 15f;

    private RectTransform canvasRect;
    private RectTransform rectTransform;
    private UnityEngine.Vector3 indicatorPos;
    private UnityEngine.Vector3 indicatorSize;
    private float indicatorOuterRadius;
    private float indicatorInnerRadius;
    private UnityEngine.Vector2 canvasMousePos;
    private const float centerRadiusRatio = 2;
    private UnityEngine.UI.Image img;

    private float lastAngle=90;
    private bool mouseButtonHeld = false;
    private volatile int turnCount;
    private bool startedTurning = false;
    private float currProgIndicatorAngle;
    private volatile bool unwinding;
    private bool wasTurningLastFrame;
    private bool playing = true;
    

    private float getMouseAngle()
    {
        return (Mathf.Atan2(canvasMousePos.y - indicatorPos.y, canvasMousePos.x - indicatorPos.x) * 180)/Mathf.PI;

        //return UnityEngine.Vector3.Angle(indicatorPos, canvasMousePos);
    }

    private bool isMouseOverIndicator()
    {
        bool isMouseOver = false;

        canvasMousePos = Input.mousePosition / canvas.scaleFactor;
        canvasMousePos.x += canvasRect.rect.position.x;
        canvasMousePos.y += canvasRect.rect.position.y;

        float DistanceFromInd = Mathf.Sqrt(Mathf.Pow(canvasMousePos.x - indicatorPos.x, 2f) + Mathf.Pow(canvasMousePos.y - indicatorPos.y, 2f));
        if (DistanceFromInd < indicatorOuterRadius && DistanceFromInd > indicatorInnerRadius)
        {
            isMouseOver = true;
        }
        return isMouseOver;
    }

    private void unwind() //unwind animation
    {
        if (unwinding)
        {
            lastAngle = ((lastAngle + unwindSpeed) % 360);

            if (turnCount <= 0)
            {  
                if (lastAngle <= 90 && lastAngle > 86) { unwinding = false; turnCount = 0; }
            } else {
                if (lastAngle <= 90 && lastAngle > 86) { turnCount = turnCount - 1; }
            }

            moveIndicatorToAngle(lastAngle);
        }
    }

    private void moveIndicatorToAngle(float angle)
    {
        angle = (angle * Mathf.PI) / 180;
        turnIndicator.rectTransform.position = rectTransform.position + new UnityEngine.Vector3(Mathf.Cos(angle) * (indicatorInnerRadius + turnIndicatorRadiusTrim), Mathf.Sin(angle) * (indicatorInnerRadius + turnIndicatorRadiusTrim), 0f); ;
    }

    // Start is called before the first frame update
    void Start()
    {
        //prepare size & position variables
        rectTransform = GetComponent<RectTransform>();
        indicatorPos = rectTransform.localPosition;
        indicatorSize = rectTransform.localScale;
        indicatorOuterRadius = rectTransform.rect.width / 2;
        indicatorInnerRadius = indicatorOuterRadius / centerRadiusRatio;
        canvasRect = canvas.GetComponent<RectTransform>();
        img = this.GetComponent<UnityEngine.UI.Image>();
        moveIndicatorToAngle(90f);
    }

    public bool StartTourniquetMiniGame() 
    {
        if (playing)
        {
            if (isMouseOverIndicator())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    mouseButtonHeld = true;
                }
                if (Input.GetMouseButtonUp(0))
                {
                    mouseButtonHeld = false;
                }

                if (mouseButtonHeld) //if held. Start counting turns from here
                {
                    if (!startedTurning)
                    {
                        img.color = Color.red;
                        startedTurning = true;
                        turnCount = 0;

                    }
                    else
                    {
                        if (lastAngle > 90f && getMouseAngle() < 90f) { turnCount++; }
                        lastAngle = getMouseAngle();
                        moveIndicatorToAngle(lastAngle);
                        Debug.Log("COUNTED " + turnCount);
                        wasTurningLastFrame = true;
                        //reduce stress here

                        if (turnCount == spinToWin)
                        {
                            Debug.Log("PLAYER 1 SAVES THE DAY");
                            playing = false;
                            //disable timer here, handle other win calls.
                        }
                    }
                }
                else
                {
                    startedTurning = false;
                    moveIndicatorToAngle(Mathf.Floor(lastAngle));
                    if (wasTurningLastFrame == true)
                    {
                        Debug.Log("You let go! unwinding...");
                        wasTurningLastFrame = false;
                        unwinding = true;
                    }
                    unwind();
                    img.color = Color.grey;

                }
            }
            else
            {
                mouseButtonHeld = false;
                startedTurning = false;
                img.color = Color.white;
                moveIndicatorToAngle(Mathf.Floor(lastAngle));
                if (wasTurningLastFrame == true)
                {
                    Debug.Log("Your hands slipped! unwinding...");
                    wasTurningLastFrame = false;
                    unwinding = true;
                }
                unwind();
            }
        }
        return playing;
    }
}
