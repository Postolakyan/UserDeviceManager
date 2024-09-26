using System.Reflection;
using UserDeviceManager.Business.Interfaces;
using UserDeviceManager.Business.Models;
using System.Drawing.Printing;

namespace UserDeviceManager.Business.Services;

public class PrinterService : IDeviceAction, IPrinterService
{
    public string PerformeAction()
    {
        return "Printing...";
    }
}
