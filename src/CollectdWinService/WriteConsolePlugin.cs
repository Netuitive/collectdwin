﻿using System;
using NLog;
using System.Collections.Generic;

namespace BloombergFLP.CollectdWin
{
    internal class WriteConsolePlugin : ICollectdWritePlugin
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Configure()
        {
            Logger.Info("console plugin configured");
        }

        public void Start()
        {
            Logger.Info("console plugin started");
        }

        public void Stop()
        {
            Logger.Info("console plugin stopped");
        }

        public void Write(CollectableValue value)
        {
            Console.WriteLine("ConsolePlugin: {0}", value.getJSON());
        }

        public void Write(Queue<CollectableValue> values)
        {
            foreach (CollectableValue value in values)
            {
                Write(value);
            }
        }
    }
}

// ----------------------------------------------------------------------------
// Copyright (C) 2015 Bloomberg Finance L.P.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// ----------------------------- END-OF-FILE ----------------------------------