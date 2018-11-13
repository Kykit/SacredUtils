﻿using System;
using System.Runtime.InteropServices;
using static SacredUtils.AppLogger;

namespace SacredUtils.resources.bin
{
    public static class PrintToLogBaseApplicationInfo
    {
        public static void Print()
        {
            if (!AppSettings.ApplicationSettings.DisablePrintBaseInfoToLog)
            {
                Log.Info("============================================================");

                Log.Info(AppSummary.Type == "Alpha"
                    ? $"Starting {AppSummary.Name} configurator version {AppSummary.AVersion}"
                    : $"Starting {AppSummary.Name} configurator version {AppSummary.Version}");

                Log.Info($"You have launched an official {AppSummary.Type} build");
                Log.Info($"Current launched SacredUtils app name {AppSummary.CurrentExe}");

                Log.Info(AppDomain.CurrentDomain.IsFullyTrusted // I LOVE PUTIN ❤❤❤❤
                    ? "Current launched SacredUtils application is fully trusted"
                    : "Current launched SacredUtils application is not fully trusted");

                Log.Info($"Version of the common language runtime {Environment.Version}");
                Log.Info($"Full version of the common language runtime {RuntimeInformation.FrameworkDescription}");

                Log.Info($"OS version {Environment.OSVersion.VersionString} {RuntimeInformation.OSArchitecture} bit");

                Log.Info($"Current monitor resolution is {ScreenResolution.ScreenX}x{ScreenResolution.ScreenY} (Primary Screen)");

                Log.Info($"Bitness of the current SacredUtils process {RuntimeInformation.ProcessArchitecture} bit");

                Log.Info($"Allocated memory for SacredUtils {Environment.WorkingSet / 1024 / 1024} MB or {Environment.WorkingSet / 1024} KB");

                Log.Info($"Running by current user name profile {Environment.UserName}");

                Log.Info($"SacredUtils current domain assemblies count {AppDomain.CurrentDomain.GetAssemblies().Length}");

                Log.Info("Involved dirs (6) : conf, logs, back, thms, lang");

                Log.Info("============================================================");
            }
        }
    }
}
