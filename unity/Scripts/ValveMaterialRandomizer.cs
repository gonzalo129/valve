{\rtf1\ansi\ansicpg1252\cocoartf2822
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\froman\fcharset0 Times-Roman;}
{\colortbl;\red255\green255\blue255;\red0\green0\blue0;}
{\*\expandedcolortbl;;\cssrgb\c0\c0\c0;}
\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\deftab720
\pard\pardeftab720\partightenfactor0

\f0\fs24 \cf0 \expnd0\expndtw0\kerning0
\outl0\strokewidth0 \strokec2 using UnityEngine;\
public class ValveMaterialRandomizer : MonoBehaviour\
\{\
\'a0\'a0\'a0\'a0[Tooltip(\'93Assign all materials from your folder here\'94)]\
\'a0\'a0\'a0\'a0public Material[] materialOptions;\
\'a0\'a0\'a0\'a0[Tooltip(\'93Root object of the valve (with multiple child parts)\'93)]\
\'a0\'a0\'a0\'a0public GameObject valveRoot;\
\'a0\'a0\'a0\'a0void Start()\
\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0ApplyRandomMaterials();\
\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0public void ApplyRandomMaterials()\
\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (materialOptions == null || materialOptions.Length == 0 || valveRoot == null)\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Debug.LogError(\'93Missing material options or valve root.\'93);\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0return;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0// Get all mesh renderers in the valve\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0var renderers = valveRoot.GetComponentsInChildren<MeshRenderer>();\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0foreach (var renderer in renderers)\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Material randomMat = materialOptions[Random.Range(0, materialOptions.Length)];\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0renderer.material = randomMat;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\}\
\}}