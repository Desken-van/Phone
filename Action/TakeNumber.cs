using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Phone.Models;
using System.Linq;
using Phone.Repository;
using System.Web.Mvc;

namespace Phone.Action
{
    public class TakeNumber : Controller
    {
        IRepository repo;
        public TakeNumber(IRepository r)
        {
            repo = r;
        }
        public  IEnumerable<PhoneNumber> Take(string text)
        {
            string pattern = "[+()0-9-]{5,20}";
            var matches = Regex.Matches(text, pattern);
            PhoneNumber[] data = new PhoneNumber[matches.Count];
            int i = 0;
            foreach (Match match in matches)
            {
                PhoneNumber part = new PhoneNumber
                {
                    Id = i + 1,
                    Number = match.Value
                };
                data[i] = part;
                i++;
            }
            IEnumerable<PhoneNumber> phonedata = from p in data
                                                 orderby p.Id
                                                 select p;
            return phonedata;
        }
    public bool Validate(string number)
        {
            string pattern = "[+()0-9-]{5,20}";
            bool validate;
            if (Regex.IsMatch(number, pattern, RegexOptions.IgnoreCase))
            {
                validate = true;
            }
            else
            {
                validate = false;
            }
            return validate;
        }
    }
}
