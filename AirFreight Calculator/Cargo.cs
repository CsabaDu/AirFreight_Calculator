using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AirFreight_Calculator
{
    public abstract class Piece : Shipment
    {
        public const double m3 = 1000000;
        public int PcLength { get; set; }
        public int PcWidth { get; set; }
        public int PcHeight { get; set; }
        public double PcWeight { get; set; }

        public Piece() { }
        protected Piece(int length, int width, int height, double weight)
        {
            this.PcLength = length;
            this.PcWidth = width;
            this.PcHeight = height;
            this.PcWeight = weight;
        }
        public Piece(Piece other)
        {
            this.PcLength = other.PcLength;
            this.PcWidth = other.PcWidth;
            this.PcHeight = other.PcHeight;
            this.PcWeight = other.PcWeight;
        }
    }

    public class CargoItem : Piece
    {
        public enum AirCraftType { NB, LD, MD }
        public enum CrossSectType { basic, narrow, wide }
        public struct CrossSect
        {
            public int edge1;
            public int edge2;
            internal CrossSect(int edge1, int edge2)
            {
                this.edge1 = edge1;
                this.edge2 = edge2;
            }
        }

        public int PcCount { get; set; }
        public bool IsCiDGR { get; set; }
        public bool IsFit { get; private set; }

        public static readonly CrossSect Limits_MD = new CrossSect(300, 335);
        public static readonly CrossSect Limits_LD = new CrossSect(260, 165);
        public static readonly CrossSect Limits_NB = new CrossSect(120, 75);

        public const int maxLength_MD = 600;
        public const int maxLength_LD = 300;

        public AirCraftType CiAct;
        public bool isComplete;

        public int GetMaxLength(AirCraftType act)
        {
            switch (act)
            {
                case AirCraftType.NB:
                    return maxLength_LD;
                case AirCraftType.LD:
                    return maxLength_LD;
                case AirCraftType.MD:
                    return maxLength_MD;
                default:
                    return maxLength_LD;
            }
        }

        public double GetPcVolume(int length, int width, int height)
        {
            return length * width * height / m3;
        }
        public double GetPcVolume(Piece piece)
        {
            return GetPcVolume(piece.PcLength, piece.PcWidth, piece.PcHeight);
        }
        public double GetPcVolume()
        {
            return GetPcVolume(this);
        }

        public CrossSectType GetCrossSectType(int edge1, int edge2, out bool match)
        {
            CrossSectType cst;
            int shorter = Math.Min(this.PcLength, this.PcWidth);
            int longer = Math.Max(this.PcLength, this.PcWidth);
            bool matchWidth = Math.Min(edge1, edge2) == shorter;
            bool matchLength = Math.Max(edge1, edge2) == longer;
            bool matchShorter = edge1 == shorter;
            bool matchLonger = edge1 == longer;
            bool matchHeight = edge2 == this.PcHeight;
            if ((matchLength && matchWidth) ||
                ((matchShorter || matchLonger) && matchHeight))
                if (matchLength && matchWidth)
                {
                    cst = CrossSectType.basic;
                    match = true;
                }
                else if (matchShorter && matchHeight)
                {
                    cst = CrossSectType.narrow;
                    match = true;
                }
                else if (matchLonger && matchHeight)
                {
                    cst = CrossSectType.wide;
                    match = true;
                }
                else
                {
                    cst = default;
                    match = false;
                }
            else
            {
                cst = default;
                match = false;
            }
            return cst;
        }
        public CrossSectType GetCrossSectType(CrossSect crossSect, out bool match)
        {
            return (GetCrossSectType(crossSect.edge1, crossSect.edge2, out match));
        }

        public CrossSect GetCrossSect(CargoItem cargoItem, CrossSectType cst)
        {
            CrossSect crossSect = new CrossSect();
            int longer = Math.Max(cargoItem.PcLength, cargoItem.PcWidth);
            int shorter = Math.Min(cargoItem.PcLength, cargoItem.PcWidth);
            switch (cst)
            {
                case CrossSectType.basic:
                    crossSect.edge1 = longer;
                    crossSect.edge2 = shorter;
                    break;
                case CrossSectType.narrow:
                    crossSect.edge1 = shorter;
                    crossSect.edge2 = cargoItem.PcHeight;
                    break;
                case CrossSectType.wide:
                    crossSect.edge1 = longer;
                    crossSect.edge2 = cargoItem.PcHeight;
                    break;
                default:
                    crossSect.edge1 = longer;
                    crossSect.edge2 = shorter;
                    break;
            }
            return crossSect;

        }

        public CrossSect GetCrossSect(CrossSectType cst)
        {
            CrossSect crossSect = new CrossSect();
            int longer = Math.Max(this.PcLength, this.PcWidth);
            int shorter = Math.Min(this.PcLength, this.PcWidth);
            switch (cst)
            {
                case CrossSectType.basic:
                    crossSect.edge1 = longer;
                    crossSect.edge2 = shorter;
                    break;
                case CrossSectType.narrow:
                    crossSect.edge1 = shorter;
                    crossSect.edge2 = this.PcHeight;
                    break;
                case CrossSectType.wide:
                    crossSect.edge1 = longer;
                    crossSect.edge2 = this.PcHeight;
                    break;
                default:
                    crossSect.edge1 = longer;
                    crossSect.edge2 = shorter;
                    break;
            }
            return crossSect;
        }

        public int GetCsEdge(CrossSect crossSect, bool isFirst)
        {
            if (isFirst)
                return crossSect.edge1;
            else
                return crossSect.edge2;
        }

        public int GetMaxLimits(bool isFirst)
        {
            CrossSect crossSect = Limits_MD;
            return GetCsEdge(crossSect, isFirst);
        }

        public bool IsCsBigger(CargoItem cargoItem, CrossSectType cst, CrossSect crossSect)
        {
            if (cargoItem.GetCrossSect(cst).edge1 > crossSect.edge1 ||
                cargoItem.GetCrossSect(cst).edge2 > crossSect.edge2)
                return true;
            else
                return false;

        }
        public bool IsCsBigger(CrossSectType cst, CrossSect crossSect)
        {
            return IsCsBigger(this, cst, crossSect);
        }

        public AirCraftType GetCiAct(CargoItem cargoItem)
        {
            bool isFit;
            CrossSectType cst = CrossSectType.narrow;
            if (!cargoItem.IsCsBigger(cst, Limits_MD))
            {
                if (!(cargoItem.GetCrossSect(cst).edge1 == 0 ||
                        cargoItem.GetCrossSect(cst).edge2 == 0))
                {
                    if (!(cargoItem.PcLength > maxLength_LD ||
                        cargoItem.PcWidth > maxLength_LD))
                    {
                        if (!cargoItem.IsCsBigger(cst, Limits_NB))
                            cargoItem.CiAct = AirCraftType.NB;
                        if (cargoItem.IsCsBigger(cst, Limits_NB) &&
                            !cargoItem.IsCsBigger(cst, Limits_LD))
                            cargoItem.CiAct = AirCraftType.LD;
                        if (cargoItem.IsCsBigger(cst, Limits_LD))
                            cargoItem.CiAct = AirCraftType.MD;
                        isFit = true;
                    }
                    else if (!(cargoItem.PcLength > maxLength_MD ||
                             cargoItem.PcWidth > maxLength_MD))
                    {
                        cargoItem.CiAct = AirCraftType.MD;
                        isFit = true;
                    }
                    else
                    {
                        cargoItem.CiAct = default;
                        isFit = false;
                    }
                }
                else
                {
                    cargoItem.CiAct = default;
                    isFit = false;
                }
            }
            else
            {
                cargoItem.CiAct = default;
                isFit = false;
            }
            cargoItem.IsFit = isFit;
            return cargoItem.CiAct;
        }

        public AirCraftType GetCiAct()
        {
            return GetCiAct(this);
        }

        public void ResetAct()
        {
            this.CiAct = default;
            this.IsFit = false;
        }

        public CargoItem() : base() { }
        public CargoItem(Piece piece,
                         int pcCount,
                         bool isCiDgr) : base(piece)
        {
            this.PcCount = pcCount;
            this.IsCiDGR = isCiDgr;
            this.CiAct = GetCiAct();
            if (this.PcLength + this.PcWidth + this.PcHeight + this.PcWeight != 0 && this.IsFit)
                this.isComplete = true;
        }
        public CargoItem(CargoItem other)
        {
            this.PcLength = other.PcLength;
            this.PcWidth = other.PcWidth;
            this.PcHeight = other.PcHeight;
            this.PcWeight = other.PcWeight;
            this.PcCount = other.PcCount;
            this.IsCiDGR = other.IsCiDGR;
            this.CiAct = other.CiAct;
            this.isComplete = other.isComplete;
        }
        ~CargoItem() { }
    }

    public class AirCargo : CargoItem
    {
        public const double Ratio_CHW = 166.66;

        public enum HandlingType { GC, SH, DG }
        public class DGR : AirCargo
        {
            internal int DgrPcCount { get; set; }
            internal int DgdCount { get; set; }
            internal int UnCount { get; set; }
            internal bool IsCAO { get; set; }

            public int GetDgrPcCount(AirCargo airCargo,
                                     int dgrPcCount)
            {
                DGR dgr = new DGR();
                if (airCargo.IsDGR)
                    if (airCargo.packingList.Count == 0)
                        if (dgrPcCount <= airCargo.AcPcCount)
                            dgr.DgrPcCount = dgrPcCount;
                        else
                            dgr.DgrPcCount = airCargo.AcPcCount;
                    else
                        dgr.DgrPcCount = GetDgrPcCount(airCargo);
                else
                    dgr.DgrPcCount = 0;
                return dgr.DgrPcCount;
            }
            public int GetDgrPcCount(int dgrPcCount)
            {
                return GetDgrPcCount(this, dgrPcCount);
            }
            public int GetDgrPcCount(AirCargo airCargo)
            {
                int count = new int();
                if (airCargo.packingList.Count != 0)
                {
                    foreach (CargoItem item in airCargo.packingList)
                    {
                        if (item.IsCiDGR || airCargo.IsDGR)
                        {
                            count += item.PcCount;
                            if (count == 0)
                                count = airCargo.GetAcPcCount();
                        }
                        else
                            count = 0;
                    }
                }
                else if (airCargo.IsDGR)
                    count = airCargo.AcPcCount;
                else
                    count = 0;
                return count;
            }
            private int GetDgrPcCount()
            {
                return GetDgrPcCount(this);
            }

            public void SetDgrPcCount(AirCargo airCargo,
                                      int dgrPcCount)
            {
                airCargo.dgr.DgrPcCount = GetDgrPcCount(airCargo, dgrPcCount);
            }
            public void SetDgrPcCount(int dgrPcCount)
            {
                this.DgrPcCount = GetDgrPcCount(this, dgrPcCount);
            }
            public int GetDgdCount(AirCargo airCargo)
            {
                return airCargo.dgr.DgdCount;
            }

            public int GetDgdCount(int dgdCount)
            {
                if (this.IsDGR)
                    return dgdCount;
                else
                    return 0;
            }

            public void SetDgdCount(int dgdCount)
            {
                this.DgdCount = GetDgdCount(dgdCount);
            }
            public int GetUnCount(int unCount)
            {
                if (this.IsDGR)
                    return unCount;
                else
                    return 0;
            }

            public void SetUnCount(int unCount)
            {
                this.UnCount = GetUnCount(unCount);
            }
            public bool GetIsCAO(AirCargo airCargo,
                                 bool isCAO)
            {
                DGR dgr = new DGR();
                if (airCargo.IsDGR)
                    dgr.IsCAO = isCAO;
                else
                    dgr.IsCAO = false;
                return dgr.IsCAO;
            }
            public bool GetIsCAO(bool isCAO)
            {
                return GetIsCAO(this, isCAO);
            }

            public void SetIsCAO(bool isCAO)
            {
                this.IsCAO = GetIsCAO(isCAO);
            }

            public void SetDGR(AirCargo airCargo,
                               bool isDGR)
            {
                airCargo.IsDGR = isDGR;
                if (isDGR)
                {
                    airCargo.HT = HandlingType.DG;
                    if (GetDgrPcCount() != 0)
                        airCargo.dgr.DgrPcCount = GetDgrPcCount();
                    else
                        airCargo.dgr.DgrPcCount = GetAcPcCount();
                    if (airCargo.dgr.DgdCount == 0)
                        airCargo.dgr.dgr.DgdCount = 1;
                    if (airCargo.dgr.UnCount == 0)
                        airCargo.dgr.dgr.UnCount = 1;
                }
            }
            public void SetDGR(AirCargo airCargo,
                               int pcCount,
                               int dgdCount,
                               int unCount,
                               bool isCAO)
            {
                if (airCargo.IsDGR)
                {
                    airCargo.dgr.DgrPcCount = pcCount;
                    airCargo.dgr.DgdCount = dgdCount;
                    airCargo.dgr.UnCount = unCount;
                    airCargo.dgr.IsCAO = isCAO;
                }
            }
            public DGR GetDGR(AirCargo airCargo)
            {
                DGR dgr = new DGR();
                if (this.IsDGR)
                {
                    dgr.DgrPcCount = airCargo.dgr.DgrPcCount;
                    dgr.DgdCount = airCargo.dgr.DgdCount;
                    dgr.UnCount = airCargo.dgr.UnCount;
                    dgr.IsCAO = airCargo.dgr.IsCAO;
                }
                else
                    dgr = default;
                return dgr;
            }
            internal DGR GetDGR()
            {
                return GetDGR(this);
            }

            public DGR() { }
            public DGR(bool isDGR)
            {
                this.IsDGR = isDGR;
                this.DgrPcCount = this.AcPcCount;
                this.DgdCount = 1;
                this.UnCount = 1;
                this.IsCAO = false;
            }
            internal DGR(int dgdCount,
                         int unCount,
                         bool isCAO) : base()
            {
                if (this.IsDGR)
                {
                    this.DgrPcCount = GetDgrPcCount();
                    this.DgdCount = dgdCount;
                    this.UnCount = unCount;
                    this.IsCAO = isCAO;
                }
            }
            internal DGR(bool isDGR,
                         int dgdCount,
                         int unCount,
                         bool isCAO)
            {
                if (isDGR)
                {
                    this.IsDGR = isDGR;
                    this.DgrPcCount = GetDgrPcCount();
                    this.DgdCount = dgdCount;
                    this.UnCount = unCount;
                    this.IsCAO = isCAO;
                }
            }
        }

        public bool IsDGR { get; private set; }
        public int AcPcCount { get; set; }
        public double AcVolume { get; private set; }
        public double GWT { get; private set; }
        public double CHW { get; private set; }
        public AirCraftType ACT { get; private set; }
        public HandlingType HT { get; internal set; }

        public List<CargoItem> packingList;
        public DGR dgr;
        public int ciCount;

        public bool GetIsDGR()
        {
            bool isDGR = false;
            return GetIsDGR(this, isDGR);
        }
        public bool GetIsDGR(bool isDGR)
        {
            return GetIsDGR(this, isDGR);
        }
        public bool GetIsDGR(AirCargo airCargo,
                             bool isDGR)
        {
            bool ciDGR = new bool();
            if (!isDGR)
            {
                if (airCargo.packingList.Count != 0)
                    foreach (CargoItem item in airCargo.packingList)
                        if (item.IsCiDGR)
                        {
                            ciDGR = true;
                            break;
                        }
            }
            else
                ciDGR = isDGR;
            return ciDGR;
        }

        internal void SetIsDGR(bool isDGR)
        {
            this.IsDGR = GetIsDGR(isDGR);
        }
        public double GetAcVolume(AirCargo airCargo)
        {
            double volume = new double();
            foreach (CargoItem item in airCargo.packingList)
                volume += GetPcVolume(item) * item.PcCount;
            return volume;
        }
        public double GetAcVolume()
        {
            return GetAcVolume(this);
        }

        public void SetAcVolume(AirCargo airCargo,
                                double volume)
        {
            if (GetAcVolume(airCargo) == 0)
                airCargo.AcVolume = volume;
        }

        public void SetAcVolume(double volume)
        {
            SetAcVolume(this, volume);
        }


        public double GetAcWeight(AirCargo airCargo)
        {
            double weight = new double();
            foreach (CargoItem item in airCargo.packingList)
                weight += item.PcWeight * item.PcCount;
            return weight;
        }
        public double GetAcWeight()
        {
            return GetAcWeight(this);
        }

        private double CorrectAcWeight(double weight)
        {
            double rem = weight % 1;
            if (rem > 0)
            {
                if (rem <= 0.5)
                    weight = Math.Floor(weight) + 0.5;
                else
                    weight = Math.Ceiling(weight);
            }
            return weight;
        }

        public double GetAcGWT(AirCargo airCargo,
                               double weight)
        {
            double gwt = new double();
            if (airCargo.packingList.Count == 0)
                gwt = CorrectAcWeight(weight);
            else
                GetAcGWT(airCargo);
            return gwt;
        }
        public double GetAcGWT(double weight)
        {
            return GetAcGWT(this, weight);
        }
        private double GetAcGWT(AirCargo airCargo)
        {
            return CorrectAcWeight(GetAcWeight(airCargo));
        }
        public double GetAcGWT()
        {
            return GetAcGWT(this);
        }

        public void SetAcGWT(double weight)
        {
            this.GWT = CorrectAcWeight(weight);
        }
        public double GetAcCHW()
        {
            return GetAcCHW(this);
        }
        public double GetAcCHW(AirCargo airCargo)
        {
            return GetAcCHW(airCargo.GWT, airCargo.AcVolume);
        }
        public double GetAcCHW(double weight,
                               double volume)
        {
            double chw = CorrectAcWeight(volume * Ratio_CHW);
            if (CorrectAcWeight(weight) >= chw)
                chw = CorrectAcWeight(weight);
            return chw;
        }

        public void SetAcCHW(double weight,
                             out bool isBigger)
        {
            GetAcCHW();
            if (CorrectAcWeight(weight) >= this.CHW)
            {
                this.CHW = CorrectAcWeight(weight);
                isBigger = true;
            }
            else
            {
                this.CHW = GetAcCHW();
                isBigger = false;
            }
        }

        public void SetAcCHW()
        {
            this.CHW = GetAcCHW();
        }
        public int GetCiCount(AirCargo airCargo)
        {
            if (airCargo.packingList.Count != 0)
                return airCargo.packingList.Count;
            else
                return 1;
        }
        private int GetCiCount()
        {
            return GetCiCount(this);
        }

        public int GetAcPcCount(AirCargo airCargo)
        {
            int count = new int();
            foreach (CargoItem item in airCargo.packingList)
                count += item.PcCount;
            return count;
        }
        public int GetAcPcCount()
        {
            return GetAcPcCount(this);
        }

        public HandlingType GetHt()
        {
            return GetHt(this);
        }
        private HandlingType GetHt(HandlingType ht)
        {
            return GetHt(this, ht);
        }
        public HandlingType GetHt(AirCargo airCargo)
        {
            return GetHt(airCargo, airCargo.HT);
        }
        public HandlingType GetHt(AirCargo airCargo,
                                  HandlingType ht)
        {
            if (airCargo.IsDGR)
                return HandlingType.DG;
            else if (ht == HandlingType.DG)
                return HandlingType.GC;
            else
                return ht;
        }

        public void SetHt(HandlingType ht)
        {
            this.HT = GetHt(this, ht);
        }
        public void SetHt()
        {
            this.HT = GetHt();
        }

        public AirCraftType GetAct(AirCargo airCargo,
                                   AirCraftType act)
        {
            if (airCargo.packingList.Count == 0)
                airCargo.ACT = AirCraftType.LD;
            else
                foreach (CargoItem item in airCargo.packingList)
                    if (GetCiAct(item) > act)
                        act = item.CiAct;
            return act;
        }
        public AirCraftType GetAct(AirCraftType act)
        {
            return GetAct(this, act);
        }
        public AirCraftType GetAct()
        {
            return GetAct(this, AirCraftType.NB);
        }

        public void SetAct(AirCraftType act)
        {
            this.ACT = GetAct(act);
        }
        public void SetAct(AirCargo airCargo,
                           bool isCAO)
        {
            if (airCargo.IsDGR)
            {
                if (isCAO)
                    airCargo.ACT = AirCraftType.MD;
            }
            else
                airCargo.ACT = GetCiAct(airCargo);
        }
        public void SetAct(bool isCAO)
        {
            SetAct(this, isCAO);
        }

        public AirCargo() { }
        public AirCargo(List<CargoItem> packingList,
                        ref bool isDGR,
                        HandlingType ht,
                        DGR dgr)
        {
            this.packingList = packingList;
            this.IsDGR = GetIsDGR(isDGR);
            this.ACT = GetAct();
            this.HT = GetHt(ht);
            this.dgr = dgr.GetDGR();
            this.ciCount = GetCiCount();
            this.AcPcCount = GetAcPcCount();
            this.AcVolume = GetAcVolume();
            this.GWT = GetAcGWT();
            this.CHW = GetAcCHW();
        }
        public AirCargo(List<CargoItem> packingList)
        {
            this.packingList = packingList;
            this.ACT = GetAct();
            this.HT = GetHt();
            this.IsDGR = GetIsDGR();
            this.ciCount = GetCiCount();
            this.AcPcCount = GetAcPcCount();
            this.AcVolume = GetAcVolume();
            this.GWT = GetAcGWT();
            this.CHW = GetAcCHW();
        }
        public AirCargo(List<CargoItem> packingList,
                        AirCraftType act,
                        HandlingType ht)
        {
            this.packingList = packingList;
            this.ACT = GetAct(act);
            this.HT = GetHt(ht);
            this.IsDGR = GetIsDGR();
            this.dgr = dgr.GetDGR();
            this.ciCount = GetCiCount();
            this.AcPcCount = GetAcPcCount();
            this.AcVolume = GetAcVolume();
            this.GWT = GetAcGWT();
            this.CHW = GetAcCHW();

        }
        public AirCargo(int acPcCount,
                        double weight,
                        double volume,
                        AirCraftType act,
                        HandlingType ht,
                        bool isDGR,
                        int dgrPcCount,
                        int dgdCount,
                        int unCount,
                        bool isCAO)
        {
            this.IsDGR = isDGR;
            this.dgr.DgrPcCount = this.dgr.GetDgrPcCount(dgrPcCount);
            this.dgr.DgdCount = this.dgr.GetDgdCount(dgdCount);
            this.dgr.UnCount = this.dgr.GetUnCount(unCount);
            this.dgr.IsCAO = this.dgr.GetIsCAO(isCAO);
            this.ACT = GetAct(act);
            this.HT = GetHt(ht);
            this.ciCount = 1;
            this.AcPcCount = acPcCount;
            this.AcVolume = volume;
            this.GWT = GetAcGWT(weight);
            this.CHW = GetAcCHW(weight, volume);
        }
        public AirCargo(AirCargo other)
        {
            this.packingList = other.packingList;
            this.ACT = other.ACT;
            this.HT = other.HT;
            this.IsDGR = other.IsDGR;
            this.dgr = other.dgr;
            this.ciCount = other.ciCount;
            this.AcPcCount = other.AcPcCount;
            this.AcVolume = other.AcVolume;
            this.GWT = other.GWT;
            this.CHW = other.CHW;
        }
        ~AirCargo() { }

        public override object Cargo
        {
            get { return this; }
        }

        protected override object Freight
        {
            get { return this.Freight; }
        }
    }
}