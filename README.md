{\rtf1\ansi\ansicpg1252\cocoartf2822
\cocoatextscaling0\cocoaplatform0{\fonttbl\f0\froman\fcharset0 Times-Bold;\f1\froman\fcharset0 Times-Roman;}
{\colortbl;\red255\green255\blue255;\red0\green0\blue0;}
{\*\expandedcolortbl;;\cssrgb\c0\c0\c0;}
\margl1440\margr1440\vieww11520\viewh8400\viewkind0
\deftab720
\pard\pardeftab720\partightenfactor0

\f0\b\fs26 \cf0 \expnd0\expndtw0\kerning0
\outl0\strokewidth0 \strokec2 Synthetic Data Generation for Industrial Valve Detection\

\f1\b0 \

\f0\b End-to-end pipeline using Unity, Blender assets, and YOLO-based object detection\

\f1\b0 \
\pard\pardeftab720\partightenfactor0

\fs24 \cf0 \strokec2 \'93This project was developed for an industrial inspection use case and reflects a real-world production-oriented pipeline.\'94
\fs26 \strokec2 \
\pard\pardeftab720\partightenfactor0
\cf0 \
This project demonstrates an end-to-end synthetic data pipeline for training an object detection model to recognize industrial valves.\
\

\f0\b Overview
\f1\b0 :\
Starting from a 3D CAD model created in Blender, I built a Unity-based simulation environment to generate large-scale, labeled image datasets through randomized rendering. The resulting synthetic dataset was used to train an object detection model capable of detecting valves in diverse visual conditions.\
\

\f0\b Problem Motivation:\

\f1\b0 Obtaining large, well-labeled datasets for industrial inspection tasks is often expensive and time-consuming. Real-world images may be scarce, poorly labeled, or lack sufficient variability.\
\
Synthetic data offers a scalable alternative, but requires careful domain randomization to ensure transferability to real-world images.\
\

\f0\b Synthetic Data Generation:\

\f1\b0 The synthetic dataset was generated using Unity with the following randomized parameters:\
\
- Valve surface textures (material variations)\
- Scene background images\
- Camera position, rotation, and zoom\
\

\f0\b For each randomized scene:\

\f1\b0 1. A screenshot was rendered automatically\
2. Ground-truth bounding box annotations were computed directly from the 3D object\
3. An image file and corresponding JSON annotation were exported\
\
\

\f0\b Unity Implementation:\

\f1\b0 Custom Unity C# scripts were written to control the simulation:\
\
- `RandomizeTexture.cs`: Applies randomized textures to the valve mesh\
- `CameraRandomizer.cs`: Randomizes camera pose and field of view\
- `ScreenshotExporter.cs`: Captures rendered images at fixed resolution\
- `AnnotationExporter.cs`: Computes 2D bounding boxes from 3D object geometry and exports annotations in JSON format\
\

\f0\b Dataset Format:
\f1\b0 \
Each generated sample consists of:\
- RGB image (PNG)\
- JSON file containing bounding box coordinates for the valve\
\
Annotations were converted to YOLO format and uploaded to Roboflow for dataset management and training.\
\

\f0\b Model Training:
\f1\b0 \
A YOLO-based object detection model was trained using the synthetic dataset.\
\
Training was performed using Roboflow's pipeline, with standard data augmentation applied during training. The goal was to evaluate whether domain-randomized synthetic data could produce a robust detector for industrial valve imagery.\
\

\f0\b Results:
\f1\b0 \
The trained model successfully detects valves across a wide range of textures, backgrounds, and camera viewpoints.\
\
Qualitative results suggest strong generalization across synthetic variations.\
\

\f0\b Takeaways:
\f1\b0 \
- Synthetic data can significantly reduce labeling costs for industrial vision tasks\
- Domain randomization is critical for improving robustness\
- Unity provides a flexible platform for scalable synthetic data generation\
\
\
}