﻿using MaterialDesignThemes.Wpf;
using SacredUtils.resources.bin;
using SacredUtils.resources.dlg;
using System;
using System.Diagnostics;
using System.Windows;

namespace SacredUtils.resources.pgs
{
    // ReSharper disable once InconsistentNaming
    public partial class application_settings_two
    {
        int _eventSubsNum;

        public application_settings_two()
        {
            InitializeComponent();

            AppLogger.Log.Info("Initialization components for application settings two done!");
        }

        public void GetSettings()
        {
            UpdateCheckTglBtn.IsChecked = AppSettings.ApplicationSettings.CheckAutoUpdate;

            UpdateAlphaCheckTglBtn.IsChecked = AppSettings.ApplicationSettings.CheckAutoAlphaUpdate;

            MakeBackupTglBtn.IsChecked = AppSettings.ApplicationSettings.MakeAutoBackupConfigs;

            LicenseTglBtn.IsChecked = AppSettings.ApplicationSettings.AcceptLicense;

            if (_eventSubsNum == 0)
            {
                EventSubscribe(); _eventSubsNum++; 
            }
        }

        private void EventSubscribe()
        {
            UpdateCheckTglBtn.Click += (s, e) => ChangeUpdateCheck(false);
            UpdateAlphaCheckTglBtn.Click += (s, e) => ChangeUpdateCheck(true);
            MakeBackupTglBtn.Click += (s, e) => ChangeBackupMake();
            LicenseTglBtn.Click += (s, e) => ChangeLicenseAgreement();

            GitHubBtn.Click += (s, e) => OpenLink("https://github.com/MairwunNx/SacredUtils");
            DonateBtn.Click += (s, e) => OpenLink("https://money.yandex.ru/to/410015993365458");
            CreatorBtn.Click += (s, e) => OpenLink("https://t-do.ru/mairwunnx");
            FeedbackBtn.Click += (s, e) => OpenLink("https://docs.google.com/forms/d/1Hx4EcS7VopBFG4bxq-zdsGUmqqD2nKy2NiwzRTiQMgA/edit?usp=sharing");
            AboutBtn.Click += (s, e) => OpenAboutDialog();

            ToOnePageBtn.Click += (s, e) => OpenOnePage();
        }

        private void ChangeUpdateCheck(bool alphaUpdate)
        {
            if (!alphaUpdate)
            {
                AppSettings.ApplicationSettings.CheckAutoUpdate = UpdateCheckTglBtn.IsChecked == true;

                AppLogger.Log.Info($"Checking for updates set to {AppSettings.ApplicationSettings.CheckAutoUpdate} by user");
            }
            else
            {
                AppSettings.ApplicationSettings.CheckAutoAlphaUpdate = UpdateAlphaCheckTglBtn.IsChecked == true;

                AppLogger.Log.Info($"Checking for alpha updates set to {AppSettings.ApplicationSettings.CheckAutoAlphaUpdate} by user");
            }
        }

        private void ChangeBackupMake()
        {
            AppSettings.ApplicationSettings.MakeAutoBackupConfigs = MakeBackupTglBtn.IsChecked == true;

            AppLogger.Log.Info($"Backup making settings set to {AppSettings.ApplicationSettings.MakeAutoBackupConfigs} by user");
        }

        private void ChangeLicenseAgreement()
        {
            AppSettings.ApplicationSettings.AcceptLicense = LicenseTglBtn.IsChecked == true;

            AppLogger.Log.Info($"Accept license set to {AppSettings.ApplicationSettings.AcceptLicense} by user");
        }

        private static void OpenLink(string link)
        {
            Process.Start(link); AppLogger.Log.Info($"{link} link was opened by user");
        }

        private static void OpenAboutDialog()
        {
            try
            {
                about_dialog about = new about_dialog();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        ((MainWindow)window).DialogFrame.Visibility = Visibility.Visible;
                        ((MainWindow)window).DialogFrame.Content = about;
                    }
                }

                if (AppSettings.ApplicationSettings.ColorTheme == "dark")
                {
                    about.AboutDialog.DialogTheme = BaseTheme.Dark;
                }

                about.AboutDialog.IsOpen = true;

                AppLogger.Log.Info("About dialog was opened by user");
            }
            catch (Exception ex)
            {
                AppLogger.Log.Error("Failed to open about dialog!");
                AppLogger.Log.Error(ex.ToString);
            }
        }

        private static void OpenOnePage()
        {
            try
            {
                foreach (Window window in Application.Current.Windows)
                {
                    ((MainWindow)window).SettingsFrame.Content = InitializeApplicationSettings.AppStgOne;

                    AppLogger.Log.Info("Application settings one page was opened by user");
                }
            }
            catch (Exception ex)
            {
                AppLogger.Log.Error("An error occurred while user opened aso page");
                AppLogger.Log.Error(ex.ToString);
            }
        }
    }
}
