using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class ActivityEntity
    {
        public string Userid { get; set; }
        public string Cmpnynam { get; set; }
        public short ClientUitype { get; set; }
        public DateTime Logindat { get; set; }
        public DateTime Logintim { get; set; }
        public int Sqlsesid { get; set; }
        public short LanguageId { get; set; }
        public short ClientType { get; set; }
        public byte IsOffline { get; set; }
        public int DexRowId { get; set; }
    }
}
