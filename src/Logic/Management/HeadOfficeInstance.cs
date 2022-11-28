namespace Logic.Management;
/// <summary>
/// Implement head office instance by singleton pattern
/// This class resides in the repositories layer of the onion diagram
/// </summary>
public static class HeadOfficeInstance
{
	private const long HeadOfficeId = 1;
    public static HeadOffice Instance { get; private set; }

	public static void Init()
	{
		var repository = new HeadOfficeRepository();
		Instance = repository.GetById(HeadOfficeId);
	}
}