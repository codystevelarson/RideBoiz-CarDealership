using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GuildCars.UI.Models
{
    public class SearchVM
    {
        public List<SelectListItem> Prices { get; set; }
        public List<SelectListItem> Years { get; set; }

        public SearchVM()
        {
            Prices = new List<SelectListItem>();
            SetPriceListItems();
            Years = new List<SelectListItem>();
            SetYearListItems();

        }

        private void SetPriceListItems()
        {
            for(int i = 5000; i <= 200000; i += 5000)
            {
                if(i == 200000)
                {
                    Prices.Add(new SelectListItem()
                    {
                        Value = i.ToString(),
                        Text = $"${i}+"
                    });
                }
                else
                {
                    if (i > 100000)
                    {
                        i += 20000;
                    }
                    Prices.Add(new SelectListItem()
                    {
                        Value = i.ToString(),
                        Text = $"${i}"
                    });
                    
                } 
            }
        }

        private void SetYearListItems()
        {
            for (int i = DateTime.Now.Year + 1; i >= 2000; i -= 1)
            {
                Years.Add(new SelectListItem()
                {
                    Value = i.ToString(),
                    Text = i.ToString()
                });
            }
        }

    }
}