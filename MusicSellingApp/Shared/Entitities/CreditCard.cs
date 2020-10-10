using System;
using System.Collections.Generic;
using System.Text;

namespace MusicSellingApp.Shared.Entitities
{
    public class CreditCard
    {
        public string HolderName { get; set; }
        public int CardNumber { get; set; }
        public int Cvv { get; set; }
        public DateTime ExpirationDate { get; set; }

        public CreditCard(string holderName, int cardNumber, int cvv, DateTime expirationDate)
        {
            HolderName = holderName;
            CardNumber = cardNumber;
            Cvv = cvv;
            ExpirationDate = expirationDate;
        }

        public CreditCard()
        {

        }

    }
}
