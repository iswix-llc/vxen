using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VXEN.Models.Transaction
{
    public enum CardHolderPresentCode : int { Default = 0, Unknown = 1, Present = 2, NotPresent = 3, MailOrder=4, PhoneOrder=5, StandingAuth=6, ECommerce=7 };
    public enum CardPresentCode : int { Default = 0, Unknown = 1, Present = 2, NotPresent = 3 };
    public enum CardInputCode : int {  Default=0, Unknown = 1, MagStripeRead = 2, ContactlessMagstripeRead =3, ManualKeyed=4, ManualKeyedMagstripeFailure=5};
    public enum CVVPresenceCode : int { UseDefault=0, NotProvided=1, Provided=2, Illegible =3, CustomerIllegible=4}
    public enum TerminalCapabilityCode : int {Default=0, Unknown=1, NoTerminal=2, MagstripeReader=3, ContactlessMagStripeReader=4, KeyEntered=5 }
    public enum TerminalEnvironmentCode : int {Default=0, NoTerminal=1, LocalAttended=2, LocalUnattended=3, RemoteAttended=4, RemoteUnattended=5,Ecommerce=6}
    public enum MotoEciCode : int { Default=0, NotUsed=1,Single=2, Recurring=3, Installment=4, SecureElectronicCommerce=5, NonAuthenticatedSecureTransaction=6, NonAuthenticatedSecureECommerceTransaction=7, NonSecureECommerceTransaction=8, AmericanExpressToken =9}
}
