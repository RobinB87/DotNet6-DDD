using DDD.In.Practice.UI.Common;
using Logic;

namespace UI;
public class SnackMachineViewModel : ViewModel
{
	private readonly SnackMachine _snackMachine;
    public override string Caption => "Snack Machine";

	private string _message = string.Empty;
	public string Message
	{
		get { return _message; }
		private set 
		{ 
			_message = value;
			Notify();
		}
	}

	public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();
	public Money MoneyInside => _snackMachine.MoneyInside + _snackMachine.MoneyInTransaction;

	public Command InsertCentCommand { get; private set; }
	public Command InsertTenCentCommand { get; private set; }
	public Command InsertQuarterCommand { get; private set; }
	public Command InsertDollarCommand { get; private set; }
	public Command InsertFiveDollarCommand { get; private set; }
	public Command InsertTwentyDollarCommand { get; private set; }
	public Command ReturnMoneyCommand { get; private set; }
	public Command BuySnackCommand { get; private set; }

    public SnackMachineViewModel(SnackMachine snackMachine)
	{
		_snackMachine = snackMachine;
        InsertCentCommand = new Command(() => InsertCent(Money.Cent));
        InsertTenCentCommand = new Command(() => InsertCent(Money.TenCent));
        InsertQuarterCommand = new Command(() => InsertCent(Money.Quarter));
        InsertDollarCommand = new Command(() => InsertCent(Money.Dollar));
        InsertFiveDollarCommand = new Command(() => InsertCent(Money.FiveDollar));
        InsertTwentyDollarCommand = new Command(() => InsertCent(Money.TwentyDollar));
		ReturnMoneyCommand = new Command(() => ReturnMoney());
		BuySnackCommand = new Command(() => BuySnack());
    }

	private void InsertCent(Money money)
	{
		_snackMachine.InsertMoney(money);
		Notify("MoneyInTransaction");
		Notify("MoneyInside");
        Message = $"You have inserted: {money}"; 
	}

	private void ReturnMoney()
	{
		_snackMachine.ReturnMoney();
        Notify("MoneyInTransaction");
        Notify("MoneyInside");
    }

	private void BuySnack()
	{
		_snackMachine.BuySnack();
        Notify("MoneyInTransaction");
        Notify("MoneyInside");
		Message = "You have bought a snack";
    }
}