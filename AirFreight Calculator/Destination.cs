using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFreight_Calculator
{
    static class Destination
    {
        public enum CountryCode
        {
            WW = 0,
            AD, AE, AF, AG, AI, AL, AM, AO, AQ, AR, AS, AT, AU, AW, AX, AZ,
            BA, BB, BD, BE, BF, BG, BH, BI, BJ, BL, BM, BN, BO, BQ, BR, BS, BT, BV, BW, BY, BZ,
            CA, CC, CD, CF, CG, CH, CI, CK, CL, CM, CN, CO, CR, CU, CV, CW, CX, CY, CZ,
            DE, DJ, DK, DM, DO, DZ,
            EC, EE, EG, EH, ER, ES, ET,
            FI, FJ, FK, FM, FO, FR,
            GA, GB, GD, GE, GF, GG, GH, GI, GL, GM, GN, GP, GQ, GR, GS, GT, GU, GW, GY,
            HK, HM, HN, HR, HT, HU,
            ID, IE, IL, IM, IN, IO, IQ, IR, IS, IT,
            JE, JM, JO, JP,
            KE, KG, KH, KI, KM, KN, KP, KR, KW, KY, KZ,
            LA, LB, LC, LI, LK, LR, LS, LT, LU, LV, LY,
            MA, MC, MD, ME, MF, MG, MH, MK, ML, MM, MN, MO, MP, MQ, MR, MS, MT, MU, MV, MW, MX, MY, MZ,
            NA, NC, NE, NF, NG, NI, NL, NO, NP, NR, NU, NZ,
            OM,
            PA, PE, PF, PG, PH, PK, PL, PM, PN, PR, PS, PT, PW, PY,
            QA,
            RE, RO, RS, RU, RW,
            SA, SB, SC, SD, SE, SG, SH, SI, SJ, SK, SL, SM, SN, SO, SR, SS, ST, SV, SX, SY, SZ,
            TC, TD, TF, TG, TH, TJ, TK, TL, TM, TN, TO, TR, TT, TV, TW, TZ,
            UA, UG, UM, US, UY, UZ,
            VA, VC, VE, VG, VI, VN, VU,
            WF, WS,
            XK,
            YE, YT,
            ZA, ZM, ZW
        }
        public enum RegionCode
        {
            CAR, CEM, NOA, SOA,
            JAK, SAS, SEA, SWP,
            AFR, EUR, MDE, SCH
        }
        public enum TcAreaCode
        {
            AMER, EMEA, APAC
        }

        public static TcAreaCode GetAreaCodeByRC(RegionCode rc)
        {
            switch (rc)
            {
                case RegionCode.CAR:
                    return TcAreaCode.AMER;
                case RegionCode.CEM:
                    return TcAreaCode.AMER;
                case RegionCode.NOA:
                    return TcAreaCode.AMER;
                case RegionCode.SOA:
                    return TcAreaCode.AMER;
                case RegionCode.JAK:
                    return TcAreaCode.APAC;
                case RegionCode.SAS:
                    return TcAreaCode.APAC;
                case RegionCode.SEA:
                    return TcAreaCode.APAC;
                case RegionCode.SWP:
                    return TcAreaCode.APAC;
                case RegionCode.AFR:
                    return TcAreaCode.EMEA;
                case RegionCode.EUR:
                    return TcAreaCode.EMEA;
                case RegionCode.MDE:
                    return TcAreaCode.EMEA;
                case RegionCode.SCH:
                    return TcAreaCode.EMEA;
                default:
                    return default;
            }

        }

        public static RegionCode GetRegionCodeByCC(CountryCode cc)
        {
            switch (cc)
            {
                case CountryCode.WW:
                    return default;
				case CountryCode.AD:
					return RegionCode.EUR;
				case CountryCode.AE:
					return RegionCode.MDE;
				case CountryCode.AF:
					return RegionCode.SAS;
				case CountryCode.AG:
					return RegionCode.CAR;
				case CountryCode.AI:
					return RegionCode.CAR;
				case CountryCode.AL:
					return RegionCode.EUR;
				case CountryCode.AM:
					return RegionCode.EUR;
				case CountryCode.AO:
					return RegionCode.AFR;
				case CountryCode.AQ:
					return RegionCode.SWP;
				case CountryCode.AR:
					return RegionCode.SOA;
				case CountryCode.AS:
					return RegionCode.SWP;
				case CountryCode.AT:
					return RegionCode.SCH;
				case CountryCode.AU:
					return RegionCode.SWP;
				case CountryCode.AW:
					return RegionCode.CAR;
				case CountryCode.AX:
					return RegionCode.EUR;
				case CountryCode.AZ:
					return RegionCode.EUR;
				case CountryCode.BA:
					return RegionCode.EUR;
				case CountryCode.BB:
					return RegionCode.CAR;
				case CountryCode.BD:
					return RegionCode.SAS;
				case CountryCode.BE:
					return RegionCode.SCH;
				case CountryCode.BF:
					return RegionCode.AFR;
				case CountryCode.BG:
					return RegionCode.EUR;
				case CountryCode.BH:
					return RegionCode.MDE;
				case CountryCode.BI:
					return RegionCode.AFR;
				case CountryCode.BJ:
					return RegionCode.AFR;
				case CountryCode.BL:
					return RegionCode.CAR;
				case CountryCode.BM:
					return RegionCode.CAR;
				case CountryCode.BN:
					return RegionCode.SEA;
				case CountryCode.BO:
					return RegionCode.SOA;
				case CountryCode.BQ:
					return RegionCode.CAR;
				case CountryCode.BR:
					return RegionCode.SOA;
				case CountryCode.BS:
					return RegionCode.CAR;
				case CountryCode.BT:
					return RegionCode.SAS;
				case CountryCode.BV:
					return RegionCode.SWP;
				case CountryCode.BW:
					return RegionCode.AFR;
				case CountryCode.BY:
					return RegionCode.EUR;
				case CountryCode.BZ:
					return RegionCode.CEM;
				case CountryCode.CA:
					return RegionCode.NOA;
				case CountryCode.CC:
					return RegionCode.SWP;
				case CountryCode.CD:
					return RegionCode.AFR;
				case CountryCode.CF:
					return RegionCode.AFR;
				case CountryCode.CG:
					return RegionCode.AFR;
				case CountryCode.CH:
					return RegionCode.SCH;
				case CountryCode.CI:
					return RegionCode.AFR;
				case CountryCode.CK:
					return RegionCode.SWP;
				case CountryCode.CL:
					return RegionCode.SOA;
				case CountryCode.CM:
					return RegionCode.AFR;
				case CountryCode.CN:
					return RegionCode.SEA;
				case CountryCode.CO:
					return RegionCode.SOA;
				case CountryCode.CR:
					return RegionCode.CEM;
				case CountryCode.CU:
					return RegionCode.CAR;
				case CountryCode.CV:
					return RegionCode.AFR;
				case CountryCode.CW:
					return RegionCode.CAR;
				case CountryCode.CX:
					return RegionCode.SWP;
				case CountryCode.CY:
					return RegionCode.EUR;
				case CountryCode.CZ:
					return RegionCode.SCH;
				case CountryCode.DE:
					return RegionCode.SCH;
				case CountryCode.DJ:
					return RegionCode.AFR;
				case CountryCode.DK:
					return RegionCode.SCH;
				case CountryCode.DM:
					return RegionCode.CAR;
				case CountryCode.DO:
					return RegionCode.CAR;
				case CountryCode.DZ:
					return RegionCode.MDE;
				case CountryCode.EC:
					return RegionCode.SOA;
				case CountryCode.EE:
					return RegionCode.SCH;
				case CountryCode.EG:
					return RegionCode.MDE;
				case CountryCode.EH:
					return RegionCode.MDE;
				case CountryCode.ER:
					return RegionCode.AFR;
				case CountryCode.ES:
					return RegionCode.SCH;
				case CountryCode.ET:
					return RegionCode.AFR;
				case CountryCode.FI:
					return RegionCode.SCH;
				case CountryCode.FJ:
					return RegionCode.SWP;
				case CountryCode.FK:
					return RegionCode.SOA;
				case CountryCode.FM:
					return RegionCode.SEA;
				case CountryCode.FO:
					return RegionCode.EUR;
				case CountryCode.FR:
					return RegionCode.SCH;
				case CountryCode.GA:
					return RegionCode.AFR;
				case CountryCode.GB:
					return RegionCode.EUR;
				case CountryCode.GD:
					return RegionCode.CAR;
				case CountryCode.GE:
					return RegionCode.EUR;
				case CountryCode.GF:
					return RegionCode.SOA;
				case CountryCode.GG:
					return RegionCode.EUR;
				case CountryCode.GH:
					return RegionCode.AFR;
				case CountryCode.GI:
					return RegionCode.EUR;
				case CountryCode.GL:
					return RegionCode.NOA;
				case CountryCode.GM:
					return RegionCode.AFR;
				case CountryCode.GN:
					return RegionCode.AFR;
				case CountryCode.GP:
					return RegionCode.CAR;
				case CountryCode.GQ:
					return RegionCode.AFR;
				case CountryCode.GR:
					return RegionCode.SCH;
				case CountryCode.GS:
					return RegionCode.SOA;
				case CountryCode.GT:
					return RegionCode.CEM;
				case CountryCode.GU:
					return RegionCode.SEA;
				case CountryCode.GW:
					return RegionCode.AFR;
				case CountryCode.GY:
					return RegionCode.SOA;
				case CountryCode.HK:
					return RegionCode.SEA;
				case CountryCode.HM:
					return RegionCode.SWP;
				case CountryCode.HN:
					return RegionCode.CEM;
				case CountryCode.HR:
					return RegionCode.EUR;
				case CountryCode.HT:
					return RegionCode.CAR;
				case CountryCode.HU:
					return RegionCode.SCH;
				case CountryCode.ID:
					return RegionCode.SEA;
				case CountryCode.IE:
					return RegionCode.SCH;
				case CountryCode.IL:
					return RegionCode.MDE;
				case CountryCode.IM:
					return RegionCode.EUR;
				case CountryCode.IN:
					return RegionCode.SAS;
				case CountryCode.IO:
					return RegionCode.AFR;
				case CountryCode.IQ:
					return RegionCode.MDE;
				case CountryCode.IR:
					return RegionCode.MDE;
				case CountryCode.IS:
					return RegionCode.EUR;
				case CountryCode.IT:
					return RegionCode.SCH;
				case CountryCode.JE:
					return RegionCode.EUR;
				case CountryCode.JM:
					return RegionCode.CAR;
				case CountryCode.JO:
					return RegionCode.MDE;
				case CountryCode.JP:
					return RegionCode.JAK;
				case CountryCode.KE:
					return RegionCode.AFR;
				case CountryCode.KG:
					return RegionCode.SEA;
				case CountryCode.KH:
					return RegionCode.SEA;
				case CountryCode.KI:
					return RegionCode.SWP;
				case CountryCode.KM:
					return RegionCode.AFR;
				case CountryCode.KN:
					return RegionCode.CAR;
				case CountryCode.KP:
					return RegionCode.JAK;
				case CountryCode.KR:
					return RegionCode.JAK;
				case CountryCode.KW:
					return RegionCode.MDE;
				case CountryCode.KY:
					return RegionCode.CAR;
				case CountryCode.KZ:
					return RegionCode.SEA;
				case CountryCode.LA:
					return RegionCode.SEA;
				case CountryCode.LB:
					return RegionCode.MDE;
				case CountryCode.LC:
					return RegionCode.CAR;
				case CountryCode.LI:
					return RegionCode.SCH;
				case CountryCode.LK:
					return RegionCode.SAS;
				case CountryCode.LR:
					return RegionCode.AFR;
				case CountryCode.LS:
					return RegionCode.AFR;
				case CountryCode.LT:
					return RegionCode.SCH;
				case CountryCode.LU:
					return RegionCode.SCH;
				case CountryCode.LV:
					return RegionCode.SCH;
				case CountryCode.LY:
					return RegionCode.MDE;
				case CountryCode.MA:
					return RegionCode.MDE;
				case CountryCode.MC:
					return RegionCode.EUR;
				case CountryCode.MD:
					return RegionCode.EUR;
				case CountryCode.ME:
					return RegionCode.EUR;
				case CountryCode.MF:
					return RegionCode.CAR;
				case CountryCode.MG:
					return RegionCode.AFR;
				case CountryCode.MH:
					return RegionCode.SEA;
				case CountryCode.MK:
					return RegionCode.EUR;
				case CountryCode.ML:
					return RegionCode.AFR;
				case CountryCode.MM:
					return RegionCode.SEA;
				case CountryCode.MN:
					return RegionCode.SEA;
				case CountryCode.MO:
					return RegionCode.SEA;
				case CountryCode.MP:
					return RegionCode.SEA;
				case CountryCode.MQ:
					return RegionCode.CAR;
				case CountryCode.MR:
					return RegionCode.AFR;
				case CountryCode.MS:
					return RegionCode.CAR;
				case CountryCode.MT:
					return RegionCode.SCH;
				case CountryCode.MU:
					return RegionCode.AFR;
				case CountryCode.MV:
					return RegionCode.SAS;
				case CountryCode.MW:
					return RegionCode.AFR;
				case CountryCode.MX:
					return RegionCode.NOA;
				case CountryCode.MY:
					return RegionCode.SEA;
				case CountryCode.MZ:
					return RegionCode.AFR;
				case CountryCode.NA:
					return RegionCode.AFR;
				case CountryCode.NC:
					return RegionCode.SWP;
				case CountryCode.NE:
					return RegionCode.AFR;
				case CountryCode.NF:
					return RegionCode.SWP;
				case CountryCode.NG:
					return RegionCode.AFR;
				case CountryCode.NI:
					return RegionCode.CEM;
				case CountryCode.NL:
					return RegionCode.SCH;
				case CountryCode.NO:
					return RegionCode.SCH;
				case CountryCode.NP:
					return RegionCode.SAS;
				case CountryCode.NR:
					return RegionCode.SWP;
				case CountryCode.NU:
					return RegionCode.SWP;
				case CountryCode.NZ:
					return RegionCode.SWP;
				case CountryCode.OM:
					return RegionCode.MDE;
				case CountryCode.PA:
					return RegionCode.SOA;
				case CountryCode.PE:
					return RegionCode.SOA;
				case CountryCode.PF:
					return RegionCode.SWP;
				case CountryCode.PG:
					return RegionCode.SWP;
				case CountryCode.PH:
					return RegionCode.SEA;
				case CountryCode.PK:
					return RegionCode.SAS;
				case CountryCode.PL:
					return RegionCode.SCH;
				case CountryCode.PM:
					return RegionCode.NOA;
				case CountryCode.PN:
					return RegionCode.SOA;
				case CountryCode.PR:
					return RegionCode.NOA;
				case CountryCode.PS:
					return RegionCode.MDE;
				case CountryCode.PT:
					return RegionCode.SCH;
				case CountryCode.PW:
					return RegionCode.SEA;
				case CountryCode.PY:
					return RegionCode.SOA;
				case CountryCode.QA:
					return RegionCode.MDE;
				case CountryCode.RE:
					return RegionCode.AFR;
				case CountryCode.RO:
					return RegionCode.EUR;
				case CountryCode.RS:
					return RegionCode.EUR;
				case CountryCode.RU:
					return RegionCode.EUR;
				case CountryCode.RW:
					return RegionCode.AFR;
				case CountryCode.SA:
					return RegionCode.MDE;
				case CountryCode.SB:
					return RegionCode.SWP;
				case CountryCode.SC:
					return RegionCode.AFR;
				case CountryCode.SD:
					return RegionCode.MDE;
				case CountryCode.SE:
					return RegionCode.SCH;
				case CountryCode.SG:
					return RegionCode.SEA;
				case CountryCode.SH:
					return RegionCode.AFR;
				case CountryCode.SI:
					return RegionCode.SCH;
				case CountryCode.SJ:
					return RegionCode.EUR;
				case CountryCode.SK:
					return RegionCode.SCH;
				case CountryCode.SL:
					return RegionCode.AFR;
				case CountryCode.SM:
					return RegionCode.EUR;
				case CountryCode.SN:
					return RegionCode.AFR;
				case CountryCode.SO:
					return RegionCode.AFR;
				case CountryCode.SR:
					return RegionCode.SOA;
				case CountryCode.SS:
					return RegionCode.AFR;
				case CountryCode.ST:
					return RegionCode.AFR;
				case CountryCode.SV:
					return RegionCode.CEM;
				case CountryCode.SX:
					return RegionCode.CAR;
				case CountryCode.SY:
					return RegionCode.MDE;
				case CountryCode.SZ:
					return RegionCode.AFR;
				case CountryCode.TC:
					return RegionCode.CAR;
				case CountryCode.TD:
					return RegionCode.AFR;
				case CountryCode.TF:
					return RegionCode.AFR;
				case CountryCode.TG:
					return RegionCode.AFR;
				case CountryCode.TH:
					return RegionCode.SEA;
				case CountryCode.TJ:
					return RegionCode.SEA;
				case CountryCode.TK:
					return RegionCode.SOA;
				case CountryCode.TL:
					return RegionCode.SEA;
				case CountryCode.TM:
					return RegionCode.SEA;
				case CountryCode.TN:
					return RegionCode.MDE;
				case CountryCode.TO:
					return RegionCode.SWP;
				case CountryCode.TR:
					return RegionCode.EUR;
				case CountryCode.TT:
					return RegionCode.CAR;
				case CountryCode.TV:
					return RegionCode.SWP;
				case CountryCode.TW:
					return RegionCode.SEA;
				case CountryCode.TZ:
					return RegionCode.AFR;
				case CountryCode.UA:
					return RegionCode.EUR;
				case CountryCode.UG:
					return RegionCode.AFR;
				case CountryCode.UM:
					return RegionCode.SWP;
				case CountryCode.US:
					return RegionCode.NOA;
				case CountryCode.UY:
					return RegionCode.SOA;
				case CountryCode.UZ:
					return RegionCode.SEA;
				case CountryCode.VA:
					return RegionCode.EUR;
				case CountryCode.VC:
					return RegionCode.CAR;
				case CountryCode.VE:
					return RegionCode.SOA;
				case CountryCode.VG:
					return RegionCode.CAR;
				case CountryCode.VI:
					return RegionCode.NOA;
				case CountryCode.VN:
					return RegionCode.SEA;
				case CountryCode.VU:
					return RegionCode.SWP;
				case CountryCode.WF:
					return RegionCode.SWP;
				case CountryCode.WS:
					return RegionCode.SWP;
				case CountryCode.XK:
					return RegionCode.EUR;
				case CountryCode.YE:
					return RegionCode.MDE;
				case CountryCode.YT:
					return RegionCode.AFR;
				case CountryCode.ZA:
					return RegionCode.AFR;
				case CountryCode.ZM:
					return RegionCode.AFR;
				case CountryCode.ZW:
					return RegionCode.AFR;
				default:
                    return default;
            }
        }

		public static string GetAreaNameByTAC(TcAreaCode tac)
        {
            switch (tac)
            {
                case TcAreaCode.AMER:
					return "Americas";
                case TcAreaCode.EMEA:
                    return "Europe Middle-East Africa";
                case TcAreaCode.APAC:
                    return "Asia Pacific";
                default:
                    return default;
            }
        }

		public static string GetRegionNameByRC(RegionCode rc)
        {
            switch (rc)
            {
				case RegionCode.AFR:
					return "Africa";
				case RegionCode.CAR:
					return "Caribbean seacountries";
				case RegionCode.CEM:
					return "Central America";
				case RegionCode.EUR:
					return "Europe Non-Schengen zone";
				case RegionCode.JAK:
					return "Japan and Korea";
				case RegionCode.MDE:
					return "Middle East";
				case RegionCode.NOA:
					return "North America";
				case RegionCode.SAS:
					return "South Asia subcontinent";
				case RegionCode.SCH:
					return "Schengen-agreement countries";
				case RegionCode.SEA:
					return "South-Eastern Asia";
				case RegionCode.SOA:
					return "South America";
				case RegionCode.SWP:
					return "South-West of Pacific";
				default:
                    return default;
            }
        }

		public static string GetCountryNameByCC(CountryCode cc)
        {
            switch (cc)
            {
				case CountryCode.AD:
					return "Andorra";
				case CountryCode.AE:
					return "United Arab Emirates";
				case CountryCode.AF:
					return "Afghanistan";
				case CountryCode.AG:
					return "Antigua and Barbuda";
				case CountryCode.AI:
					return "Anguilla";
				case CountryCode.AL:
					return "Albania";
				case CountryCode.AM:
					return "Armenia";
				case CountryCode.AO:
					return "Angola";
				case CountryCode.AQ:
					return "Antarctica";
				case CountryCode.AR:
					return "Argentina";
				case CountryCode.AS:
					return "American Samoa";
				case CountryCode.AT:
					return "Austria";
				case CountryCode.AU:
					return "Australia";
				case CountryCode.AW:
					return "Aruba";
				case CountryCode.AX:
					return "Aland Islands";
				case CountryCode.AZ:
					return "Azerbaijan";
				case CountryCode.BA:
					return "Bosnia and Herzegovina";
				case CountryCode.BB:
					return "Barbados";
				case CountryCode.BD:
					return "Bangladesh";
				case CountryCode.BE:
					return "Belgium";
				case CountryCode.BF:
					return "Burkina Faso";
				case CountryCode.BG:
					return "Bulgaria";
				case CountryCode.BH:
					return "Bahrain";
				case CountryCode.BI:
					return "Burundi";
				case CountryCode.BJ:
					return "Benin";
				case CountryCode.BL:
					return "Saint Barthelemy";
				case CountryCode.BM:
					return "Bermuda";
				case CountryCode.BN:
					return "Brunei";
				case CountryCode.BO:
					return "Bolivia";
				case CountryCode.BQ:
					return "Bonaire, St Eustatius and Saba";
				case CountryCode.BR:
					return "Brazil";
				case CountryCode.BS:
					return "Bahamas";
				case CountryCode.BT:
					return "Bhutan";
				case CountryCode.BV:
					return "Bouvet Island";
				case CountryCode.BW:
					return "Botswana";
				case CountryCode.BY:
					return "Belarus";
				case CountryCode.BZ:
					return "Belize";
				case CountryCode.CA:
					return "Canada";
				case CountryCode.CC:
					return "Cocos (Keeling) Islands";
				case CountryCode.CD:
					return "Democratic Republic of the Congo";
				case CountryCode.CF:
					return "Central African Republic";
				case CountryCode.CG:
					return "Congo";
				case CountryCode.CH:
					return "Switzerland";
				case CountryCode.CI:
					return "Cote d`Ivoire";
				case CountryCode.CK:
					return "Cook Islands";
				case CountryCode.CL:
					return "Chile";
				case CountryCode.CM:
					return "Cameroon";
				case CountryCode.CN:
					return "China";
				case CountryCode.CO:
					return "Colombia";
				case CountryCode.CR:
					return "Costa Rica";
				case CountryCode.CU:
					return "Cuba";
				case CountryCode.CV:
					return "Cape Verde";
				case CountryCode.CW:
					return "Curacao";
				case CountryCode.CX:
					return "Christmas Island";
				case CountryCode.CY:
					return "Cyprus";
				case CountryCode.CZ:
					return "Czech Republic";
				case CountryCode.DE:
					return "Germany";
				case CountryCode.DJ:
					return "Djibouti";
				case CountryCode.DK:
					return "Denmark";
				case CountryCode.DM:
					return "Dominica";
				case CountryCode.DO:
					return "Dominican Republic";
				case CountryCode.DZ:
					return "Algeria";
				case CountryCode.EC:
					return "Ecuador";
				case CountryCode.EE:
					return "Estonia";
				case CountryCode.EG:
					return "Egypt";
				case CountryCode.EH:
					return "Western Sahara";
				case CountryCode.ER:
					return "Eritrea";
				case CountryCode.ES:
					return "Spain";
				case CountryCode.ET:
					return "Ethiopia";
				case CountryCode.FI:
					return "Finland";
				case CountryCode.FJ:
					return "Fiji";
				case CountryCode.FK:
					return "Falkland Islands (Malvinas)";
				case CountryCode.FM:
					return "Federated States of Micronesia";
				case CountryCode.FO:
					return "Faroe Islands";
				case CountryCode.FR:
					return "France";
				case CountryCode.GA:
					return "Gabon";
				case CountryCode.GB:
					return "United Kingdom";
				case CountryCode.GD:
					return "Grenada";
				case CountryCode.GE:
					return "Georgia";
				case CountryCode.GF:
					return "French Guiana";
				case CountryCode.GG:
					return "Guernsey";
				case CountryCode.GH:
					return "Ghana";
				case CountryCode.GI:
					return "Gibraltar";
				case CountryCode.GL:
					return "Greenland";
				case CountryCode.GM:
					return "Gambia";
				case CountryCode.GN:
					return "Guinea";
				case CountryCode.GP:
					return "Guadeloupe";
				case CountryCode.GQ:
					return "Equatorial Guinea";
				case CountryCode.GR:
					return "Greece";
				case CountryCode.GS:
					return "South Georgia and the South Sandwich Islands";
				case CountryCode.GT:
					return "Guatemala";
				case CountryCode.GU:
					return "Guam";
				case CountryCode.GW:
					return "Guinea-Bissau";
				case CountryCode.GY:
					return "Guyana";
				case CountryCode.HK:
					return "Hong Kong";
				case CountryCode.HM:
					return "Heard Island and McDonald Islands";
				case CountryCode.HN:
					return "Honduras";
				case CountryCode.HR:
					return "Croatia";
				case CountryCode.HT:
					return "Haiti";
				case CountryCode.HU:
					return "Hungary";
				case CountryCode.ID:
					return "Indonesia";
				case CountryCode.IE:
					return "Ireland";
				case CountryCode.IL:
					return "Israel";
				case CountryCode.IM:
					return "Isle of Man";
				case CountryCode.IN:
					return "India";
				case CountryCode.IO:
					return "British Indian Ocean Territory";
				case CountryCode.IQ:
					return "Iraq";
				case CountryCode.IR:
					return "Iran";
				case CountryCode.IS:
					return "Iceland";
				case CountryCode.IT:
					return "Italy";
				case CountryCode.JE:
					return "Jersey";
				case CountryCode.JM:
					return "Jamaica";
				case CountryCode.JO:
					return "Jordan";
				case CountryCode.JP:
					return "Japan";
				case CountryCode.KE:
					return "Kenya";
				case CountryCode.KG:
					return "Kyrgyzstan";
				case CountryCode.KH:
					return "Cambodia";
				case CountryCode.KI:
					return "Kiribati";
				case CountryCode.KM:
					return "Comoros";
				case CountryCode.KN:
					return "Saint Kitts and Nevis";
				case CountryCode.KP:
					return "North Korea";
				case CountryCode.KR:
					return "South Korea";
				case CountryCode.KW:
					return "Kuwait";
				case CountryCode.KY:
					return "Cayman Islands";
				case CountryCode.KZ:
					return "Kazakhstan";
				case CountryCode.LA:
					return "Laos";
				case CountryCode.LB:
					return "Lebanon";
				case CountryCode.LC:
					return "Saint Lucia";
				case CountryCode.LI:
					return "Liechtenstein";
				case CountryCode.LK:
					return "Sri Lanka";
				case CountryCode.LR:
					return "Liberia";
				case CountryCode.LS:
					return "Lesotho";
				case CountryCode.LT:
					return "Lithuania";
				case CountryCode.LU:
					return "Luxembourg";
				case CountryCode.LV:
					return "Latvia";
				case CountryCode.LY:
					return "Libya";
				case CountryCode.MA:
					return "Morocco";
				case CountryCode.MC:
					return "Monaco";
				case CountryCode.MD:
					return "Moldova";
				case CountryCode.ME:
					return "Montenegro";
				case CountryCode.MF:
					return "Saint Martin";
				case CountryCode.MG:
					return "Madagascar";
				case CountryCode.MH:
					return "Marshall Islands";
				case CountryCode.MK:
					return "North Macedonia";
				case CountryCode.ML:
					return "Mali";
				case CountryCode.MM:
					return "Myanmar";
				case CountryCode.MN:
					return "Mongolia";
				case CountryCode.MO:
					return "Macao";
				case CountryCode.MP:
					return "Northern Mariana Islands";
				case CountryCode.MQ:
					return "Martinique";
				case CountryCode.MR:
					return "Mauritania";
				case CountryCode.MS:
					return "Montserrat";
				case CountryCode.MT:
					return "Malta";
				case CountryCode.MU:
					return "Mauritius";
				case CountryCode.MV:
					return "Maldives";
				case CountryCode.MW:
					return "Malawi";
				case CountryCode.MX:
					return "Mexico";
				case CountryCode.MY:
					return "Malaysia";
				case CountryCode.MZ:
					return "Mozambique";
				case CountryCode.NA:
					return "Namibia";
				case CountryCode.NC:
					return "New Caledonia";
				case CountryCode.NE:
					return "Niger";
				case CountryCode.NF:
					return "Norfolk Island";
				case CountryCode.NG:
					return "Nigeria";
				case CountryCode.NI:
					return "Nicaragua";
				case CountryCode.NL:
					return "Netherlands";
				case CountryCode.NO:
					return "Norway";
				case CountryCode.NP:
					return "Nepal";
				case CountryCode.NR:
					return "Nauru";
				case CountryCode.NU:
					return "Niue";
				case CountryCode.NZ:
					return "New Zealand";
				case CountryCode.OM:
					return "Oman";
				case CountryCode.PA:
					return "Panama";
				case CountryCode.PE:
					return "Peru";
				case CountryCode.PF:
					return "French Polynesia";
				case CountryCode.PG:
					return "Papua New Guinea";
				case CountryCode.PH:
					return "Philippines";
				case CountryCode.PK:
					return "Pakistan";
				case CountryCode.PL:
					return "Poland";
				case CountryCode.PM:
					return "Saint Pierre and Miquelon";
				case CountryCode.PN:
					return "Pitcairn";
				case CountryCode.PR:
					return "Puerto Rico";
				case CountryCode.PS:
					return "Palestine";
				case CountryCode.PT:
					return "Portugal";
				case CountryCode.PW:
					return "Palau";
				case CountryCode.PY:
					return "Paraguay";
				case CountryCode.QA:
					return "Qatar";
				case CountryCode.RE:
					return "Reunion";
				case CountryCode.RO:
					return "Romania";
				case CountryCode.RS:
					return "Serbia";
				case CountryCode.RU:
					return "Russia";
				case CountryCode.RW:
					return "Rwanda";
				case CountryCode.SA:
					return "Saudi Arabia";
				case CountryCode.SB:
					return "Solomon Islands";
				case CountryCode.SC:
					return "Seychelles";
				case CountryCode.SD:
					return "Sudan";
				case CountryCode.SE:
					return "Sweden";
				case CountryCode.SG:
					return "Singapore";
				case CountryCode.SH:
					return "Saint Helena, Ascension and Tristan da Cunha";
				case CountryCode.SI:
					return "Slovenia";
				case CountryCode.SJ:
					return "Svalbard and Jan Mayen";
				case CountryCode.SK:
					return "Slovakia";
				case CountryCode.SL:
					return "Sierra Leone";
				case CountryCode.SM:
					return "San Marino";
				case CountryCode.SN:
					return "Senegal";
				case CountryCode.SO:
					return "Somalia";
				case CountryCode.SR:
					return "Suriname";
				case CountryCode.SS:
					return "South Sudan";
				case CountryCode.ST:
					return "Sao Tome and Principe";
				case CountryCode.SV:
					return "El Salvador";
				case CountryCode.SX:
					return "Sint Maarten";
				case CountryCode.SY:
					return "Syria";
				case CountryCode.SZ:
					return "Eswatini";
				case CountryCode.TC:
					return "Turks and Caicos Islands";
				case CountryCode.TD:
					return "Chad";
				case CountryCode.TF:
					return "French Southern Territories";
				case CountryCode.TG:
					return "Togo";
				case CountryCode.TH:
					return "Thailand";
				case CountryCode.TJ:
					return "Tajikistan";
				case CountryCode.TK:
					return "Tokelau";
				case CountryCode.TL:
					return "Timor-Leste";
				case CountryCode.TM:
					return "Turkmenistan";
				case CountryCode.TN:
					return "Tunisia";
				case CountryCode.TO:
					return "Tonga";
				case CountryCode.TR:
					return "Turkey";
				case CountryCode.TT:
					return "Trinidad and Tobago";
				case CountryCode.TV:
					return "Tuvalu";
				case CountryCode.TW:
					return "Taiwan";
				case CountryCode.TZ:
					return "Tanzania";
				case CountryCode.UA:
					return "Ukraine";
				case CountryCode.UG:
					return "Uganda";
				case CountryCode.UM:
					return "United States Minor Outlying Islands";
				case CountryCode.US:
					return "United States of America";
				case CountryCode.UY:
					return "Uruguay";
				case CountryCode.UZ:
					return "Uzbekistan";
				case CountryCode.VA:
					return "Holy See";
				case CountryCode.VC:
					return "Saint Vincent and the Grenadines";
				case CountryCode.VE:
					return "Venezuela";
				case CountryCode.VG:
					return "British Virgin Islands";
				case CountryCode.VI:
					return "United States Virgin Islands";
				case CountryCode.VN:
					return "Vietnam";
				case CountryCode.VU:
					return "Vanuatu";
				case CountryCode.WF:
					return "Wallis and Futuna";
				case CountryCode.WS:
					return "Samoa";
				case CountryCode.WW:
					return "Worldwide";
				case CountryCode.XK:
					return "Kosovo";
				case CountryCode.YE:
					return "Yemen";
				case CountryCode.YT:
					return "Mayotte";
				case CountryCode.ZA:
					return "South Africa";
				case CountryCode.ZM:
					return "Zambia";
				case CountryCode.ZW:
					return "Zimbabwe";
				default:
                    return default;
            }
        }

    }
}
