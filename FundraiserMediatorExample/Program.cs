namespace FundraiserMediatorExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var charity = new CharityPot("StrepsilsForBane", 300);
            
            var fundraiser1 = new Fundraiser("Michelle");
            var fundraiser2 = new Fundraiser("Raphael");
            var fundraiser3 = new Fundraiser("William");

            charity.RegisterFundraisers(fundraiser1, fundraiser2, fundraiser3);

            fundraiser1.DonateToFundraiser(50);
            fundraiser3.DonateToFundraiser(45);
            fundraiser3.DonateToFundraiser(5);
            fundraiser2.DonateToFundraiser(16);
            fundraiser1.DonateToFundraiser(250);
        }
    }
}
