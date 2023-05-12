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
