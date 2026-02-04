{\rtf1\ansi\ansicpg1252\cocoartf2822
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\froman\fcharset0 Times-Roman;}
{\colortbl;\red255\green255\blue255;\red22\green21\blue22;}
{\*\expandedcolortbl;;\cssrgb\c11373\c10980\c11373;}
\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\deftab720
\pard\pardeftab720\partightenfactor0

\f0\fs24 \cf2 \expnd0\expndtw0\kerning0
\outl0\strokewidth0 \strokec2 using UnityEngine;\
public class RandomCameraZoom : MonoBehaviour\
\{\
\'a0\'a0\'a0\'a0[Header(\'93Zoom Parameters\'94)]\
\'a0\'a0\'a0\'a0public float minFOV = 20f;\'a0 // Minimum zoom (narrow view)\
\'a0\'a0\'a0\'a0public float maxFOV = 60f;\'a0 // Maximum zoom (wide view)\
\'a0\'a0\'a0\'a0[Header(\'93Timing\'94)]\
\'a0\'a0\'a0\'a0public bool zoomEveryFrame = false;\'a0 // Toggle if you want to zoom every frame or manually\
\'a0\'a0\'a0\'a0public float zoomInterval = 1.0f;\'a0\'a0\'a0\'a0 // Time between zooms (if zoomEveryFrame is true)\
\'a0\'a0\'a0\'a0private Camera cam;\
\'a0\'a0\'a0\'a0private float timer;\
\'a0\'a0\'a0\'a0void Start()\
\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0cam = GetComponent<Camera>();\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (cam == null)\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Debug.LogError(\'93RandomCameraZoom script must be attached to a Camera.\'93);\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0// Apply initial random zoom\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0ApplyRandomZoom();\
\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0void Update()\
\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (!zoomEveryFrame) return;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0timer += Time.deltaTime;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (timer >= zoomInterval)\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0ApplyRandomZoom();\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0timer = 0f;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0public void ApplyRandomZoom()\
\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (cam == null) return;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0float randomFOV = Random.Range(minFOV, maxFOV);\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0cam.fieldOfView = randomFOV;\
\'a0\'a0\'a0\'a0\}\
\}\
}