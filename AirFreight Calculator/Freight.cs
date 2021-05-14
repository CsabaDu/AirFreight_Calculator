using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirFreight_Calculator
{
    public class Amount : Shipment, IComparable<Amount>
    {
        internal Rate Rate { get; set; }
        public static class Exchange
        {
            public enum Currency { HUF, EUR, USD }

            public const decimal huf = 1;
            public static decimal eur = 360;
            public static decimal usd = 300;

            public static decimal GetRate(Currency curr)
            {
                switch (curr)
                {
                    case Currency.HUF:
                        return 1;
                    case Currency.EUR:
                        return eur;
                    case Currency.USD:
                        return usd;
                    default:
                        return 1;
                }
            }

            internal static void SetRate(decimal rate,
                                         Currency curr)
            {
                switch (curr)
                {
                    case Currency.HUF:
                        return;
                    case Currency.EUR:
                        eur = rate;
                        break;
                    case Currency.USD:
                        usd = rate;
                        break;
                    default:
                        return;
                }
            }

            public static Currency GetCurrency(Amount amt)
            {
                return amt.Curr;
            }

            internal static void SetCurrency(ref Amount amt,
                                             Currency curr)
            {
                decimal rate;
                switch (GetCurrency(amt))
                {
                    case Currency.HUF:
                        rate = huf;
                        break;
                    case Currency.EUR:
                        rate = eur;
                        break;
                    case Currency.USD:
                        rate = usd;
                        break;
                    default:
                        return;
                }
                amt.Val = amt.Val * rate / GetRate(curr);
                amt.Curr = curr;
            }
        }

        public decimal Val { get; set; }
        public Exchange.Currency Curr { get; set; }

        public static Amount operator +(Amount a, Amount b)
        {
            if (!(a == null || b == null))
                if (a.Curr.Equals(b.Curr))
                    return new Amount(a.Val + b.Val, a.Curr);
                else
                {
                    decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                    decimal bVal = b.Val * Exchange.GetRate(b.Curr);
                    return new Amount((aVal + bVal) / Exchange.GetRate(a.Curr), a.Curr);
                }
            else return new Amount(a.Curr);
        }
        public static Amount operator +(Amount a, decimal b)
        {
            if (!(a == null))
            {
                decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                return new Amount((aVal + b) / Exchange.GetRate(a.Curr), a.Curr);
            }
            else return new Amount(a.Curr);
        }
        public static Amount operator +(Amount a, int b)
        {
            if (!(a == null))
            {
                decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                return new Amount((aVal + b) / Exchange.GetRate(a.Curr), a.Curr);
            }
            else return new Amount(a.Curr);
        }

        public static Amount operator -(Amount a, Amount b)
        {
            if (!(a == null || b == null))
                if (a.Curr.Equals(b.Curr))
                    return new Amount(a.Val - b.Val, a.Curr);
                else
                {
                    decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                    decimal bVal = b.Val * Exchange.GetRate(b.Curr);
                    return new Amount((aVal - bVal) / Exchange.GetRate(a.Curr), a.Curr);
                }
            else return new Amount(a.Curr);
        }
        public static Amount operator -(Amount a, decimal b)
        {
            if (!(a == null))
            {
                decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                return new Amount((aVal - b) / Exchange.GetRate(a.Curr), a.Curr);
            }
            else return new Amount(a.Curr);
        }
        public static Amount operator -(Amount a, int b)
        {
            if (!(a == null))
            {
                decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                return new Amount((aVal - b) / Exchange.GetRate(a.Curr), a.Curr);
            }
            else return new Amount(a.Curr);
        }

        public static Amount operator *(Amount a, int b)
        {
            if (!(a == null))
                return new Amount(a.Val * b, a.Curr);
            else
                return new Amount(a.Curr);
        }
        public static Amount operator *(Amount a, decimal b)
        {
            if (!(a == null))
                return new Amount(a.Val * b, a.Curr);
            else
                return new Amount(a.Curr);
        }
        public static Amount operator *(Amount a, double b)
        {
            decimal bDec = Convert.ToDecimal(b);
            if (!(a == null))
                return new Amount(a.Val * bDec, a.Curr);
            else
                return new Amount(a.Curr);
        }

        public static decimal operator /(Amount a, Amount b)
        {
            if (!(a == null || b == null))
            {
                if (b.Val != 0)
                {
                    if (a.Curr.Equals(b.Curr))
                        return a.Val / b.Val;
                    else
                    {
                        decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                        decimal bVal = b.Val * Exchange.GetRate(b.Curr);
                        return aVal / (bVal * Exchange.GetRate(a.Curr));
                    }
                }
                else return 0;
            }
            else return 0;
        }
        public static Amount operator /(Amount a, int b)
        {
            if (!(a == null))
            {
                decimal aVal = a.Val * Exchange.GetRate(a.Curr); ;
                return new Amount(aVal / (b * Exchange.GetRate(a.Curr)), a.Curr);
            }
            else return new Amount(a.Curr);
        }
        public static Amount operator /(Amount a, decimal b)
        {
            if (!(a == null))
            {
                decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                return new Amount(aVal / (b * Exchange.GetRate(a.Curr)), a.Curr);
            }
            else return new Amount(a.Curr);
        }
        public static Amount operator /(Amount a, double b)
        {
            decimal bDec = Convert.ToDecimal(b);
            return a / bDec;
        }

        public static bool operator ==(Amount a, Amount b)
        {
            if (!(a is null || b is null))
                if (a.Curr.Equals(b.Curr))
                    if (a.Val == b.Val)
                        return true;
                    else
                        return false;
                else
                {
                    decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                    decimal bVal = b.Val * Exchange.GetRate(b.Curr);
                    if (aVal == bVal)
                        return true;
                    else
                        return false;
                }
            else
                return default;
        }
        public static bool operator !=(Amount a, Amount b)
        {
            if (!(a is null || b is null))
                if (a.Curr.Equals(b.Curr))
                    if (a.Val != b.Val)
                        return true;
                    else
                        return false;
                else
                {
                    decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                    decimal bVal = b.Val * Exchange.GetRate(b.Curr);
                    if (aVal != bVal)
                        return true;
                    else
                        return false;
                }
            else
                return default;
        }
        public static bool operator >(Amount a, Amount b)
        {
            if (!(a is null || b is null))
                if (a.Curr.Equals(b.Curr))
                    if (a.Val > b.Val)
                        return true;
                    else
                        return false;
                else
                {
                    decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                    decimal bVal = b.Val * Exchange.GetRate(b.Curr);
                    if (aVal > bVal)
                        return true;
                    else
                        return false;
                }
            else
                return default;
        }
        public static bool operator <(Amount a, Amount b)
        {
            if (!(a is null || b is null))
                if (a.Curr.Equals(b.Curr))
                    if (a.Val < b.Val)
                        return true;
                    else
                        return false;
                else
                {
                    decimal aVal, bVal, xchgr;
                    xchgr = Exchange.GetRate(a.Curr);
                    aVal = a.Val * xchgr;
                    bVal = b.Val * Exchange.GetRate(b.Curr);
                    if (aVal < bVal / xchgr)
                        return true;
                    else
                        return false;
                }
            else
                return default;
        }
        public static bool operator >=(Amount a, Amount b)
        {
            if (!(a is null || b is null))
                if (a.Curr.Equals(b.Curr))
                    if (a.Val >= b.Val)
                        return true;
                    else
                        return false;
                else
                {
                    decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                    decimal bVal = b.Val * Exchange.GetRate(b.Curr);
                    if (aVal >= bVal)
                        return true;
                    else
                        return false;
                }
            else
                return default;
        }
        public static bool operator <=(Amount a, Amount b)
        {
            if (!(a is null || b is null))
                if (a.Curr.Equals(b.Curr))
                    if (a.Val <= b.Val)
                        return true;
                    else
                        return false;
                else
                {
                    decimal aVal = a.Val * Exchange.GetRate(a.Curr);
                    decimal bVal = b.Val * Exchange.GetRate(b.Curr);
                    if (aVal <= bVal)
                        return true;
                    else
                        return false;
                }
            else
                return default;
        }

        public override bool Equals(object obj)
        {
            return obj is Amount &&
                this.Val * Exchange.GetRate(this.Curr) ==
                    (obj as Amount).Val * Exchange.GetRate((obj as Amount).Curr);
        }
        public override int GetHashCode()
        {
            int hashCode = -1981823167;
            hashCode = hashCode * -1521134295 + this.Val.GetHashCode();
            hashCode = hashCode * -1521134295 + this.Curr.GetHashCode();
            return hashCode;
        }
        public int CompareTo(Amount other)
        {
            if (!Equals(other))
                if (this > other)
                    return 1;
                else
                    return -1;
            else
                return 0;
        }

        public static decimal GetValue(Amount amt)
        {
            return amt.Val;
        }
        public static decimal GetValue(Amount amt,
                                       Exchange.Currency curr)
        {
            return amt.Val * Exchange.GetRate(curr) /
                Exchange.GetRate(amt.Curr);
        }
        protected Exchange.Currency GetCurr(Amount amt)
        {
            return Exchange.GetCurrency(amt);
        }

        public Amount() { }
        public Amount(decimal val)
        {
            this.Val = val;
            this.Curr = Exchange.Currency.HUF;
        }
        public Amount(Exchange.Currency curr)
        {
            this.Val = 0;
            this.Curr = curr;
        }
        public Amount(decimal val,
                      Exchange.Currency curr)
        {
            this.Val = val;
            this.Curr = curr;
        }
        public Amount(Amount other)
        {
            this.Val = other.Val;
            this.Curr = other.Curr;
        }
    }

    public class Rate : Amount
    {
        public enum Measurement { AWB, GWT, CHW, PCS, DGP, DGD, UNC }
        public enum RateType { L, R, B, F, M, Q }
        internal Amount Net { get; set; }
        internal int Unit { get; set; }
        public Measurement RateMmt { get; internal set; }
        public RateType RT { get; internal set; }
        public int? Limit { get; set; }
        public Measurement LimitMmt { get; internal set; }


        public Rate() { }
        public Rate(Amount net,
                    int unit,
                    Measurement rateMmt,
                    RateType rt,
                    int? limit,
                    Measurement limitMmt)
        {
            this.Net = net;
            this.Unit = unit;
            this.RateMmt = rateMmt;
            this.RT = rt;
            this.Limit = limit;
            this.LimitMmt = limitMmt;
        }
        public Rate(Rate other)
        {
            this.Net = other.Net;
            this.Unit = other.Unit;
            this.RateMmt = other.RateMmt;
            this.RT = other.RT;
            this.Limit = other.Limit;
            this.LimitMmt = other.LimitMmt;
        }

        public class Surcharge : Rate
        {
            public string zoneCode;
            public string schgCode;

            public Surcharge() : base() { }

            public Surcharge(string zoneCode,
                             string schgCode,
                             Rate rate) : base(rate)
            {
                this.zoneCode = zoneCode;
                this.schgCode = schgCode;
            }
            public Surcharge(string zoneCode,
                             string schgCode,
                             Amount net,
                             int unit,
                             Measurement rateMmt,
                             RateType rt)
            {
                this.zoneCode = zoneCode;
                this.schgCode = schgCode;
                this.Net = net;
                this.Unit = unit;
                this.RateMmt = rateMmt;
                this.RT = rt;
                this.Limit = 1;
                this.LimitMmt = Measurement.AWB;
            }
            public Surcharge(Surcharge other)
            {
                this.zoneCode = other.zoneCode;
                this.schgCode = other.schgCode;
                this.Net = other.Net;
                this.Unit = other.Unit;
                this.RateMmt = other.RateMmt;
                this.RT = other.RT;
                this.Limit = 1;
                this.LimitMmt = Measurement.AWB;
            }
        }
    }

    public class Charge : Rate
    {
        public double quantity;
        public Amount amount;

        public struct RateCharge
        {
            public Amount amt;
            public RateType rt;
            public RateCharge(Amount amt, RateType rt)
            {
                this.amt = amt;
                this.rt = rt;
            }
        }
        public Charge() { }
        public Charge(AirCargo airCargo,
                      List<Rate> rateList)
        {
            this.amount = new Amount(GetChargeAmount(airCargo, rateList));
        }
        public Charge(List<Rate> rateList)
        {
            this.amount = GetChargeAmount(this.Cargo as AirCargo, rateList);
        }
        public Charge(Charge other)
        {
            this.amount = other.amount;
        }

        public static double GetQuantity(AirCargo airCargo,
                                         Rate rate)
        {
            return GetQuantity(airCargo, rate.RateMmt);
        }
        public static double GetQuantity(AirCargo airCargo,
                                         Measurement mmt)
        {
            switch (mmt)
            {
                case Measurement.AWB:
                    return 1;
                case Measurement.GWT:
                    return airCargo.GWT;
                case Measurement.CHW:
                    return airCargo.CHW;
                case Measurement.PCS:
                    return airCargo.AcPcCount;
                case Measurement.DGD:
                    return airCargo.dgr.DgdCount + 1;
                case Measurement.UNC:
                    if (airCargo.dgr.UnCount > 0)
                        return airCargo.dgr.UnCount - 1;
                    else return 0;
                case Measurement.DGP:
                    return airCargo.dgr.DgrPcCount;
                default:  return 0;
            }
        }
        public static double GetLimit(AirCargo airCargo,
                                      Rate rate)
        {
            return GetQuantity(airCargo, rate.LimitMmt);
        }
        public static Amount GetChargeAmount(AirCargo airCargo,
                                             List<Rate> rateList)
        {
            try
            {

                List<RateCharge> rateCharges = new List<RateCharge>();
                List<Amount> charges_R = new List<Amount>();
                List<Amount> charges_Q = new List<Amount>();
                if(rateList.Count != 0)
                {
                    foreach (Rate item in rateList)
                    {
                        double quantity = GetQuantity(airCargo, item);
                        double limitQuantity = GetLimit(airCargo, item);
                        Amount rateAmount = item.Net;
                        Amount calcAmount = new Amount();
                        switch (item.RT)
                        {
                            case RateType.L:
                                calcAmount = rateAmount;
                                break;
                            case RateType.R:
                                if (item.Limit != null)
                                    if (limitQuantity <= item.Limit)
                                        charges_R.Add(rateAmount);
                                break;
                            case RateType.B:
                                if (limitQuantity > item.Limit)
                                    calcAmount = rateAmount;
                                break;
                            case RateType.F:
                                if (item.Limit == null)
                                    item.Limit = 0;
                                if (limitQuantity >= item.Limit)
                                    calcAmount = rateAmount * Math.Ceiling((quantity - limitQuantity)
                                        / item.Unit);
                                break;
                            case RateType.M:
                                calcAmount = rateAmount;
                                break;
                            case RateType.Q:
                                if (item.Limit != null)
                                    if (item.Val > 0)
                                    {
                                        if (limitQuantity < item.Limit)
                                            charges_Q.Add(rateAmount * ((int)(item.Limit)
                                                / item.Unit));
                                        else
                                            charges_Q.Add(rateAmount * (quantity / item.Unit));
                                    }
                                break;
                            default:
                                return default;
                        }
                        if (calcAmount.Val != 0)
                            rateCharges.Add(new RateCharge(calcAmount, item.RT));
                    }
                    if (charges_Q.Count != 0)
                        rateCharges.Add(new RateCharge(charges_Q.Min(), RateType.Q));
                    if (charges_R.Count != 0)
                        rateCharges.Add(new RateCharge(charges_R.Min(), RateType.R));
                }
                Amount minCharge = new Amount();
                Amount flatCharge = new Amount();
                Amount outcome = new Amount();
                foreach (RateCharge item in rateCharges)
                {
                    switch (item.rt)
                    {
                        case RateType.L:
                            outcome += item.amt;
                            break;
                        case RateType.R:
                            outcome += item.amt;
                            break;
                        case RateType.B:
                            outcome += item.amt;
                            break;
                        case RateType.F:
                            if (item.amt.Val > 0)
                                flatCharge = item.amt;
                            break;
                        case RateType.M:
                            if (item.amt.Val > 0)
                                minCharge = item.amt;
                            else
                                minCharge = new Amount(item.amt.Curr);
                            break;
                        case RateType.Q:
                            if (item.amt.Val > 0)
                                flatCharge = item.amt;
                            break;
                        default:
                            return default;
                    }
                }
                if (minCharge > flatCharge)
                    outcome += minCharge;
                else if (flatCharge.Val > 0)
                    outcome += flatCharge;
                return outcome;
            }
            catch (NullReferenceException)
            {
                return new Amount();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return default;
            }
        }
    }

    public class AirFreight : Charge
    {
        public static Amount AirCarriage { get; set; }
        public static Amount AirSchgs { get; set; }
        public static Amount GroundHandling { get; set; }
        public static Amount Profit { get; set; }
        public bool IsNet { get; set; }

        public AirFreight(Amount airCarriage,
                          Amount airSchgs,
                          Amount groundHandling,
                          Amount profit)
        {
            AirCarriage = airCarriage;
            AirSchgs = airSchgs;
            GroundHandling = groundHandling;
            Profit = profit;
        }
        public AirFreight(Amount airCarriage,
                          Amount airSchgs,
                          Amount groundHandling)
        {
            AirCarriage = airCarriage;
            AirSchgs = airSchgs;
            GroundHandling = groundHandling;
            Profit = new Amount(Exchange.Currency.EUR);
        }

        public AirFreight(Amount profit)
        {
            AirCarriage = new Charge();
            AirSchgs = new Charge();
            GroundHandling = new Charge();
            Profit = profit;
        }
        static AirFreight() { }

        public static Amount GetAirFreight()
        {
            return GetAirFreight(AirCarriage, AirSchgs, GroundHandling, Profit);
        }
        public static Amount GetAirFreight(Amount airCarriage,
                                           Amount airSchgs,
                                           Amount groundHandling)
        {
            return airCarriage + airSchgs + groundHandling;
        }
        public static Amount GetAirFreight(Amount profit)
        {
            return GetAirFreight(AirCarriage, AirSchgs, GroundHandling) + profit;
        }

        public static Amount GetAirFreight(Amount airCarriage,
                                           Amount airSchgs,
                                           Amount groundHandling,
                                           Amount profit)
        {
            return GetAirFreight(airCarriage, airSchgs, groundHandling) + profit;
        }

        protected override object Freight
        {
            get { return GetFreight(); }
        }
        protected override object GetFreight()
        {
            return new AirFreight(AirCarriage, AirSchgs, GroundHandling, Profit);
        }
    }
}

