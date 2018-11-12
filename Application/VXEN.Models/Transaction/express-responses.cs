using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VXEN.Models.Transaction
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://transaction.elementexpress.com")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "https://transaction.elementexpress.com", IsNullable = false)]
    public partial class CreditCardSaleResponse
    {

        private CreditCardSaleResponseResponse responseField;

        /// <remarks/>
        public CreditCardSaleResponseResponse Response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://transaction.elementexpress.com")]
    public partial class CreditCardSaleResponseResponse
    {

        private byte expressResponseCodeField;

        private string expressResponseMessageField;

        private byte hostResponseCodeField;

        private string hostResponseMessageField;

        private uint expressTransactionDateField;

        private uint expressTransactionTimeField;

        private string expressTransactionTimezoneField;

        private CreditCardSaleResponseResponseBatch batchField;

        private CreditCardSaleResponseResponseCard cardField;

        private CreditCardSaleResponseResponseTransaction transactionField;

        /// <remarks/>
        public byte ExpressResponseCode
        {
            get
            {
                return this.expressResponseCodeField;
            }
            set
            {
                this.expressResponseCodeField = value;
            }
        }

        /// <remarks/>
        public string ExpressResponseMessage
        {
            get
            {
                return this.expressResponseMessageField;
            }
            set
            {
                this.expressResponseMessageField = value;
            }
        }

        /// <remarks/>
        public byte HostResponseCode
        {
            get
            {
                return this.hostResponseCodeField;
            }
            set
            {
                this.hostResponseCodeField = value;
            }
        }

        /// <remarks/>
        public string HostResponseMessage
        {
            get
            {
                return this.hostResponseMessageField;
            }
            set
            {
                this.hostResponseMessageField = value;
            }
        }

        /// <remarks/>
        public uint ExpressTransactionDate
        {
            get
            {
                return this.expressTransactionDateField;
            }
            set
            {
                this.expressTransactionDateField = value;
            }
        }

        /// <remarks/>
        public uint ExpressTransactionTime
        {
            get
            {
                return this.expressTransactionTimeField;
            }
            set
            {
                this.expressTransactionTimeField = value;
            }
        }

        /// <remarks/>
        public string ExpressTransactionTimezone
        {
            get
            {
                return this.expressTransactionTimezoneField;
            }
            set
            {
                this.expressTransactionTimezoneField = value;
            }
        }

        /// <remarks/>
        public CreditCardSaleResponseResponseBatch Batch
        {
            get
            {
                return this.batchField;
            }
            set
            {
                this.batchField = value;
            }
        }

        /// <remarks/>
        public CreditCardSaleResponseResponseCard Card
        {
            get
            {
                return this.cardField;
            }
            set
            {
                this.cardField = value;
            }
        }

        /// <remarks/>
        public CreditCardSaleResponseResponseTransaction Transaction
        {
            get
            {
                return this.transactionField;
            }
            set
            {
                this.transactionField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://transaction.elementexpress.com")]
    public partial class CreditCardSaleResponseResponseBatch
    {

        private byte hostBatchIDField;

        private byte hostItemIDField;

        private decimal hostBatchAmountField;

        /// <remarks/>
        public byte HostBatchID
        {
            get
            {
                return this.hostBatchIDField;
            }
            set
            {
                this.hostBatchIDField = value;
            }
        }

        /// <remarks/>
        public byte HostItemID
        {
            get
            {
                return this.hostItemIDField;
            }
            set
            {
                this.hostItemIDField = value;
            }
        }

        /// <remarks/>
        public decimal HostBatchAmount
        {
            get
            {
                return this.hostBatchAmountField;
            }
            set
            {
                this.hostBatchAmountField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://transaction.elementexpress.com")]
    public partial class CreditCardSaleResponseResponseCard
    {

        private string aVSResponseCodeField;

        private string cardLogoField;

        private string cardNumberMaskedField;

        private uint bINField;

        /// <remarks/>
        public string AVSResponseCode
        {
            get
            {
                return this.aVSResponseCodeField;
            }
            set
            {
                this.aVSResponseCodeField = value;
            }
        }

        /// <remarks/>
        public string CardLogo
        {
            get
            {
                return this.cardLogoField;
            }
            set
            {
                this.cardLogoField = value;
            }
        }

        /// <remarks/>
        public string CardNumberMasked
        {
            get
            {
                return this.cardNumberMaskedField;
            }
            set
            {
                this.cardNumberMaskedField = value;
            }
        }

        /// <remarks/>
        public uint BIN
        {
            get
            {
                return this.bINField;
            }
            set
            {
                this.bINField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "https://transaction.elementexpress.com")]
    public partial class CreditCardSaleResponseResponseTransaction
    {

        private uint transactionIDField;

        private byte approvalNumberField;

        private ulong referenceNumberField;

        private string acquirerDataField;

        private string processorNameField;

        private string transactionStatusField;

        private byte transactionStatusCodeField;

        private decimal approvedAmountField;

        /// <remarks/>
        public uint TransactionID
        {
            get
            {
                return this.transactionIDField;
            }
            set
            {
                this.transactionIDField = value;
            }
        }

        /// <remarks/>
        public byte ApprovalNumber
        {
            get
            {
                return this.approvalNumberField;
            }
            set
            {
                this.approvalNumberField = value;
            }
        }

        /// <remarks/>
        public ulong ReferenceNumber
        {
            get
            {
                return this.referenceNumberField;
            }
            set
            {
                this.referenceNumberField = value;
            }
        }

        /// <remarks/>
        public string AcquirerData
        {
            get
            {
                return this.acquirerDataField;
            }
            set
            {
                this.acquirerDataField = value;
            }
        }

        /// <remarks/>
        public string ProcessorName
        {
            get
            {
                return this.processorNameField;
            }
            set
            {
                this.processorNameField = value;
            }
        }

        /// <remarks/>
        public string TransactionStatus
        {
            get
            {
                return this.transactionStatusField;
            }
            set
            {
                this.transactionStatusField = value;
            }
        }

        /// <remarks/>
        public byte TransactionStatusCode
        {
            get
            {
                return this.transactionStatusCodeField;
            }
            set
            {
                this.transactionStatusCodeField = value;
            }
        }

        /// <remarks/>
        public decimal ApprovedAmount
        {
            get
            {
                return this.approvedAmountField;
            }
            set
            {
                this.approvedAmountField = value;
            }
        }
    }


}
