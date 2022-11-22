﻿using DDD.In.Practice.UI.Common;
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
        InsertCentCommand = new Command(() => InsertMoney(Money.Cent));
        InsertTenCentCommand = new Command(() => InsertMoney(Money.TenCent));
        InsertQuarterCommand = new Command(() => InsertMoney(Money.Quarter));
        InsertDollarCommand = new Command(() => InsertMoney(Money.Dollar));
        InsertFiveDollarCommand = new Command(() => InsertMoney(Money.FiveDollar));
        InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
		ReturnMoneyCommand = new Command(() => ReturnMoney());
		BuySnackCommand = new Command(() => BuySnack());
    }

	private void InsertMoney(Money coinOrNote)
	{
		_snackMachine.InsertMoney(coinOrNote);
        NotifyClient($"You have inserted: {coinOrNote}");
	}

	private void ReturnMoney()
	{
		_snackMachine.ReturnMoney();
        NotifyClient("Money was returned");
    }

    private void BuySnack()
	{
		_snackMachine.BuySnack();
		NotifyClient("You have bought a snack");
    }

	private void NotifyClient(string message)
	{
        Message = message;
        Notify(nameof(MoneyInTransaction));
        Notify(nameof(MoneyInside));
    }
}