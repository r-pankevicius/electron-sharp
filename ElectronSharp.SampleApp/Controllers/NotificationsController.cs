﻿using Microsoft.AspNetCore.Mvc;
using ElectronSharp.API;
using ElectronSharp.API.Entities;

namespace ElectronSharp.SampleApp.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Index()
        {
            if(HybridSupport.IsElectronActive)
            {
                Electron.IpcMain.On("basic-noti", (args) => {

                    var options = new NotificationOptions("Basic Notification", "Short message part")
                    {
                        OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync("Notification clicked")
                    };

                    Electron.Notification.Show(options);

                });

                Electron.IpcMain.On("advanced-noti", (args) => {

                    var options = new NotificationOptions("Notification with image", "Short message plus a custom image")
                    {
                        OnClick = async () => await Electron.Dialog.ShowMessageBoxAsync("Notification clicked"),
                        Icon = "/assets/img/programming.png"
                    };

                    Electron.Notification.Show(options);
                });
            }

            return View();
        }
    }
}