Synthetic Data Generation for Industrial Valve Detection

End-to-end pipeline using Unity, Blender assets, and YOLO-based object detection

This project was developed for an industrial inspection use case and reflects a real-world production-oriented pipeline.

This project demonstrates an end-to-end synthetic data pipeline for training an object detection model to recognize industrial valves.

**Overview:**
Starting from a 3D CAD model created in Blender, I built a Unity-based simulation environment to generate large-scale, labeled image datasets through randomized rendering. The resulting synthetic dataset was used to train an object detection model capable of detecting valves in diverse visual conditions.

**Problem Motivation:**
Obtaining large, well-labeled datasets for industrial inspection tasks is often expensive and time-consuming. Real-world images may be scarce, poorly labeled, or lack sufficient variability.

Synthetic data offers a scalable alternative, but requires careful domain randomization to ensure transferability to real-world images.

**Synthetic Data Generation:**
The synthetic dataset was generated using Unity with the following randomized parameters:

- Valve surface textures (material variations)
- Scene background images
- Camera position, rotation, and zoom

**For each randomized scene:**
1. A screenshot was rendered automatically
2. Ground-truth bounding box annotations were computed directly from the 3D object
3. An image file and corresponding JSON annotation were exported


**Unity Implementation:**
Custom Unity C# scripts were written to control the simulation:

- `RandomizeTexture.cs`: Applies randomized textures to the valve mesh
- `CameraRandomizer.cs`: Randomizes camera pose and field of view
- `ScreenshotExporter.cs`: Captures rendered images at fixed resolution
- `AnnotationExporter.cs`: Computes 2D bounding boxes from 3D object geometry and exports annotations in JSON format

**Dataset Format:**
Each generated sample consists of:
- RGB image (PNG)
- JSON file containing bounding box coordinates for the valve

Annotations were converted to YOLO format and uploaded to Roboflow for dataset management and training.

**Model Training:**
A YOLO-based object detection model was trained using the synthetic dataset.

Training was performed using Roboflow's pipeline, with standard data augmentation applied during training. The goal was to evaluate whether domain-randomized synthetic data could produce a robust detector for industrial valve imagery.

**Results:**
The trained model successfully detects valves across a wide range of textures, backgrounds, and camera viewpoints.

Qualitative results suggest strong generalization across synthetic variations.

**Takeaways:**
- Synthetic data can significantly reduce labeling costs for industrial vision tasks
- Domain randomization is critical for improving robustness
- Unity provides a flexible platform for scalable synthetic data generation


