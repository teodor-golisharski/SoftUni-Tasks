using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfolio = new List<Stock>();
        }

        public List<Stock> Portfolio { get; set; }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count
        {
            get { return Portfolio.Count; }
        }
        public void BuyStock(Stock stock)
        {
            if (!Portfolio.Any(x => x.CompanyName == stock.CompanyName))
            {
                if (stock.MarketCapitalization > 10000 && MoneyToInvest > stock.PricePerShare)
                {
                    Portfolio.Add(stock);
                    MoneyToInvest -= stock.PricePerShare;
                }
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.Any(x => x.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }
            else if (Portfolio.Find(x => x.CompanyName == companyName).PricePerShare >= sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }
            Stock temp = Portfolio.Find(x => x.CompanyName == companyName);
            Portfolio.Remove(temp);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            if (Portfolio.Any(x => x.CompanyName == companyName))
            {
                Stock temp = Portfolio.Find(x => x.CompanyName == companyName);
                return temp;
            }
            else
            {
                return null;
            }
        }
        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count > 0)
            {
                return Portfolio.OrderByDescending(x => x.MarketCapitalization).First(x => true);
            }
            return null;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (Stock item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}
