﻿using System;
using System.IO;
using System.Windows;
using MaterialDesignThemes.Wpf;
using SacredUtils.resources.dlg;
using static SacredUtils.SourceFiles.settings.ApplicationSettingsManager;
using Theme = SacredUtils.SourceFiles.theme.Theme;

namespace SacredUtils.SourceFiles.bin
{
    public static class GetApplicationLicenseState
    {
        public static void GetLicenseState()
        {
            Directory.CreateDirectory($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils");

            if (!File.Exists($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su") || !File.Exists("License.txt"))
            {
                File.WriteAllBytes("License.txt", Properties.Resources.License);
                File.WriteAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su", "false");
                MainWindow.MainWindowInstance.UpdateLbl.IsEnabled = false; MainWindow.MainWindowInstance.MinimizeBtn.IsEnabled = false;
                OpenLicenseDialog();
            }
            else if (File.ReadAllText($"{Environment.ExpandEnvironmentVariables("%appdata%")}\\SacredUtils\\LicenseAgreement.su").Contains("false"))
            {
                File.WriteAllBytes("License.txt", Properties.Resources.License);
                MainWindow.MainWindowInstance.UpdateLbl.IsEnabled = false; MainWindow.MainWindowInstance.MinimizeBtn.IsEnabled = false;
                OpenLicenseDialog();
            }
        }

        private static void OpenLicenseDialog()
        {
            ApplicationLicenseDialog applicationLicenseDialog = new ApplicationLicenseDialog();
            MainWindow.MainWindowInstance.DialogFrame.Visibility = Visibility.Visible;
            MainWindow.MainWindowInstance.DialogFrame.Content = applicationLicenseDialog;

            if (Settings.ApplicationUiTheme == Theme.Dark)
            {
                applicationLicenseDialog.BaseDialog.DialogTheme = BaseTheme.Dark;
            }

            applicationLicenseDialog.BaseDialog.IsOpen = true;
        }
    }
}
