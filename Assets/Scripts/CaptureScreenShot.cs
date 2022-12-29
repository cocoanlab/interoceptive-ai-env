using System.IO;
using UnityEngine;
using Unity.MLAgents;

public class CaptureScreenShot : MonoBehaviour
{
        private int takes = 0;
        public bool recordEnable;

        private EnvironmentParameters m_ResetParams;

        public void Awake()
        {
                Academy.Instance.OnEnvironmentReset += SetParameters;
        }

        // Use this for initialization
        void Start()
        {
                SetParameters();
        }

        void SetParameters()
        {
                // Setting parameters from python
                m_ResetParams = Academy.Instance.EnvironmentParameters;
                recordEnable = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("recordEnable", 0));
        }

        public void CaptureImage()
        {
                takes = takes + 1;

                var mediaOutputFolder = Path.Combine(Application.dataPath, "..", "SampleRecordings");

                DirectoryInfo directoryInfo = new DirectoryInfo(mediaOutputFolder);
                if (!directoryInfo.Exists)
                {
                        directoryInfo.Create();
                }

                string s_takes = takes.ToString();
                ScreenCapture.CaptureScreenshot(Path.Combine(mediaOutputFolder, "record_") + s_takes.PadLeft(5, '0') + ".png");
        }

}

// #if UNITY_EDITOR

// using System.IO;
// using UnityEngine;
// using UnityEditor.Recorder;
// using UnityEditor.Recorder.Input;
// using Unity.MLAgents;

// // namespace UnityEngine.Recorder.Examples
// // {

// // namespace CaptureScreenShotClass
// // {
// public class CaptureScreenShot : MonoBehaviour
// {
//         public int outputWidth;
//         public int outputHeight;

//         public bool recordEnable;
//         RecorderController m_RecorderController;
//         private EnvironmentParameters m_ResetParams;


//         void OnEnable()
//         {
//                 m_ResetParams = Academy.Instance.EnvironmentParameters;
//                 recordEnable = System.Convert.ToBoolean(m_ResetParams.GetWithDefault("recordEnable", 0));
//                 outputWidth = (int)m_ResetParams.GetWithDefault("outputWidth", 1000);
//                 outputHeight = (int)m_ResetParams.GetWithDefault("outputHeight", 1000);

//                 var controllerSettings = ScriptableObject.CreateInstance<RecorderControllerSettings>();
//                 m_RecorderController = new RecorderController(controllerSettings);

//                 var mediaOutputFolder = Path.Combine(Application.dataPath, "..", "SampleRecordings");

//                 // Image
//                 var imageRecorder = ScriptableObject.CreateInstance<ImageRecorderSettings>();
//                 imageRecorder.name = "My Image Recorder";
//                 imageRecorder.Enabled = true;
//                 imageRecorder.OutputFormat = ImageRecorderSettings.ImageRecorderOutputFormat.PNG;
//                 imageRecorder.CaptureAlpha = false;
//                 imageRecorder.OutputFile = Path.Combine(mediaOutputFolder, "image_") + DefaultWildcard.Take;
//                 imageRecorder.imageInputSettings = new GameViewInputSettings
//                 {
//                         OutputWidth = outputWidth,
//                         OutputHeight = outputHeight,
//                 };

//                 // Setup Recording
//                 controllerSettings.AddRecorderSettings(imageRecorder);
//                 controllerSettings.SetRecordModeToSingleFrame(0);

//         }
//         void OnGUI()
//         {
//                 if (Input.GetKeyUp("r"))
//                 {
//                         m_RecorderController.PrepareRecording();
//                         m_RecorderController.StartRecording();
//                 }
//         }

//         public void CaptureImage()
//         {
//                 m_RecorderController.PrepareRecording();
//                 m_RecorderController.StartRecording();
//         }

// }
// // }
// // }

// #endif