namespace VXEN.Enums.Transaction
{
    //TODO: Implement Transaction Enums as needed. Pull requests welcome.

    public enum BatchCloseType
    {
        Regular = 0,
        Force = 1
    }

    public enum BatchIndexCode
    {
        Current = 0,
        FirstPrevious = 1
    }

    public enum BatchGroupingCode
    {
        FullBatch = 0,
        SingleBatch = 1
    }

    public enum BatchQueryType
    {
        Total = 0,
        Item = 1
    }

    public enum BooleanType
    {
        False = 0,
        True = 1
    }

    public enum CardInputCode
    {
        Default = 0,
        Unknown = 1,
        MagstripeRead = 2,
        ContactlessMagstripeRead = 3,
        ManualKeyed = 4,
        ManualKeyedMagstripeFailure = 5
    }

    public enum CardLogo
    {
        Visa = 1,
        MasterCard = 2,
        Amex = 3,
        Discover = 4,
        Diners = 5,
        StoredValue = 6,
        Other = 7,
        JCB = 8,
        CarteBlanche = 9,
        Interac = 10
    }

    public enum CardPresentCode
    {
        Default = 0,
        Unknown = 1,
        Present = 2,
        NotPresent = 3,
        MailOrder = 4,
        PhoneOrder = 5,
        StandingAuth = 6,
        ECommerce = 7
    }

    public enum CardholderPresentCode
    {
        Default = 0,
        Unknown = 1,
        Present = 2,
        NotPresent = 3,
        MailOrder = 4,
        PhoneOrder = 5,
        StandingAuth = 6,
        ECommerce = 7
    }

    public enum CheckType
    {
        Personal = 0,
        Business = 1
    }

    public enum ConsentCode
    {
        NotSpecified = 0,
        FaceToFace = 1,
        Phone = 2,
        Internet = 3
    }

    public enum CVVPresenceCode
    {
        UseDefault = 0,
        NotProvided = 1,
        Provided = 2,
        Illegible = 3,
        CustomerIllegible = 4
    }

    public enum CVVResponseType
    {
        Regular = 0,
        Extended = 1
    }

    public enum DCCRequested
    {
        OptOut = 0,
        OptIn = 1,
        Suspended = 2
    }

    public enum DDAAccountType
    {
        Checking = 0,
        Savings = 1
    }

    public enum DeviceInputCode
    {
        NotUsed = 0,
        Unknown = 1,
        Terminal = 2,
        Keyboard = 3
    }

    public enum Device
    {
        Default = 0,
        MagtekEncryptedSwipe = 1,
        EncryptedInputDevice = 2
    }

    public enum ElectronicCommerceIndicator
    {
        Null = 0,
        NotUsed = 1,
        Single = 2,
        Recurring = 3,
        Installment = 4,
        SecureECommerce = 5,
        NonAuthenticatedSecureTransaction = 6,
        NonAuthenticatedSecureECommerceTransaction = 7,
        NonSecureECommerceTransaction = 8,
        AmericanExpressToken = 9
    }

    public enum EncryptedFormat
    {
        Default = 0,
        Format1_Magtek = 1,
        Format2_IngenicoDPP = 2,
        Format3_IngenicoOnGuard = 3,
        Format4_IDTech = 4,
        Format5_VeriFoneVxDevicesMercuryFormat = 5,
        Format6_InfinitePeripherals = 6,
        Format7_VeriFoneMxDevices = 7
    }

    public enum ExpressResponseCode
    {
        Approved = 0,
        PartialApproval = 5,
        DCCRequested = 7,
        Decline = 20,
        ExpiredCard = 21,
        DuplicateApproved = 22,
        Duplicate = 23,
        PickUpCard = 24,
        ReferralCallIssuer = 25,
        BalanceNotAvailable = 30,
        NotDefined = 90,
        InvalidData = 101,
        InvalidAccount = 102,
        InvalidRequest = 103,
        AuthorizationFailed = 104,
        NotAllowed = 105,
        OutOfBalance = 120,
        CommunicationError = 1001,
        HostError = 1002,
        OtherError = 1009
    }

    public enum ExtendedBooleanType
    {
        Null = -1,
        False = 0,
        True = 1
    }

    public enum ExtendedStatusType
    {
        Null = -1,
        Active = 0,
        Disabled = 1,
        Removed = 2
    }

    public enum ExtendedRunFrequency
    {
        Null = -1,
        OneTimeFuture = 0,
        Daily = 1,
        Weekly = 2,
        BiWeekly = 3,
        Monthly = 4,
        BiMonthly = 5,
        Quarterly = 6,
        SemiAnnually = 7,
        Yearly = 8
    }

    public enum MarketCode
    {
        Default = 0,
        AutoRental = 1,
        DirectMarketing = 2,
        ECommerce = 3,
        FoodRestaurant = 4,
        HotelLodging = 5,
        Petroleum = 6,
        Retail = 7,
        QSR = 8
    }

    public enum MotoECICode
    {
        Default = 0,
        NotUsed = 1,
        Single = 2,
        Recurring = 3,
        Installment = 4,
        SecureElectronicCommerce = 5,
        NonAuthenticatedSecureTransaction = 6,
        NonAuthenticatedSecureECommerceTransaction = 7,
        NonSecureECommerceTransaction = 8,
        AmericanExpressToken = 9
    }

    public enum PASSUpdaterBatchStatus
    {
        Null = 0,
        IncludedInNextBatch = 1,
        NotIncludedInNextBatch = 2
    }

    public enum PASSUpdaterOption
    {
        Null = 0,
        AutoUpdateEnabled = 1,
        AutoUpdateDisabled = 2
    }

    public enum PASSUpdaterStatus
    {
        Null = 0,
        UpdateInProgress = 1,
        MatchNoChanges = 2,
        MatchAccountChanges = 3,
        MatchExpirationChange = 4,
        MatchAccountClosed = 5,
        MatchContactCardholder = 6,
        NoMatchParticipating = 7,
        NoMatchNonParticipating = 8,
        InvalidInfo = 9,
        NoResponse = 10,
        NotAllowed = 11,
        Error = 12,
        PASSUpdaterDisabled = 13,
        NotUpdated = 14
    }

    public enum PaymentAccountType
    {
        CreditCard = 0,
        Checking = 1,
        Savings = 2,
        ACH = 3,
        Other = 4
    }

    public enum ReversalType
    {
        System = 0,
        Full = 1,
        Partial = 2
    }

    public enum RunFrequency
    {
        OneTimeFuture = 0,
        Daily = 1,
        Weekly = 2,
        BiWeekly = 3,
        Monthly = 4,
        BiMonthly = 5,
        Quarterly = 6,
        SemiAnnually = 7,
        Yearly = 8
    }

    public enum ScheduledTaskRunStatus
    {
        Null = -1,
        Pending = 0,
        Running = 1,
        Completed = 2,
        Error = 3,
        SystemRetry = 4,
        ManualRetry = 5
    }

    public enum TerminalEncryptionFormat
    {
        Default = 0,
        Format1 = 1,
        Format2 = 2,
        Format3 = 3,
        Format4 = 4
    }

    public enum TransactionSetupMethod
    {
        Default = 0,
        CreditCardSale = 1,
        CreditCardAuthorization = 2,
        CreditCardAVSOnly = 3,
        CreditCardForce = 4,
        DebitCardSale = 5,
        CheckSaleReservedForFutureUse = 6,
        PaymentAccountCreate = 7,
        PaymentAccountUpdate = 8,
        Sale = 9
    }

    public enum StatusType
    {
        Active = 0,
        Disabled = 1,
        Removed = 2
    }

    public enum TerminalType
    {
        Unknown = 0,
        PointOfSale = 1,
        ECommerce = 2,
        MOTO = 3,
        FuelPump = 4,
        ATM = 5,
        Voice = 6,
        Mobile = 7,
        WebSiteGiftCard = 8
    }

    public enum TerminalCapabilityCode
    {
        Default = 0,
        Unknown = 1,
        NoTerminal = 2,
        MagstripeReader = 3,
        ContactlessMagstripeReader = 4,
        KeyEntered = 5
    }

    public enum TerminalEnvironmentCode
    {
        Default = 0,
        NoTerminal = 1,
        LocalAttended = 2,
        LocalUnattended = 3,
        RemoteAttended = 4,
        RemoteUnattended = 5,
        ECommerce = 6
    }

    public enum TokenProvider
    {
        Null = 0,
        ExpressPASS = 1,
        OmniToken = 2,
        Paymetric = 3,
        TransArmor = 4
    }

    public enum TransactionStatusCode
    {
        InProcess = 0,
        Approved = 1,
        Declined = 2,
        Duplicate = 3,
        Voided = 4,
        Authorized = 5,
        AuthCompleted = 6,
        Reversed = 7,
        Success = 8,
        Returned = 9,
        Pending = 10,
        Queued = 11,
        Unknown = 12,
        OtherError = 13,
        Originated = 14,
        Settled = 15,
        PartialApproved = 16,
        Rejected = 17,
        DCCRequested = 20
    }

    public enum WalletType
    {
        Null = 0,
        Android = 1,
        Apple = 2,
        Samsung = 3
    }
}