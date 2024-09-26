using UserDeviceManager.Business.Interfaces;

namespace UserDeviceManager.Business.Services;

public class PhoneService : IDeviceAction, IPhoneService
{
    public string PerformeAction()
    {
        return "Making Call...";
    }
}
