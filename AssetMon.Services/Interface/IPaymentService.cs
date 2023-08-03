﻿using AssetMon.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetMon.Services.Interface
{
    public interface IPaymentService
    {
        Task<ResultDTO<IEnumerable<PaymentDTO>>> GetPaymentsAsync(string vehicleId, bool trackChanges);
    }
}
