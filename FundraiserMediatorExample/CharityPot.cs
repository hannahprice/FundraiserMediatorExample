using System;
using System.Collections.Generic;
using System.Linq;

namespace FundraiserMediatorExample
{
    internal sealed class CharityPot
    {
        public string Name { get; }
        public int Target { get; }

        private readonly Dictionary<string, List<int>> _donations;
        private readonly List<Fundraiser> _fundraisers;

        private bool _targetMet;

        public CharityPot(string name, int target)
        {
            Name = name;
            Target = target;

            _fundraisers = new List<Fundraiser>();
            _donations = new Dictionary<string, List<int>>();

            _targetMet = false;
        }

        public void RegisterFundraiser(Fundraiser fundraiser)
        {
            fundraiser.SetFundraiser(this);
            _fundraisers.Add(fundraiser);
        }

        public void RegisterFundraisers(params Fundraiser[] fundraisers)
        {
            foreach (var fundraiser in fundraisers)
            {
                RegisterFundraiser(fundraiser);
            }
        }

        public void ReceiveDonation(string name, int donation)
        {
            Console.WriteLine($"{Name} received £{donation} from {name}");

            if (!_donations.ContainsKey(name))
            {
                _donations.Add(name, new List<int>());
            }

            _donations[name].Add(donation);

            var runningTotal = _donations.SelectMany(x => x.Value).Sum();

            if (runningTotal >= Target && !_targetMet)
            {
                _targetMet = true;
                Console.WriteLine($"Fundraising target of £{Target} met! Current pot is £{runningTotal}");
            }

            _fundraisers.ForEach(x => x.ReceiveFundraiserUpdate(runningTotal, _donations.ContainsKey(x.Name) ? _donations[x.Name].Sum() : 0 ));
        }
    }
}
