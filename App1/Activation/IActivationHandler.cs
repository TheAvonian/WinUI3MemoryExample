﻿using System.Threading.Tasks;

namespace App1.Activation;

public interface IActivationHandler
{
    bool CanHandle(object args);

    Task HandleAsync(object args);
}
