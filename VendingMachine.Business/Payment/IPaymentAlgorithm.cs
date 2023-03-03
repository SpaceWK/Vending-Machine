﻿namespace VendingMachine.Business.Payment
{
    internal interface IPaymentAlgorithm
    {
        string Name { get; }

        void Run(float price);
    }
}
