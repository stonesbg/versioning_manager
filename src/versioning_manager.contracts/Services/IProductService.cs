﻿using System.Collections.Generic;
using versioning_manager.contracts.Models;

namespace versioning_manager.contracts.Services
{
    public interface IProductService
    {
        IEnumerable<IProduct> GetProducts();
    }
}