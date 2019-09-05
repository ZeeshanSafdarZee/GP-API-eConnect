using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class Gl20000
    {
        public short Openyear { get; set; }
        public int Jrnentry { get; set; }
        public decimal Rctrxseq { get; set; }
        public string Sourcdoc { get; set; }
        public string Refrence { get; set; }
        public string Dscriptn { get; set; }
        public DateTime Trxdate { get; set; }
        public string Trxsorce { get; set; }
        public int Actindx { get; set; }
        public byte Polldtrx { get; set; }
        public string Lastuser { get; set; }
        public DateTime Lstdtedt { get; set; }
        public string Uswhpstd { get; set; }
        public string Orgntsrc { get; set; }
        public short Orgnatyp { get; set; }
        public short Qkofset { get; set; }
        public short Series { get; set; }
        public short Ortrxtyp { get; set; }
        public string Orctrnum { get; set; }
        public string Ormstrid { get; set; }
        public string Ormstrnm { get; set; }
        public string Ordocnum { get; set; }
        public DateTime Orpstddt { get; set; }
        public string Ortrxsrc { get; set; }
        public short OrigDtaseries { get; set; }
        public int OrigSeqNum { get; set; }
        public int Seqnumbr { get; set; }
        public short DtaGlStatus { get; set; }
        public decimal DtaIndex { get; set; }
        public string Curncyid { get; set; }
        public short Currnidx { get; set; }
        public string Ratetpid { get; set; }
        public string Exgtblid { get; set; }
        public decimal Xchgrate { get; set; }
        public DateTime Exchdate { get; set; }
        public DateTime Time1 { get; set; }
        public short Rtclcmtd { get; set; }
        public decimal Noteindx { get; set; }
        public byte Ictrx { get; set; }
        public string Orcomid { get; set; }
        public int Originje { get; set; }
        public short Periodid { get; set; }
        public decimal Debitamt { get; set; }
        public decimal Crdtamnt { get; set; }
        public decimal Ordbtamt { get; set; }
        public decimal Orcrdamt { get; set; }
        public DateTime Docdate { get; set; }
        public int Pstgnmbr { get; set; }
        public int Ppsgnmbr { get; set; }
        public decimal Denxrate { get; set; }
        public short Mctrxstt { get; set; }
        public string CorrespondingUnit { get; set; }
        public byte Voided { get; set; }
        public int BackOutJe { get; set; }
        public short BackOutJeYear { get; set; }
        public int CorrectingJe { get; set; }
        public short CorrectingJeYear { get; set; }
        public int OriginalJe { get; set; }
        public decimal OriginalJeSeqNum { get; set; }
        public short OriginalJeYear { get; set; }
        public short LedgerId { get; set; }
        public byte AdjustmentTransaction { get; set; }
        public string Aprvluserid { get; set; }
        public DateTime Apprvldt { get; set; }
        public DateTime DexRowTs { get; set; }
        public int DexRowId { get; set; }
    }
}
