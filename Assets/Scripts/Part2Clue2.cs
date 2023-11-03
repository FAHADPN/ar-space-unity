using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Google.XR.ARCoreExtensions;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using TMPro;
using AR_Fukuoka;

namespace AR_Fukuoka
    {
    public class Part2Clue2 : MonoBehaviour
    {
        public AREarthManager EarthManager;
        public VpsInitializer Initializer;
        public Text OutputText;
        public double HeadingThreshold = 25;
        public double HorizontalThreshold = 20;
        public double Latitude;
        public double Longitude;
        public double Altitude;
        public double Heading;
        public GameObject ContentPrefab;
        GameObject displayObject;
        public ARAnchorManager AnchorManager;


        void Update()
        {
            string status = "";
            if (!Initializer.IsReady || EarthManager.EarthTrackingState != TrackingState.Tracking)
            {
                return;
            }
            GeospatialPose pose = EarthManager.CameraGeospatialPose;

            if (displayObject == null)
            {
                Altitude = pose.Altitude - 1.5f;
                Quaternion quaternion = Quaternion.AngleAxis(180f - (float)Heading, Vector3.up);
                ARGeospatialAnchor anchor = AnchorManager.AddAnchor(Latitude, Longitude, Altitude, quaternion);
                if (anchor != null)
                {
                    displayObject = Instantiate(ContentPrefab, anchor.transform);
                }
            }
            ShowTrackingInfo(status, pose);

            void ShowTrackingInfo(string status, GeospatialPose pose)
            {
                OutputText.text = string.Format(
                    "Latitude/Longitude: {0}°, {1}°\n" +
                    "Horizontal Accuracy: {2}m\n" +
                    "Altitude: {3}m\n" +
                    "Vertical Accuracy: {4}m\n" +
                    "Heading: {5}°\n" +
                    "Heading Accuracy: {6}°\n" +
                    "{7} \n",
                    pose.Latitude.ToString("F6"),  //{0}
                    pose.Longitude.ToString("F6"), //{1}
                    pose.HorizontalAccuracy.ToString("F6"), //{2}
                    pose.Altitude.ToString("F2"),  //{3}
                    pose.VerticalAccuracy.ToString("F2"),  //{4}
                    pose.Heading.ToString("F1"),   //{5}
                    pose.HeadingAccuracy.ToString("F1"),   //{6}
                    status //{7}
                );
            }
        }
    }
}
