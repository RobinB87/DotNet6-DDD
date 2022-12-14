using DDD.In.Practice.UI.Common;
using Logic.SharedKernel;
using Logic.SnackMachines;
using System.Collections.Generic;
using System.Linq;

namespace UI.SnackMachines;
public class SnackMachineViewModel : ViewModel
{
    private readonly SnackMachine _snackMachine;
    private readonly SnackMachineRepository _snackMachineRepository;

    public override string Caption => "Snack Machine";
    public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();
    public Money MoneyInside => _snackMachine.MoneyInside;

    public IReadOnlyList<SnackPileViewModel> Piles =>
        _snackMachine.GetAllSnackPiles()
        .Select(x => new SnackPileViewModel(x))
        .ToList();

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

    public Command InsertCentCommand { get; private set; }
    public Command InsertTenCentCommand { get; private set; }
    public Command InsertQuarterCommand { get; private set; }
    public Command InsertDollarCommand { get; private set; }
    public Command InsertFiveDollarCommand { get; private set; }
    public Command InsertTwentyDollarCommand { get; private set; }
    public Command ReturnMoneyCommand { get; private set; }
    public Command<string> BuySnackCommand { get; private set; }

    public SnackMachineViewModel(SnackMachine snackMachine)
    {
        _snackMachine = snackMachine;
        _snackMachineRepository = new SnackMachineRepository();

        InsertCentCommand = new Command(() => InsertMoney(Money.Cent));
        InsertTenCentCommand = new Command(() => InsertMoney(Money.TenCent));
        InsertQuarterCommand = new Command(() => InsertMoney(Money.Quarter));
        InsertDollarCommand = new Command(() => InsertMoney(Money.Dollar));
        InsertFiveDollarCommand = new Command(() => InsertMoney(Money.FiveDollar));
        InsertTwentyDollarCommand = new Command(() => InsertMoney(Money.TwentyDollar));
        ReturnMoneyCommand = new Command(() => ReturnMoney());
        BuySnackCommand = new Command<string>(BuySnack);
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

    private void BuySnack(string position)
    {
        var positionInt = int.Parse(position);
        var error = _snackMachine.CanBuySnack(positionInt);
        if (error != string.Empty)
        {
            NotifyClient(error);
            return;
        }

        _snackMachine.BuySnack(positionInt);
        _snackMachineRepository.Save(_snackMachine);
        NotifyClient("You have bought a snack");
    }

    private void NotifyClient(string message)
    {
        Message = message;
        Notify(nameof(MoneyInTransaction));
        Notify(nameof(MoneyInside));
        Notify(nameof(Piles));
    }
}