﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6.View
{
    public interface IView
    {
        bool ConfirmationSale(Property property);
        bool ConfirmationPurchase(Property property);

    }
}