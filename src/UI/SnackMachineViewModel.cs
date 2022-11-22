using DDD.In.Practice.UI.Common;
using Logic;

namespace UI;
public class SnackMachineViewModel : ViewModel
{
	private readonly SnackMachine _snackMachine;
    public override string Caption => "Snack Machine";
	public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();
	public Command InsertCentCommand { get; private set; }
	public Command InsertTenCentCommand { get; private set; }
	public Command InsertQuarterCommand { get; private set; }
	public Command InsertDollarCommand { get; private set; }
	public Command InsertFiveDollarCommand { get; private set; }
	public Command InsertTwentyDollarCommand { get; private set; }

    public SnackMachineViewModel(SnackMachine snackMachine)
	{
		_snackMachine = snackMachine;
        InsertCentCommand = new Command(() => InsertCent(Money.Cent));
        InsertTenCentCommand = new Command(() => InsertCent(Money.TenCent));
        InsertQuarterCommand = new Command(() => InsertCent(Money.Quarter));
        InsertDollarCommand = new Command(() => InsertCent(Money.Dollar));
        InsertFiveDollarCommand = new Command(() => InsertCent(Money.FiveDollar));
        InsertTwentyDollarCommand = new Command(() => InsertCent(Money.TwentyDollar));
	}

	private void InsertCent(Money money)
	{
		_snackMachine.InsertMoney(money);
		Notify("MoneyInTransaction");
	}
}