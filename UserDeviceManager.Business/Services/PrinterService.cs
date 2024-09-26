using UserDeviceManager.Business.Interfaces;

namespace UserDeviceManager.Business.Services;

public class PrinterService : IDeviceAction, IPrinterService
{
    public string PerformeAction()
    {
        return "Printing...";
    }
}
