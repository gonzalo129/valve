{\rtf1\ansi\ansicpg1252\cocoartf2822
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\froman\fcharset0 Times-Roman;}
{\colortbl;\red255\green255\blue255;\red0\green0\blue0;}
{\*\expandedcolortbl;;\cssrgb\c0\c0\c0;}
\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\deftab720
\pard\pardeftab720\partightenfactor0

\f0\fs24 \cf0 \expnd0\expndtw0\kerning0
\outl0\strokewidth0 \strokec2 using UnityEngine;\
using UnityEngine.Rendering;\
using UnityEngine.Rendering.HighDefinition;\
public class HDRISkyRandomizer : MonoBehaviour\
\{\
\'a0\'a0\'a0\'a0[Tooltip(\'93HDRI Cubemaps to choose from\'94)]\
\'a0\'a0\'a0\'a0public Cubemap[] skyCubemaps;\
\'a0\'a0\'a0\'a0[Tooltip(\'93Reference to the Global Volume in your scene\'94)]\
\'a0\'a0\'a0\'a0public Volume globalVolume;\
\'a0\'a0\'a0\'a0private HDRISky hdriSky;\
\'a0\'a0\'a0\'a0void Awake()\
\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (globalVolume == null)\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Debug.LogError(\'93Global Volume not assigned!\'93);\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0return;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0// Try to get the HDRISky override from the volume\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (!globalVolume.sharedProfile.TryGet(out hdriSky))\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Debug.LogError(\'93HDRISky override not found in the volume profile!\'93);\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0public void ApplyRandomSky()\
\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (hdriSky == null || skyCubemaps == null || skyCubemaps.Length == 0)\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Debug.LogWarning(\'93HDRI Sky or cubemap list is invalid.\'93);\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0return;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0// Filter out nulls just in case\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Cubemap[] validCubemaps = System.Array.FindAll(skyCubemaps, c => c != null);\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (validCubemaps.Length == 0)\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Debug.LogError(\'93All HDRI sky cubemaps are null!\'93);\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0return;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0// Pick a random cubemap\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Cubemap randomSky = validCubemaps[Random.Range(0, validCubemaps.Length)];\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0hdriSky.hdriSky.value = randomSky;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0// Ensure HDRI Sky is the active sky type in the Visual Environment override\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (globalVolume.sharedProfile.TryGet(out VisualEnvironment visualEnv))\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0visualEnv.skyType.Override((int)SkyType.HDRISky);\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0// Nudge the system to ensure the sky updates\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0hdriSky.rotation.value += 0.001f;\'a0 // Tiny value to force change\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0hdriSky.active = false;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0hdriSky.active = true;\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0// Explicitly request the sky environment update\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0if (RenderPipelineManager.currentPipeline is HDRenderPipeline pipeline)\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\{\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0pipeline.RequestSkyEnvironmentUpdate();\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0\}\
\'a0\'a0\'a0\'a0\'a0\'a0\'a0\'a0Debug.Log(\'93Applied HDRI: \'94 + randomSky.name);\
\'a0\'a0\'a0\'a0\}\
\}}