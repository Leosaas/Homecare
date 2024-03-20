﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseService.Application.Interface
{
    public interface IPublisher<T> where T : class
    {
        bool SendMessageToQueue(string queueName,T message);
    }
}