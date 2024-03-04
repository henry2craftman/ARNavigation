// Converts between c string and NSString*. It needs to be returned as a copy of the c string so that Unity handles the memory and gets a valid value.
char* cStringCopy(const char* string)
{
    if (string == NULL)
        return NULL;
    char* res = (char*)malloc(strlen(string) + 1);
    strcpy(res, string);
    return res;
}



//In unity, You'd place this file in your "Assets>plugins>ios" folder
//Objective-C Code
#import <mobileffmpeg/MobileFFmpeg.h>

extern "C"
{
    /**
    * Returns FFmpeg version bundled within the library.
    *
    * @return FFmpeg version
    */
    /*char* _getFFmpegVersion()
    {
        // UTF8String method gets us a c string. Then we have to malloc a copy to give to Unity. I reuse a method below that makes it easy.
        return "nope";//cStringCopy([[MobileFFmpeg getFFmpegVersion] UTF8String]);
    }*/

    /**
    * Returns MobileFFmpeg library version.
    *
    * @return MobileFFmpeg version
    */
    /*char* _getVersion()
    {
        return cStringCopy(["nope"]);//cStringCopy([[MobileFFmpeg getVersion] UTF8String]);
    }*/

    /**
    * Synchronously executes FFmpeg with arguments provided.
    *
    * @param arguments FFmpeg command options/arguments as string array
    * @return zero on successful execution, 255 on user cancel and non-zero on error
    */
    /*int _executeWithArguments(const char* arguments)
    {
        //NSLog(@"Executing ffmpeg command: %@", @(cmd));
        return [MobileFFmpeg executeWithArguments: @(arguments)];
    }*/

    /**
    * Synchronously executes FFmpeg command provided. Space character is used to split command
    * into arguments.
    *
    * @param command FFmpeg command
    * @return zero on successful execution, 255 on user cancel and non-zero on error
    */
    int _execute(const char* command)
    {
        return [MobileFFmpeg execute: @(command)];
    }
    
    /**
    * Cancels an ongoing operation.
    *
    * This function does not wait for termination to complete and returns immediately.
    */
    void _cancel()
    {
        [MobileFFmpeg cancel];
    }

    /**
    * Returns return code of last executed command.
    *
    * @return return code of last executed command
    */
    /*int _getLastReturnCode()
    {
        return [MobileFFmpeg getLastReturnCode];
    }*/

    /**
    * Returns log output of last executed command. Please note that disabling redirection using
    * MobileFFmpegConfig.disableRedirection() method also disables this functionality.
    *
    * @return output of last executed command
    */
    /*char* _getLastCommandOutput()
    {
        return cStringCopy([[MobileFFmpeg getLastCommandOutput] UTF8String]);
    }*/

    /**
     * Returns MobileFFmpeg library build date.
     *
     * @return MobileFFmpeg library build date
     */
    /*char* _getBuildDate()
    {
        return cStringCopy([[MobileFFmpeg getBuildDate] UTF8String]);
    }*/

    /**
    * Parses the given command into arguments.
    *
    * @param command string command
    * @return array of arguments
    */
    /*char* _parseArguments(const char* command)
    {
        return cStringCopy([[MobileFFmpeg parseArguments: @(command)]; UTF8String]);
    }*/
}
