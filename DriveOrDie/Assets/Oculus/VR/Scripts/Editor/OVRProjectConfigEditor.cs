using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OVRProjectConfig))]
public class OVRProjectConfigEditor : Editor
{
	override public void OnInspectorGUI()
	{
		OVRProjectConfig projectConfig = (OVRProjectConfig)target;
		DrawTargetDeviceInspector(projectConfig);
		EditorGUILayout.Space();
		DrawProjectConfigInspector(projectConfig);
	}

	public static void DrawTargetDeviceInspector(OVRProjectConfig projectConfig)
	{
		// Target Devices
		EditorGUILayout.LabelField("Target Devices", EditorStyles.boldLabel);
#if PRIORITIZE_OCULUS_XR_SETTINGS
		EditorGUILayout.LabelField("Configure Target Devices in Oculus XR Plugin Settings.");
#else
		bool hasModified = false;

		foreach (OVRProjectConfig.DeviceType deviceType in System.Enum.GetValues(typeof(OVRProjectConfig.DeviceType)))
		{
			bool oldSupportsDevice = projectConfig.targetDeviceTypes.Contains(deviceType);
			bool newSupportsDevice = oldSupportsDevice;
			OVREditorUtil.SetupBoolField(projectConfig, ObjectNames.NicifyVariableName(deviceType.ToString()), ref newSupportsDevice, ref hasModified);

			if (newSupportsDevice && !oldSupportsDevice)
			{
				projectConfig.targetDeviceTypes.Add(deviceType);
			}
			else if (oldSupportsDevice && !newSupportsDevice)
			{
				projectConfig.targetDeviceTypes.Remove(deviceType);
			}
		}

		if (hasModified)
		{
			OVRProjectConfig.CommitProjectConfig(projectConfig);
		}
#endif
	}

	public static void DrawProjectConfigInspector(OVRProjectConfig projectConfig)
	{
		bool hasModified = false;
		EditorGUILayout.LabelField("Quest Features", EditorStyles.boldLabel);

		// Show overlay support option
		EditorGUI.BeginDisabledGroup(true);
		EditorGUILayout.Toggle(new GUIContent("Focus Aware (Required)",
			"If checked, the new overlay will be displayed when the user presses the home button. The game will not be paused, but will now receive InputFocusLost and InputFocusAcquired events."), true);
		EditorGUI.EndDisabledGroup();

		// Hand Tracking Support
		OVREditorUtil.SetupEnumField(projectConfig, "Hand Tracking Support", ref projectConfig.handTrackingSupport, ref hasModified);

		OVREditorUtil.SetupEnumField(projectConfig, new GUIContent("Hand Tracking Frequency",
			"Note that a higher tracking frequency will reserve some performance headroom from the application's budget."),
			ref projectConfig.handTrackingFrequency, ref hasModified, "https://developer.intern.oculus.com/documentation/unity/unity-handtracking/#enable-hand-tracking");


		// System Keyboard Support
		OVREditorUtil.SetupBoolField(projectConfig, new GUIContent("Requires System Keyboard",
			"If checked, the Oculus System keyboard will be enabled for Unity input fields and any calls to open/close the Unity TouchScreenKeyboard."),
			ref projectConfig.requiresSystemKeyboard, ref hasModified);

		// System Splash Screen
		OVREditorUtil.SetupTexture2DField(projectConfig, new GUIContent("System Splash Screen",
			"If set, the Splash Screen will be presented by the Operating System as a high quality composition layer at launch time."),
			ref projectConfig.systemSplashScreen, ref hasModified);

		// Allow optional 3-dof head-tracking
		OVREditorUtil.SetupBoolField(projectConfig, new GUIContent("Allow Optional 3DoF Head Tracking",
			"If checked, application can work in both 6DoF and 3DoF modes. It's highly recommended to keep it unchecked unless your project strongly needs the 3DoF head tracking."),
			ref projectConfig.allowOptional3DofHeadTracking, ref hasModified);

		EditorGUI.EndDisabledGroup();
		EditorGUILayout.Space();

		EditorGUILayout.LabelField("Android Build Settings", EditorStyles.boldLabel);

		// Show overlay support option
		OVREditorUtil.SetupBoolField(projectConfig, new GUIContent("Skip Unneeded Shaders",
			"If checked, prevent building shaders that are not used by default to reduce time spent when building."),
			ref projectConfig.skipUnneededShaders, ref hasModified);

		EditorGUI.EndDisabledGroup();
		EditorGUILayout.Space();

		EditorGUILayout.LabelField("Security", EditorStyles.boldLabel);
		OVREditorUtil.SetupInputField(projectConfig, "Custom Security XML Path", ref projectConfig.securityXmlPath, ref hasModified);
		OVREditorUtil.SetupBoolField(projectConfig, "Disable Backups", ref projectConfig.disableBackups, ref hasModified);
		OVREditorUtil.SetupBoolField(projectConfig, "Enable NSC Configuration", ref projectConfig.enableNSCConfig, ref hasModified);

		EditorGUI.EndDisabledGroup();
		EditorGUILayout.Space();

		EditorGUILayout.LabelField("Experimental", EditorStyles.boldLabel);
		// Experimental Features Enabled
		OVREditorUtil.SetupBoolField(projectConfig, new GUIContent("Experimental Features Enabled",
			"If checked, this application can use experimental features. Note that such features are for developer use only. This option must be disabled when submitting to the Oculus Store."),
			ref projectConfig.experimentalFeaturesEnabled, ref hasModified);
		EditorGUI.BeginDisabledGroup(!projectConfig.experimentalFeaturesEnabled);
		OVREditorUtil.SetupBoolField(projectConfig, new GUIContent("Passthrough Capability Enabled",
			"If checked, this application can use passthrough functionality. This option must be enabled at build time, otherwise initializing passthrough and creating passthrough layers in application scenes will fail."),
			ref projectConfig.insightPassthroughEnabled, ref hasModified);
		EditorGUI.EndDisabledGroup();

		// apply any pending changes to project config
		if (hasModified)
		{
			OVRProjectConfig.CommitProjectConfig(projectConfig);
		}
	}
}
