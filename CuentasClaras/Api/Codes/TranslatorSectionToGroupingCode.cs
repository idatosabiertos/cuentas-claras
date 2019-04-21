using CuentasClaras.InputDataModel;
using CuentasClaras.Model;
using System;
using System.Collections.Generic;

namespace CuentasClaras.Api.Codes
{
    public class TranslatorSectionToGroupingCode
    {
        private static Dictionary<int, int> shortList = new Dictionary<int, int>() {
            { 1, 2},
            { 2, 1},
            { 3, 1},
            { 4, 1},
            { 5, 1},
            { 6, 1},
            { 7, 1},
            { 8, 1},
            { 9, 1},
            { 10, 1},
            { 11, 1},
            { 12, 1},
            { 13, 1},
            { 14, 1},
            { 15, 1},
            { 16, 2},
            { 17, 2},
            { 18, 2},
            { 19, 2},

            { 25, 2},
            { 26, 2},
            { 27, 2},
            { 28, 2},
            { 29, 2},

            { 31, 2},
            { 32, 2},
            { 33, 2},
            { 34, 2},
            { 35, 2},
            { 50, 2},
            { 51, 2},
            { 52, 2},
            { 53, 2},

            { 60, 2},
            { 61, 2},
            { 62, 2},
            { 63, 2},
            { 64, 2},
            { 65, 2},
            { 66, 2},
            { 67, 2},
            { 68, 2},

            { 70, 2},

            { 80, 3},
            { 81, 3},
            { 82, 3},
            { 83, 3},
            { 84, 3},
            { 85, 3},
            { 86, 3},
            { 87, 3},
            { 88, 3},
            { 89, 3},
            { 90, 3},
            { 91, 3},
            { 92, 3},
            { 93, 3},
            { 94, 3},
            { 95, 3},
            { 96, 3},
            { 97, 3},
            { 98, 3},
        };
        private static Dictionary<int, int> longList = new Dictionary<int, int>() {
            { 1, 1},
            { 2, 2},
            { 3, 2},
            { 4, 2},
            { 5, 2},
            { 6, 2},
            { 7, 2},
            { 8, 2},
            { 9, 2},
            { 10, 2},
            { 11, 2},
            { 12, 2},
            { 13, 2},
            { 14, 2},
            { 15, 2},
            { 16, 3},
            { 17, 4},
            { 18, 4},
            { 19, 4},

            { 24, 2},
            { 25, 6},
            { 26, 6},
            { 27, 5},
            { 28, 6},
            { 29, 5},

            { 31, 6},
            { 32, 5},
            { 33, 5},
            { 34, 5},
            { 35, 6},
            { 50, 6},
            { 51, 6},
            { 52, 6},
            { 53, 6},

            { 60, 6},
            { 61, 6},
            { 62, 6},
            { 63, 6},
            { 64, 5},
            { 65, 5},
            { 66, 5},
            { 67, 5},
            { 68, 5},

            { 70, 6},

            { 80, 7},
            { 81, 7},
            { 82, 7},
            { 83, 7},
            { 84, 7},
            { 85, 7},
            { 86, 7},
            { 87, 7},
            { 88, 7},
            { 89, 7},
            { 90, 7},
            { 91, 7},
            { 92, 7},
            { 93, 7},
            { 94, 7},
            { 95, 7},
            { 96, 7},
            { 97, 7},
            { 98, 7},
        };
        public static Dictionary<int, int> LongList
        {
            get { return longList; }
            set { longList = value; }
        }

        public static Dictionary<int, int> ShortList
        {
            get { return shortList; }
            set { shortList = value; }
        }

        public static Buyer GetBuyer(string buyerExternalId, string name)
        {
            string[] ids = buyerExternalId.Split("-");

            if (ids.Length < 2)
                return new Buyer()
                {
                    BuyerExternalId = buyerExternalId,
                    Name = name
                };

            //INCISO
            int section = Int32.Parse(ids[0]);
            //UNIDAD
            int unit = Int32.Parse(ids[1]);

            if (longList.ContainsKey(section))
            {
                return new Buyer()
                {
                    BuyerExternalId = longList[section].ToString(),
                    Name = GroupingCodesLongList.Items[longList[section]]
                };
            }
            else
            {
                return new Buyer()
                {
                    BuyerExternalId = buyerExternalId,
                    Name = name
                };
            }
        }
        public static Buyer GetBuyer(ReleaseInputDataModel input) {
            return GetBuyer(input.buyerId, input.buyerName);
        }
    }
}
