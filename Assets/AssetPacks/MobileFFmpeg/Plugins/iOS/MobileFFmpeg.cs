using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public class MobileFFmpeg : MonoBehaviour
{
    // For the most part, imports match the function defined in the iOS code, except char* is replaced with string here so it gets a C# string.
#if UNITY_IPHONE
    //[DllImport("__Internal")]
    //private static extern string _getFFmpegVersion();

    //[DllImport("__Internal")]
    //private static extern string _getVersion();

    //[DllImport("__Internal")]
    //private static extern int _executeWithArguments(string arguments);

    [DllImport("__Internal")]
    private static extern int _execute(string command);

    [DllImport("__Internal")]
    private static extern void _cancel();

    //[DllImport("__Internal")]
    //private static extern int _getLastReturnCode();

    //[DllImport("__Internal")]
    //private static extern string _getLastCommandOutput();

    //[DllImport("__Internal")]
    //private static extern string _getBuildDate();

    //[DllImport("__Internal")]
    //private static extern string _parseArguments(string command);
#endif




    // Methods providing the iOS functionality
    #region UnityCallableMethods
    /**
    * Returns FFmpeg version bundled within the library.
    *
    * @return FFmpeg version
    */
    /*public static string GetFFmpegVersion()
    {
        string ffmpegVersion = "UNKNOWN";

#if UNITY_IPHONE
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            ffmpegVersion = _getFFmpegVersion();
        }
#endif

        return ffmpegVersion;
    }*/

    /**
     * Returns MobileFFmpeg library version.
     *
     * @return MobileFFmpeg version
     */
    /*public static string GetVersion()
    {
        string mobileFFmpegVersion = "UNKNOWN";

#if UNITY_IPHONE
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            mobileFFmpegVersion = _getVersion();
        }
#endif

        return mobileFFmpegVersion;
    }*/

    /**
     * Synchronously executes FFmpeg with arguments provided.
     *
     * @param arguments FFmpeg command options/arguments as string array
     * @return zero on successful execution, 255 on user cancel and non-zero on error
     */
    /*public static int ExecuteWithArguments(string arguments)
    {
        int result = -1;
        // We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
#if UNITY_IPHONE
        // Now we check that it's actually an iOS device/simulator, not the Unity Player. You only get plugins on the actual device or iOS Simulator.
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            result = _executeWithArguments(arguments);
        }
#endif

        return result;
    }*/

    /**
     * Synchronously executes FFmpeg command provided. Space character is used to split command
     * into arguments.
     *
     * @param command FFmpeg command
     * @return zero on successful execution, 255 on user cancel and non-zero on error
     */
    public static int Execute(string command)
    {
        int result = -1;
        // We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
#if UNITY_IPHONE
        // Now we check that it's actually an iOS device/simulator, not the Unity Player. You only get plugins on the actual device or iOS Simulator.
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            result = _execute(command);
        }
#endif

        return result;
    }

    /**
     * Cancels an ongoing operation.
     *
     * This function does not wait for termination to complete and returns immediately.
     */
    public static void Cancel()
    {
        // We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
#if UNITY_IPHONE
        // Now we check that it's actually an iOS device/simulator, not the Unity Player. You only get plugins on the actual device or iOS Simulator.
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _cancel();
        }
#endif
    }

    /**
    * Returns return code of last executed command.
    *
    * @return return code of last executed command
    */
    /*public static int GetLastReturnCode()
    {
        int result = -1;
        // We check for UNITY_IPHONE again so we don't try this if it isn't iOS platform.
#if UNITY_IPHONE
        // Now we check that it's actually an iOS device/simulator, not the Unity Player. You only get plugins on the actual device or iOS Simulator.
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            result = _getLastReturnCode();
        }
#endif

        return result;
    }*/

    /**
    * Returns log output of last executed command. Please note that disabling redirection using
    * MobileFFmpegConfig.disableRedirection() method also disables this functionality.
    *
    * @return output of last executed command
    */
    /*public static string GetLastCommandOutput()
    {
        string lastCommand = "UNKNOWN";

#if UNITY_IPHONE
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            lastCommand = _getLastCommandOutput();
        }
#endif

        return lastCommand;
    }*/

    /**
     * Returns MobileFFmpeg library build date.
     *
     * @return MobileFFmpeg library build date
     */
    /*public static string GetBuildDate()
    {
        string lastCommand = "UNKNOWN";

#if UNITY_IPHONE
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            lastCommand = _getBuildDate();
        }
#endif

        return lastCommand;
    }*/

    /**
    * Parses the given command into arguments.
    *
    * @param command string command
    * @return array of arguments
    */
    /*public static string ParseArguments(string command)
    {
        string parsedArguments = "UNKNOWN";

#if UNITY_IPHONE
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            parsedArguments = _parseArguments(command);
        }
#endif

        return parsedArguments;
    }*/
    #endregion
}