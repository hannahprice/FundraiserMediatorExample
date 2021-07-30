using System;

namespace FundraiserMediatorExample
{
    internal sealed class Fundraiser
    {
        public string Name { get; }

        private CharityPot _charity;

        public Fundraiser(string name)
        {
            Name = name;
        }

        public void SetFundraiser(CharityPot charity)
        {
            _charity = charity;
        }

        public void DonateToFundraiser(int funds)
        {
            _charity.ReceiveDonation(Name, funds);
        }

        public void ReceiveFundraiserUpdate(int total, int personalTotal)
        {
            Console.WriteLine($"{Name} received fundraiser update for {_charity.Name}. Total raised = £{total}, total raised by {Name} = £{personalTotal}");
        }
    }
}
