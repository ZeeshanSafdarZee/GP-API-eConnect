using System;
using System.Collections.Generic;

namespace GP.API.Entities
{
    public partial class PMApplyEntity
    {
        public string Vendorid { get; set; }
        public DateTime Docdate { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Glpostdt { get; set; }
        public DateTime Time1 { get; set; }
        public string Vchrnmbr { get; set; }
        public short Doctype { get; set; }
        public string Apfrdcnm { get; set; }
        public DateTime ApplyFromGlpostDate { get; set; }
        public string Fromcurr { get; set; }
        public decimal Apfrmaplyamt { get; set; }
        public decimal Apfrmdisctaken { get; set; }
        public decimal Apfrmdiscavail { get; set; }
        public decimal Apfrmwrofamt { get; set; }
        public decimal ActualApplyToAmount { get; set; }
        public decimal ActualDiscTakenAmount { get; set; }
        public decimal ActualDiscAvailTaken { get; set; }
        public decimal ActualWriteOffAmount { get; set; }
        public decimal Apfrmexrate { get; set; }
        public decimal Apfrmdenrate { get; set; }
        public short Apfrmrtclcmeth { get; set; }
        public short Apfrmmctrxstt { get; set; }
        public string Aptvchnm { get; set; }
        public short Aptodcty { get; set; }
        public string Aptodcnm { get; set; }
        public DateTime Aptodcdt { get; set; }
        public DateTime ApplyToGlpostDate { get; set; }
        public string Curncyid { get; set; }
        public short Currnidx { get; set; }
        public decimal Appldamt { get; set; }
        public decimal Distknam { get; set; }
        public decimal Disavtkn { get; set; }
        public decimal Wrofamnt { get; set; }
        public decimal Orappamt { get; set; }
        public decimal Ordistkn { get; set; }
        public decimal Ordatkn { get; set; }
        public decimal Orwrofam { get; set; }
        public decimal Aptoexrate { get; set; }
        public decimal Aptodenrate { get; set; }
        public short Aptortclcmeth { get; set; }
        public short Aptomctrxstt { get; set; }
        public decimal Ppsamded { get; set; }
        public decimal Gstdsamt { get; set; }
        public string Taxdtlid { get; set; }
        public byte Posted { get; set; }
        public decimal Ten99amnt { get; set; }
        public decimal Rlganlos { get; set; }
        public decimal Apyfrmrndamt { get; set; }
        public decimal Apytorndamt { get; set; }
        public decimal Apytornddisc { get; set; }
        public decimal Oapyfrmrndamt { get; set; }
        public decimal Oapytorndamt { get; set; }
        public decimal Oapytornddisc { get; set; }
        public decimal SettledGainCreditCurrT { get; set; }
        public decimal SettledLossCreditCurrT { get; set; }
        public decimal SettledGainDebitCurrTr { get; set; }
        public decimal SettledLossDebitCurrTr { get; set; }
        public decimal SettledGainDebitDiscAv { get; set; }
        public decimal SettledLossDebitDiscAv { get; set; }
        public short RevaluationStatus { get; set; }
        public decimal Credit1099Amount { get; set; }
        public short Deften99type { get; set; }
        public short Deften99boxnumber { get; set; }
        public int DexRowId { get; set; }
    }
}
