using System;
using System.Collections;

namespace ChainOfResponsibilityWithoutPrint
{
    public enum CurrencyType
    {
        Eur,
        Dollar,
        Ruble
    }

    public interface IBanknote
    {
        CurrencyType Currency { get; }
        int Value { get; }
    }

    public class Banknote : IBanknote
    {
        public CurrencyType Currency { get; }
        public int Value { get; }

        public Banknote()
        { }

        public Banknote(CurrencyType currency, int value)
        {
            Currency = currency;
            Value = value;
        }

        protected bool Equals(Banknote other)
        {
            return Currency == other.Currency && Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Banknote)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)Currency * 397) ^ Value;
            }
        }
    }

    public class Bancomat
    {
        private readonly BanknoteHandler _handler;

        public Bancomat()
        {
            _handler = new TenRubleHandler(null);

            _handler = new TenDollarHandler(_handler);
            _handler = new FiftyDollarHandler(_handler);
            _handler = new HundredDollarHandler(_handler);
        }

        public bool Validate(IBanknote banknote)
        {
            return _handler.Validate(banknote);
        }
    }

    public abstract class BanknoteHandler
    {
        private readonly BanknoteHandler _nextHandler;
        protected abstract IBanknote Banknote { get; }

        protected BanknoteHandler(BanknoteHandler nextHandler)
        {
            _nextHandler = nextHandler;
        }

        public bool Validate(IBanknote banknote)
        {
            if (banknote.Value <= 0)
            {
                return true;
            }
            if (banknote.Currency != Banknote.Currency)
            {
                return NextHandlerValidate(banknote);
            }
            if (banknote.Value / Banknote.Value == 0)
            {
                return NextHandlerValidate(banknote);
            }
            var updateBanknote = UpdateBanknote(banknote);
            return NextHandlerValidate(updateBanknote);
        }

        private IBanknote UpdateBanknote(IBanknote banknote)
        {
            var amountBanknotes = banknote.Value / Banknote.Value;
            var costAmountBanknotes = amountBanknotes * Banknote.Value;
            var newValue = banknote.Value - costAmountBanknotes;
            return new Banknote(banknote.Currency, newValue);
        }

        public virtual bool NextHandlerValidate(IBanknote banknote)
        {
            return _nextHandler != null && _nextHandler.Validate(banknote);
        }
    }

    public class TenRubleHandler : BanknoteHandler
    {
        protected override IBanknote Banknote => new Banknote(CurrencyType.Ruble, 10);

        public TenRubleHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class HundredDollarHandler : BanknoteHandler
    {
        protected override IBanknote Banknote => new Banknote(CurrencyType.Dollar, 100);

        public HundredDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class FiftyDollarHandler : BanknoteHandler
    {
        protected override IBanknote Banknote => new Banknote(CurrencyType.Dollar, 50);

        public FiftyDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }

    public class TenDollarHandler : BanknoteHandler
    {
        protected override IBanknote Banknote => new Banknote(CurrencyType.Dollar, 10);

        public TenDollarHandler(BanknoteHandler nextHandler) : base(nextHandler)
        { }
    }
}
